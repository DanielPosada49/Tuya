using Logistica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistica.Repository
{
    public interface ILogisticRepository
    {
        IEnumerable<Logistic> GetLogistic();
        Logistic GetLogisticById(int LogisticId);
        void InsertLogistic(Logistic logistic);
        void DeleteLogistic(int LogisticId);
        void UpdateLogistic(Logistic logistic);
        void Save();
    }
}
