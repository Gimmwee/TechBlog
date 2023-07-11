using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Core.Repository.IRepository;

namespace TechBlog.Core.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ITagRepository TagRepository { get; }
        IPostTagMapRepository PostTagMapRepository { get; }
        ICommentRepository CommentRepository { get; }
        void SaveChange();
    }
}
