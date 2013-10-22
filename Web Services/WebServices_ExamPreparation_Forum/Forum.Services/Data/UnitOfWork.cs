using System;
using System.Web.UI.WebControls;
using Forum.Data;
using Forum.Model;
using SchoolSystem.Repositories;

namespace Forum.Services.Data
{
    public class UnitOfWork : IDisposable
    {
        private ForumDbContext context = new ForumDbContext();
        public IRepository<Category> categoryRepository { get; private set; }
        public IRepository<Comment> commentRepository { get; private set; }
        public IRepository<Post> postRepository { get; private set; }
        public IRepository<Thread> threadRepository { get; private set; }
        public IRepository<User> userRepository { get; private set; }
        public IRepository<Vote> voteRepository { get; private set; }
        private bool disposed = false;

        public UnitOfWork()
        {
            categoryRepository = new EfRepository<Category>(context);
            commentRepository = new EfRepository<Comment>(context);
            postRepository = new EfRepository<Post>(context);
            threadRepository = new EfRepository<Thread>(context);
            userRepository = new EfRepository<User>(context);
            voteRepository = new EfRepository<Vote>(context);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
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