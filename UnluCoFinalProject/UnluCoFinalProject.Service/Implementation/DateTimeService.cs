using System;
using UnluCoFinalProject.Service.Contract;

namespace UnluCoFinalProject.Service.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}