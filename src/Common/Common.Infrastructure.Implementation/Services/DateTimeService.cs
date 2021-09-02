using Common.Infrastructure.Interface;
using System;

namespace Common.Infrastructure.Implementation.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
