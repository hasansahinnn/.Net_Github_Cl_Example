using MyOnionApi1.Application.Interfaces;
using System;

namespace MyOnionApi1.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
