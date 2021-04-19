using AutoMapper;
using Common.Modules;
using Library;

namespace EmployeeFactory.DataProviders
{
    internal class DataConverter
    {
        private readonly MapperConfiguration mapperConfiguration;
        private readonly Mapper mapper;

        public DataConverter()
        {
            mapperConfiguration = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeModel>()
                    .ForMember(d => d.DayOfBirth, o => o.MapFrom(s => GenerationHelper.ToStringByFormatter(s.DayOfBirth, GenerationFormatter.StandardFormatter)))
                    .ForMember(d => d.JoinedDate, o => o.MapFrom(s => GenerationHelper.ToStringByFormatter(s.JoinedDate, GenerationFormatter.StandardFormatter)))
                    .ForMember(d => d.LeftDate, o => o.MapFrom(s => GenerationHelper.ToStringByFormatter(s.LeftDate, GenerationFormatter.StandardFormatter)))
                    .ForMember(d => d.CreatedDate, o => o.MapFrom(s => GenerationHelper.ToStringByFormatter(s.CreatedDate, GenerationFormatter.StandardFormatter)))
                    .ForMember(d => d.UpdatedDate, o => o.MapFrom(s => GenerationHelper.ToStringByFormatter(s.UpdatedDate, GenerationFormatter.StandardFormatter)));
            });

            mapper = new Mapper(mapperConfiguration);
        }

        public void ToEmployeeModel(Employee employee, ref EmployeeModel employeeModel)
        {
            mapper.Map<Employee, EmployeeModel>(employee, employeeModel);
        }
    }
}
