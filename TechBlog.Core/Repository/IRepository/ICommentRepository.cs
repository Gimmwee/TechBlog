
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Core.Models;
using TechBlog.Core.Repository.GenericRepo;

namespace TechBlog.Core.Repository.IRepository
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {

        void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);
        IList<Comment> GetCommentsForPost(int postId);
        IList<Comment> GetCommentsForPost(Post post);
    }
}
