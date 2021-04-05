using RCG.CoreApp.Enums;
using RCG.CoreApp.Interfaces.Repositories;
using RCG.CoreApp.Interfaces.Settings;
using RCG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RCG.CoreApp.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly IApplConfigsRepository _applConfigsRepository;
        public SettingsService(IApplConfigsRepository applConfigsRepository)
        {
            this._applConfigsRepository = applConfigsRepository;
        }

        public async Task<string> GetApplConfigValueAsync(EnumMaster.ApplConfig applConfigEnum)
        {
            var applConfigValue = string.Empty;
            var applConfig = await this._applConfigsRepository.GetApplConfigValueAsync(applConfigEnum);
            if (applConfig != null)
            {
                applConfigValue = applConfig.Value;
            }
            return applConfigValue;
        }

        public async Task<bool> SaveApplConfigValueAsync(ApplConfigs applConfigs)
        {
            if (Directory.Exists(applConfigs.Value))
            {
                var nameEnum = (EnumMaster.ApplConfig)Enum.Parse(typeof(EnumMaster.ApplConfig), applConfigs.Name);
                var applConfig = await this._applConfigsRepository.GetApplConfigValueAsync(nameEnum);
                if (applConfig != null)
                {
                    applConfig.Value = applConfigs.Value;
                    applConfig.LastModifiedBy = applConfigs.LastModifiedBy;
                    applConfig.LastModifiedOn = applConfigs.LastModifiedOn;
                }

                var success = await this._applConfigsRepository.SaveApplConfigValueAsync(applConfig);
                return success;
            }
            else
            {
                return false;
            }
        }
    }
}
