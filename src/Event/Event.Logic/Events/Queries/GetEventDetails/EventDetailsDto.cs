using Common.Mappings;
using Event.Domain.Models;
using System;

namespace Event.Logic.Events.Queries.GetEventDetails
{
    public class EventDetailsDto : IMapFrom<EventModel>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public string Address { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CustomersCapacity { get; set; }

        public int CustomersEnrolled { get; set; }
    }
}
