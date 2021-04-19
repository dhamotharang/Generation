using Common.Modules;
using Common.Responses;
using FrameworkSetting;
using Library;
using System;
using System.Linq;

namespace EmployeeFactory.DataProviders
{
    internal class DataFactory
    {
        private readonly DataConverter converter = new DataConverter();

        public ResponseOutput<object> GetDetail(Guid _id, Guid detailId)
        {
            try
            {
                using (var context = new EmployeeContext())
                {
                    var data = context.Employee.FirstOrDefault(o => o.Id.Equals(detailId)/* && o.CreatedBy.Equals(_id)*/);
                    if (data == null)
                    {
                        return new ResponseOutput<object>(null, NotificationType.Error, GenerationStatusCode.NotFound, GenerationResource.MSG_006, null);
                    }

                    EmployeeModel result = new EmployeeModel();
                    converter.ToEmployeeModel(data, ref result);

                    return new ResponseOutput<object>(result, NotificationType.Success, GenerationStatusCode.Ok, null, null);
                }
            }
            catch (Exception ex)
            {
                return new ResponseOutput<object>(null, NotificationType.Error, GenerationStatusCode.InternalServerError,
                    GenerationResource.MSG_005, GenerationHelper.GetMessageDetailOfException(ex));
            }
        }
    }
}
