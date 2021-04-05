using RCG.CoreApp.Interfaces.Repositories;
using RCG.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using RCG.CoreApp.Enums;

namespace RCG.Data.Repositories
{
    public class ApplConfigsRepository : IApplConfigsRepository
    {
        private readonly IRepositoryAsync<ApplConfigs> _repository;
        public ApplConfigsRepository(IRepositoryAsync<ApplConfigs> repository)
        {
            this._repository = repository;
        }

        public async Task<ApplConfigs> GetApplConfigValueAsync(EnumMaster.ApplConfig applConfig)
        {
            try
            {
                var indexFilePath = await this._repository.Entities.Where(a => a.Id == (int)applConfig).FirstOrDefaultAsync();
                return indexFilePath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SaveApplConfigValueAsync(ApplConfigs applConfig)
        {
            if (applConfig.Id > 0)
            {
                await this._repository.UpdateAsync(applConfig, applConfig.Id);
            }
            else
            {
                await this._repository.AddAsync(applConfig);
            }

            return true;
        }
    }
}
