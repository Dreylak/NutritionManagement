using Common.Persistance.Models;
using System;

namespace Customer.Domain.Models
{
    public class CustomerModel : AuditableEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
