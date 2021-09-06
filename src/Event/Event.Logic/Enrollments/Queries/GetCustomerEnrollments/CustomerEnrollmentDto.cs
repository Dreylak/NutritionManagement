using AutoMapper;
using Common.Mappings;
using Event.Domain.Models;
using System;

namespace Event.Logic.Enrollments.Queries.GetCustomerEnrollments
{
    public class CustomerEnrollmentDto : IMapFrom<EventModel>
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Address { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CustomersCapacity { get; set; }

        public int CustomersEnrolled { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EventModel, CustomerEnrollmentDto>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
