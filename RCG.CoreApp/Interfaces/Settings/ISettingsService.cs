using RCG.CoreApp.Enums;
using RCG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RCG.CoreApp.Interfaces.Settings
{
    public interface ISettingsService
    {
        Task<string> GetApplConfigValueAsync(EnumMaster.ApplConfig applConfigEnum);
        Task<bool> SaveApplConfigValueAsync(ApplConfigs applConfigs);
    }
}
