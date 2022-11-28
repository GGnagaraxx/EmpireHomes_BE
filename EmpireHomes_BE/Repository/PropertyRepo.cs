using EmpireHomes_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpireHomes_BE.Repository
{
    public class PropertyRepo : IRepoBase<Property>, IDisposable
    {

        private bool disposed = false;
        private DataContext context;
        public PropertyRepo(DataContext context) { 
            this.context = context;
        }

        public async Task<List<Property>> GetAll()
        {
            return await context.Properties.ToListAsync();
        }

        public async Task<Property?> GetById(int id)
        {
            return await context.Properties.FindAsync(id);
        }

        public async void Add(Property item)
        {
            await context.Properties.AddAsync(item);
        }

        public void Update(Property item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Property? property = context.Properties.Find(id);
            if (property != null)
            {
                context.Properties.Remove(property);
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
