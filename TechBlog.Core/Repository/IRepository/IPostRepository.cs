﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Core.Models;
using TechBlog.Core.Repository.GenericRepo;

namespace TechBlog.Core.Repository.IRepository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Post FindPost(int year, int month, string urlSlug);
        Post GetPosts(int id);
        IList<Post> GetPublisedPosts();
        IList<Post> GetUnpublisedPosts();
        IList<Post> GetLatestPost(int size);
        IList<Post> GetPostsByMonth(DateTime monthYear);
        int CountPostsForCategory(string category);
        IList<Post> GetPostsByCategory(string category);
        IList<Post> GetPostsByTag(string tag);
        IList<Post> GetMostViewedPost(int size);
        IList<Post> GetHighestPosts(int size);
        Post GetPostByUrlSlug(string urlSlug);
        Post GetLatedPost();
        IList<Post> GetPostsByTitle(string title);
        bool IsTitleDuplicate(string title);
        void Detach(Post post);
        IList<Post> GetAllPosts();

        IList<Post> GetPostsByCategoryId(int categoryId);

    }
}
