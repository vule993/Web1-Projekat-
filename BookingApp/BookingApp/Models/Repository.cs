using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Repository<T,TC>where T:class where TC:DbContext
    {
        private readonly TC _ctx;   //context
        public Repository(TC ctx)
        {
            _ctx = ctx;
        }


        public void Add(T toAdd)
        {
            _ctx.Set<T>().Add(toAdd);
            Save();
        }

        public void Delete(T toDelete)
        {
            _ctx.Set<T>().Remove(toDelete);
            Save();
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> query = _ctx.Set<T>();
            return query;
        }

        public int Save()
        {
            return _ctx.SaveChanges();
        }

        public void Update(T toUpdate)
        {
            _ctx.Entry(toUpdate).State = EntityState.Modified;
            Save();
        }
    }
}