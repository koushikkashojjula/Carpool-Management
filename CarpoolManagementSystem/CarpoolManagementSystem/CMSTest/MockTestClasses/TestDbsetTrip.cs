using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginSignup.Models;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace CMSTest.TripClasses
{
    
        class TestDbsetTrip<T> : DbSet<T>, IQueryable, IEnumerable<T> where T : class
        {
            ObservableCollection<T> data = new ObservableCollection<T>();
            IQueryable _query;
            public TestDbsetTrip()
            {
                _query = data.AsQueryable();
            }
            public override T Add(T item)
            {
                data.Add(item);
                return item;
            }
            public override T Remove(T item)
            {
                data.Remove(item);
                return item;
            }
            IQueryProvider IQueryable.Provider
            {
                get { return _query.Provider; }
            }
            Type IQueryable.ElementType
            {
                get { return _query.ElementType; }
            }
            public override ObservableCollection<T> Local
            {
                get { return new ObservableCollection<T>(data); }
            }
            System.Linq.Expressions.Expression IQueryable.Expression
            {
                get { return _query.Expression; }
            }
            //public T Retrieve(T item)
            //{
            //    data.Single(t=>t.)
            //}
            //public override Trip Find(params object[] keyValues)
            //{
            //    //return base.Find(keyValues);
            //    return this.SingleOrDefault(t => t.id == (int)keyValues.Single());
            //    foreach(var item in data)
            //    {
            //        if(d)
            //    }
            //}
        }
    }

