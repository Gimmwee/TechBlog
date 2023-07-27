
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Core.Models;
using TechBlog.Core.Repository.GenericRepo;

namespace TechBlog.Core.Repository.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        IList<Category> GetCategoryByName(string name);
        bool HasPosts(Category category);
    }
}
