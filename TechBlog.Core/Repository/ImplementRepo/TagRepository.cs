
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
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(TechBlogContext context) : base(context)
        {

        }
        /// <summary>
        /// get tag by urlslug
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        public IEnumerable<Tag> GetTagByUrlSlug(string urlSlug)
        {
            return _context.Tags.Where(t => t.UrlSlug == urlSlug);
        }
    }
}
