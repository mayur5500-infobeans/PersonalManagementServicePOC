using Repository.PersonalManagementServicePOC.Context.Implementation;
using Repository.PersonalManagementServicePOC.DTOs;
using Repository.PersonalManagementServicePOC.Repositories.Interfaces;
using System;
using System.Linq;

namespace Repository.PersonalManagementServicePOC.Repositories.Implementations
{
    public class CommitteeRepository : ICommitteeRepository, IDisposable
    {
        private readonly CommitteeContext _dbContext;

        public CommitteeRepository(CommitteeContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        public CommitteeDto GetCommittee(Guid id)
        {
            var committee = _dbContext.Committees.Where(c => c.Id == id).Select(c => new CommitteeDto()
            {
                Id = c.Id,
                Name = c.Name
            });
            return committee.SingleOrDefault();
        }

        public void Create(CommitteeDto model)
        {
            _dbContext.Committees.Add(model);
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
