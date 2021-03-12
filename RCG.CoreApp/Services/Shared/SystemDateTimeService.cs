using RCG.CoreApp.Interfaces.Shared;
using System;

namespace Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}