
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Core.DataContext;
using TechBlog.Core.Repository.ImplementRepo;
using TechBlog.Core.Repository.IRepository;

namespace TechBlog.Core.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly TechBlogContext _context;
        private IPostRepository postRepository;
        private ICategoryRepository categoryRepository;
        private ITagRepository tagRepository;
        private IPostTagMapRepository postTagMapRepository;
        private ICommentRepository commentRepository;

        public UnitOfWork(TechBlogContext context = null)
        {
            this._context = context ?? new TechBlogContext();
        }


        public ICategoryRepository CategoryRepository => categoryRepository ?? new CategoryRepository(_context);

        public IPostRepository PostRepository => postRepository ?? new PostRepository(_context);

        public ITagRepository TagRepository => tagRepository ?? new TagRepository(_context);

        public IPostTagMapRepository PostTagMapRepository => postTagMapRepository ?? new PostTagMapRepository(_context);

        public ICommentRepository CommentRepository => commentRepository ?? new CommentRepository(_context);

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
