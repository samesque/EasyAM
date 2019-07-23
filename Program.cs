using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Lname = "Scharlach";
            person.Fname = "Rot";

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, Employee>()
                    .ForMember(dest => dest.Lastname, src => src.MapFrom(p => p.Lname))
                    .ForMember(dest => dest.Firstname, src => src.MapFrom(p => p.Fname));
            });
            IMapper mapper = config.CreateMapper();
            Employee employee = mapper.Map<Person,Employee>(person);

        }
    }
    class Employee
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
    class Person
    {
        public string Lname { get; set; }
        public string Fname { get; set; }
    }
}
