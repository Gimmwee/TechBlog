
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechBlog.Core.DataContext;
using TechBlog.Core.Models;
using TechBlog.Core.Repository.GenericRepo;
using TechBlog.Core.Repository.IRepository;

namespace TechBlog.Core.Repository.ImplementRepo
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(TechBlogContext context) : base(context)
        {

        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment
            {

                PostId = postId,
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody
            };
            _context.Add(comment);
            _context.SaveChanges();
        }
        /// <summary>
        /// get comments for post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IList<Comment> GetCommentsForPost(int postId)
        {
            return _context.Comments.Where(c => c.PostId == postId).ToList();
        }
        /// <summary>
        /// get comment for post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public IList<Comment> GetCommentsForPost(Post post)
        {
            return post.Comments.ToList();
        }
    }
}
