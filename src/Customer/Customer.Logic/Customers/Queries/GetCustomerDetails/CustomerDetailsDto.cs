using AutoMapper;
using Common.Mappings;
using Customer.Domain.Models;
using System;

namespace Customer.Logic.Customers.Queries.GetCustomerDetails
{
    public class CustomerDetailsDto : IMapFrom<CustomerModel>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerModel, CustomerDetailsDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => (int)((DateTime.Now - src.BirthDate).TotalDays / 365)));
        }
    }
}
