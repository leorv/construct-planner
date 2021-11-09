using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public ConstructContext ConstructContext
        {
            get { return Context as ConstructContext; }
        }
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
