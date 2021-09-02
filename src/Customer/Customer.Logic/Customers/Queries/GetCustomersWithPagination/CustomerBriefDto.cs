using AutoMapper;
using Common.Mappings;
using Customer.Domain.Models;
using System;

namespace Customer.Logic.Customers.Queries.GetCustomersWithPagination
{
    public class CustomerBriefDto : IMapFrom<CustomerModel>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerModel, CustomerBriefDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => (int)((DateTime.UtcNow - src.BirthDate).TotalDays / 365)));
        }
    }
}
