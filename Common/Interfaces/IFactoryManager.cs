using Common.Responses;
using System;

namespace Common.Interfaces
{
    public interface IFactoryManager
    {
        ResponseOutput<object> GetDetail(Guid _id, Guid detailId);
        ResponseOutput<object> UpdateDetail(Guid _id, Guid detailId, ref object model);
    }
}
