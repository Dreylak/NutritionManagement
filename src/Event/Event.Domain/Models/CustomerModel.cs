using System.Collections.Generic;

namespace Event.Domain.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        public ICollection<EventModel> Events { get; set; }
    }
}
