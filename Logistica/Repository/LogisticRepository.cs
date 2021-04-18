using Logistica.DBContext;
using Logistica.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistica.Repository
{
    public class LogisticRepository : ILogisticRepository
    {
        private readonly LogisticContext _dbContext;

        public LogisticRepository(LogisticContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteLogistic(int LogisticId)
        {
            var product = _dbContext.Logistics.Find(LogisticId);
            _dbContext.Logistics.Remove(product);
            Save();
        }

        public IEnumerable<Logistic> GetLogistic()
        {
            return _dbContext.Logistics.ToList();
        }

        public Logistic GetLogisticById(int Logistics)
        {
            return _dbContext.Logistics.Find(Logistics);
        }

        public void InsertLogistic(Logistic logistic)
        {
            _dbContext.Add(logistic);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateLogistic(Logistic logistic)
        {
            _dbContext.Entry(logistic).State = EntityState.Modified;
            Save();
        }
    }
}
