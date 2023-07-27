
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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TechBlogContext context) : base(context)
        {
        }

        public IList<Category> GetCategoryByName(string name)
        {
            return _context.Categories
            .Where(p => p.Name.Contains(name))
            .ToList();
        }

        public bool HasPosts(Category category)
        {
            // Kiểm tra xem danh mục có bài viết nào hay không
            return _context.Set<Post>().Any(p => p.CategoryId == category.CategoryId);
        }
    }
}
