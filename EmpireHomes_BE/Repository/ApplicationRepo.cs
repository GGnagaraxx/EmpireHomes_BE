using EmpireHomes_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpireHomes_BE.Repository
{
    public class ApplicationRepo : IRepoBase<Application>, IDisposable
    {

        private bool disposed = false;
        private DataContext context;
        public ApplicationRepo(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Application>> GetAll()
        {
            return await context.Applications.ToListAsync();
        }

        public async Task<Application?> GetById(int id)
        {
            return await context.Applications.FindAsync(id);
        }

        public async void Add(Application item)
        {
            await context.Applications.AddAsync(item);
        }

        public void Update(Application item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Application? application = context.Applications.Find(id);
            if (application != null)
            {
                context.Applications.Remove(application);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        //=================================================//
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
