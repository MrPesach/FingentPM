using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RCG.CoreApp.Interfaces.Repositories;
using RCG.Domain.Entities;

namespace RCG.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Users> _repository;

        public UserRepository(IRepositoryAsync<Users> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Users>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<Users>> GetNonAdminListAsync()
        {
            return await _repository.Entities.Where(p => !p.IsAdmin).ToListAsync();
        }

        public async Task<Users> GetByIdAsync(long id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Users> GetByUsernameAsync(long? id, string username)
        {
            if (id != null)
            {
                return await _repository.Entities.Where(p => p.Username == username).FirstOrDefaultAsync();
            }
            else
            {
                return await _repository.Entities.Where(p => p.Id != id && p.Username == username).FirstOrDefaultAsync();
            }
        }

        public async Task<long> InsertAsync(Users user)
        {
            await _repository.AddAsync(user);
            return user.Id;
        }

        public async Task UpdateAsync(Users User)
        {
            await _repository.UpdateAsync(User, User.Id);
        }


        public async Task DeleteAsync(Users User)
        {
            await _repository.DeleteAsync(User);
        }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //CreateMap<UserResponse, User>().ReverseMap();
        }
    }
}