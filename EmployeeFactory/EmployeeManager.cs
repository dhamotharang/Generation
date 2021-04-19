using Common.Interfaces;
using Common.Responses;
using EmployeeFactory.DataProviders;
using System;

namespace EmployeeFactory
{
    public class EmployeeManager : IFactoryManager
    {
        private readonly DataFactory factory = new DataFactory();

        public ResponseOutput<object> GetDetail(Guid _id, Guid detailId)
        {
            return factory.GetDetail(_id, detailId);
        }

        public ResponseOutput<object> UpdateDetail(Guid _id, Guid detailId, ref object model)
        {
            throw new NotImplementedException();
        }
    }
}
