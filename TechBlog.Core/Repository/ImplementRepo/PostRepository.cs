
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Core.DataContext;
using TechBlog.Core.Models;
using TechBlog.Core.Repository.GenericRepo;
using TechBlog.Core.Repository.IRepository;

namespace TechBlog.Core.Repository.ImplementRepo
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(TechBlogContext context) : base(context)
        {
        }
        /// <summary>
        /// count post for category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int CountPostsForCategory(string category)
        {
            return _context.Posts.Count(x => x.Category.Name.ToLower() == category.ToLower());
        }
        /// <summary>
        /// Find post by year,month , urlslug
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        public Post FindPost(int year, int month, string urlSlug)
        {
            return _context.Posts.SingleOrDefault(p =>
                p.PostedOn != null &&
                p.PostedOn.Value.Year == year &&
                p.PostedOn.Value.Month == month &&
                p.UrlSlug == urlSlug);
        }
        /// <summary>
        /// get latestpost
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public IList<Post> GetLatestPost(int size)
        {
            return _context.Posts
        .OrderByDescending(p => p.PostedOn)
        .Take(size)
        .ToList();
        }
        /// <summary>
        /// get post by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IList<Post> GetPostsByCategory(string category)
        {
            return _context.Posts
        .Where(p => p.Category.Name == category)
        .ToList();
        }
        /// <summary>
        /// get post by month
        /// </summary>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _context.Posts
                .Where(x => x.PostedOn != null && x.PostedOn.Value.Month == monthYear.Month && x.PostedOn.Value.Year == monthYear.Year)
                .ToList();
        }
        /// <summary>
        /// get published post
        /// </summary>
        /// <returns></returns>
        public IList<Post> GetPublisedPosts()
        {
            return _context.Posts
        .Where(p => p.Published == true)
        .ToList();
        }
        /// <summary>
        /// get unpublished post
        /// </summary>
        /// <returns></returns>
        public IList<Post> GetUnpublisedPosts()
        {
            return _context.Posts
        .Where(p => p.Published == false)
        .ToList();
        }
        /// <summary>
        /// get highest post
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public IList<Post> GetHighestPosts(int size)
        {
            return _context.Posts
        .OrderByDescending(p => p.ViewCount)
        .Take(size)
        .ToList();
        }
        /// <summary>
        /// get mostviewd post
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public IList<Post> GetMostViewedPost(int size)
        {
            return _context.Posts
       .Where(p => p.Published == true)
       .OrderByDescending(p => p.ViewCount)
       .Take(size)
       .ToList();
        }

        public Post GetPostById(int id)
        {
            return _context.Posts.FirstOrDefault(c => c.PostId == id);
        }

        public Post GetPostByUrlSlug(string urlSlug)
        {
            return _context.Posts.FirstOrDefault(c => c.UrlSlug == urlSlug);
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return _context.Posts.Where(p => _context.PostTagMaps
  .Where(ptm => _context.Tags
  .Where(t => t.Name.ToLower() == tag.ToLower())
  .Select(t => t.TagId)
  .Contains(ptm.TagId))
  .Select(ptm => ptm.PostId)
  .Contains(p.PostId)).ToList();
        }

        public Post GetPosts(int id)
        {
            return _context.Posts
            .Include(p => p.Category)
            .SingleOrDefault(p => p.PostId == id);
        }

        public Post GetLatedPost()
        {
            return _context.Posts.OrderByDescending(p => p.PostedOn).FirstOrDefault();
        }

        public IList<Post> GetPostsByTitle(string title)
        {
            return _context.Posts
            .Where(p => p.Title.Contains(title))
            .ToList();
        }

        public bool IsTitleDuplicate(string title)
        {
            // Check if there is any post with the given title
            return _context.Posts.Any(p => p.Title == title);
        }

        public void Detach(Post post)
        {
            _context.Entry(post).State = EntityState.Detached;
        }

        public IList<Post> GetAllPosts()
        {
            return _context.Posts.Include(p => p.Category).ToList();
        }

        public IList<Post> GetPostsByCategoryId(int categoryId)
        {
            return _context.Posts
            .Where(p => p.CategoryId == categoryId)
            .ToList();
        }
    }
}

