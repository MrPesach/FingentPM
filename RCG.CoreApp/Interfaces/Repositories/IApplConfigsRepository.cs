using RCG.CoreApp.Enums;
using RCG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCG.CoreApp.Interfaces.Repositories
{
    public interface IApplConfigsRepository
    {
        Task<ApplConfigs> GetApplConfigValueAsync(EnumMaster.ApplConfig applConfig);
        Task<bool> SaveApplConfigValueAsync(ApplConfigs applConfig);
    }
}
