
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Core.Models;
using TechBlog.Core.Repository.GenericRepo;

namespace TechBlog.Core.Repository.IRepository
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        IEnumerable<Tag> GetTagByUrlSlug(string urlSlug);

        IList<Tag> GetTagByName(string name);
    }
}
