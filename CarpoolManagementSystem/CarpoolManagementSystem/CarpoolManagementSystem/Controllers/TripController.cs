using LoginSignup.Models;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Net.Mail;

namespace LoginSignup.Controllers
{
    public class TripController : Controller
    {
        public ITripContext tp = new TripContext();
        public TripController() { }
        public TripController(ITripContext I_t)
        {
            tp = I_t;
        }
        public ActionResult ShowTripData(SearchBarModel f)
        {
            if(tp == null) tp = new TripContext();
            List<Trip> l_t = new List<Trip>();
            if (f.source == null && f.destination == null && f.date == null)   //all fields null
            {
                l_t = tp.Trips.ToList();
            }
            else if (f.source == null && f.destination == null)      //only date is provided
            {
                l_t = tp.Trips.Where(u => u.date == f.date).ToList();
            }
            else if (f.source == null && f.date == null)    //only destination is provided
            {
                l_t = tp.Trips.Where(u => u.destination == f.destination).ToList();
            }
            else if (f.destination == null && f.date == null)   //only source is provided
            {
                l_t = tp.Trips.Where(u => u.source == f.source).ToList();
            }
            else if (f.date == null)         //Source and destination are provided
            {
                l_t = tp.Trips.Where(u => u.source == f.source && u.destination == f.destination).ToList();
            }
            else if (f.destination == null)      //Source and date are provided
            {
                l_t = tp.Trips.Where(u => u.source == f.source && u.date == f.date).ToList();
            }
            else if (f.source == null)           // destination and date are provided
            {
                l_t = tp.Trips.Where(u => u.destination == f.destination && u.date == f.date).ToList();
            }
            else               //all fields are provided
            {
                l_t = tp.Trips.Where(u => u.source == f.source && u.date == f.date && u.destination == f.destination).ToList();
            }
            return View("ShowTripData", l_t);
        }

        public ActionResult TripDetails(int id)
        {
            //TripContext tp = new TripContext();
            Trip x = tp.Trips.Find(id);
            return View("TripDetails", x);
        }

        [HttpGet]
        public string JoinTrip(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    TripGroupContext g = new TripGroupContext();
                    var tg = g.TripGroups.Where(b => b.Id.ToString() == id).ToArray();
                    foreach (var d in tg)
                    {
                        if (d.People == User.Identity.Name)
                        {
                            return "2";
                        }
                    }

                    TripGroup t_g = new TripGroup();
                    t_g.Id = Int32.Parse(id);
                    t_g.People = User.Identity.Name;
                    t_g.TripAdmin = false;
                    g.TripGroups.Add(t_g);
                    g.SaveChanges();
                    TripContext t_s = new TripContext();
                    Trip t = t_s.Trips.Single(d => d.id.ToString() == id);
                    t.vacant_seats = t.vacant_seats - 1;
                    t_s.SaveChanges();
                    return "3";
                }
                catch
                {
                    return "3";
                }
                
            }

            else
                return "1";

        }

        public ActionResult deleteTrip(int id)
        {
            TripContext s = new TripContext();
            Trip t = s.Trips.Single(u => u.id == id);
            s.Trips.Remove(t);
            s.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public string ShowJoinButton(string id)
        {
            if(tp == null)  tp = new TripContext();
            try
            {
                TripGroupContext g = new TripGroupContext();
                AspNetUsersContext u = new AspNetUsersContext();
                Trip te = tp.Trips.Single(a1 => a1.id.ToString() == id);
                AspNetUsers a = u.AspNetUsers.Single(c1 => c1.Id == te.created_by);

                if (a.UserName == User.Identity.Name)
                {
                    return "1";
                }
                else if (te.vacant_seats == 0)
                {
                    return "2";
                }
                else
                {
                    return "3";
                }
            }
            catch
            {
                return "3";
            }
        }
        [HttpGet]
        public string sendEmail(string id, string emailText)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    string toEmail = null;
                    TripContext a = new TripContext();

                    Trip b = a.Trips.Single(u => u.id.ToString() == id);
                    AspNetUsersContext us = new AspNetUsersContext();
                    AspNetUsers au = us.AspNetUsers.Single(z => z.Id == b.created_by);
                    toEmail = au.Email;
                    if (SMTPSendEmail(toEmail, User.Identity.Name + " wants to carpool with you", emailText))
                    {
                        return "success";
                    }
                    else
                    {
                        return "fail";
                    }
                }
                else return "fail";
            }
            catch
            {
                return "fail";
            }
        }
        public bool SMTPSendEmail(string emailID, string subject, string emailText)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("carpoolmanagementsystem@gmail.com", "Passw0rd!_");


                //Setting From , To and CC
                MailAddress From = new MailAddress("carpoolmanagementsystem@gmail.com");
                MailAddress To = new MailAddress(emailID);



                MailMessage mail = new MailMessage(From, To);
                mail.Body = emailText;
                mail.Subject = subject;


                client.Send(mail);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
