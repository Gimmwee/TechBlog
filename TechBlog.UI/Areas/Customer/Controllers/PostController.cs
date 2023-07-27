
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using TechBlog.Core.Models;
using TechBlog.Core.Repository.ImplementRepo;
using TechBlog.Core.Repository.UnitOfWork;

namespace TechBlog.UI.Controllers
{
    [Area("Customer")]
    [Route("Post/{action}")]
    public class PostController : Controller
    {
        private IUnitOfWork uow;

        public PostController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public IActionResult Index(int? page)
        {

            int pageSize = 2; // Set the number of records per page
            int pageNumber = (page ?? 1); // If no page number is specified, default to 1

            var posts = uow.PostRepository.GetPublisedPosts()
        .OrderByDescending(p => p.PostId)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();

            // Pass the records and page information to the view
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = uow.PostRepository.GetPublisedPosts().Count();
            return View(posts);
        }


        public IActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var post = uow.PostRepository.GetPosts(id.Value);
                if (post != null)
                {
                    return View(post);
                }
            }
            return RedirectToAction("Index");

        }

        public IActionResult PostByCategory(string category)
        {
            var post = uow.PostRepository.GetPostsByCategory(category);
            if (post != null)
            {
                return View(post);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Comment(int postId, string email, string name, string commentText, string commentHeader)
        {
            var result = uow.PostRepository.Find(postId);
            Comment comment = new Comment
            {
                Name = name,
                Email = email,
                PostId = postId,
                CommentText = commentText,
                CommentHeader = commentHeader,
                CommentTime = DateTime.Now,
                Published = false
            };
            if (comment != null)
            {
                uow.CommentRepository.Add(comment);
                uow.SaveChange();
                return RedirectToAction("Details", "Post", new { id = result.PostId });
            }
            return RedirectToAction("Index");
        }
        public IActionResult Search(string searchTerm)
        {
            var postspublic = uow.PostRepository.GetPublisedPosts();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Perform search and filter posts based on the search term
                var posts = uow.PostRepository.GetPostsByTitle(searchTerm);
                ViewBag.SearchTerm = searchTerm;

                if (posts.Any())
                {
                    // Display the search results
                    return View(posts);
                }
                else
                {
                    ViewBag.Message = "Không tim thấy \"" + searchTerm + "\".";
                    // If no search results found, display all published posts
                    return View(postspublic);
                }
            }
            else
            {
                // If no search term provided, display all published posts
                return View(postspublic);
            }
        }

    }
}
