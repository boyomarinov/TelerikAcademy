using System;
using BloggingSystem.Data;
using BloggingSystem.Model;
using BloggingSystem.Repositories;

namespace BloggingSystem.Services.Data
{
    public class UnitOfWork : IDisposable
    {
        private BloggingSystemDbContext context = new BloggingSystemDbContext();
        public IRepository<Tag> tagRepository { get; private set; }
        public IRepository<Comment> commentRepository { get; private set; }
        public IRepository<Post> postRepository { get; private set; }
        public IRepository<User> userRepository { get; private set; }
        private bool disposed = false;

        public UnitOfWork()
        {
            this.tagRepository = new EfRepository<Tag>(this.context);
            this.commentRepository = new EfRepository<Comment>(this.context);
            this.postRepository = new EfRepository<Post>(this.context);
            this.userRepository = new EfRepository<User>(this.context);
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
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}