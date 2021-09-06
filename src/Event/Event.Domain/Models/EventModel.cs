using Common.Persistance.Models;
using System;
using System.Collections.Generic;

namespace Event.Domain.Models
{
    public class EventModel : AuditableEntity
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

        public ICollection<CustomerModel> Customers { get; private set; } = new List<CustomerModel>();
    }
}
