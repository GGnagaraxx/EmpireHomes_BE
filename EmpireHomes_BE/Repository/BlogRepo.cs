using EmpireHomes_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpireHomes_BE.Repository
{
    public class BlogRepo : IRepoBase<Blog>, IDisposable
    {

        private bool disposed = false;
        private DataContext context;
        public BlogRepo(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Blog>> GetAll()
        {
            return await context.Blogs.ToListAsync();
        }

        public async Task<Blog?> GetById(int id)
        {
            return await context.Blogs.FindAsync(id);
        }

        public async void Add(Blog item)
        {
            await context.Blogs.AddAsync(item);
        }

        public void Update(Blog item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Blog? blog = context.Blogs.Find(id);
            if (blog != null)
            {
                context.Blogs.Remove(blog);
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
