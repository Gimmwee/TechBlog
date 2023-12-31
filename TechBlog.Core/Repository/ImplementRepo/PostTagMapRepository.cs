﻿
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
    public class PostTagMapRepository : GenericRepository<PostTagMap>, IPostTagMapRepository
    {
        public PostTagMapRepository(TechBlogContext context) : base(context)
        {

        }

    }
}
