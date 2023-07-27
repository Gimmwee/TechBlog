
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Data;
using TechBlog.Core.Common;
using TechBlog.Core.Models;
using TechBlog.Core.Repository.UnitOfWork;

namespace TechBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("PostManage/{action}")]
    [Authorize(Roles = ("Admin, Blog Owner, Contributor"))]
    public class PostManageController : Controller
    {

        private readonly IUnitOfWork _uow;
        public PostManageController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: PostManageController
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1); 

            var posts = _uow.PostRepository.GetAllPosts()
                                .OrderByDescending(p => p.PostId)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            // Pass the records and page information to the view
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = _uow.PostRepository.GetAll().Count();
            return View(posts);

        }

        // GET: PostManageController/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var post = _uow.PostRepository.GetPosts(id.Value);
                if (post != null)
                {
                    return View(post);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: PostManageController/Create
        [Authorize(Roles = "Admin, Blog Owner, Contributor")]
        public ActionResult Create()
        {
            var categories = _uow.CategoryRepository.GetAll();
            var list = new List<SelectListItem>();

            foreach (var category in categories)
            {
                list.Add(new SelectListItem { Value = category.CategoryId.ToString(), Text = category.Name });
            }

            ViewData["categories"] = list;

            return View();
        }

        // POST: PostManageController/Create
        [Authorize(Roles = "Admin, Blog Owner, Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                // Check if title is already taken
                bool isTitleTaken = _uow.PostRepository.GetAll().Any(p => p.Title == post.Title);
                if (isTitleTaken)
                {
                    TempData["Message"] = "The title is already taken. Please choose a different title!";
                }
                else if (post.ViewCount < 0 || post.RateCount < 0 || post.TotalRate < 0)
                {
                    TempData["Message"] = "View count, rate count, and total rate cannot be negative.";
                }
                else
                {
                    post.UrlSlug = SeoUrlHepler.ToUrlSlug(post.Title);
                    post.PostedOn = DateTime.Now;
                    post.Modified = DateTime.Now;

                    _uow.PostRepository.Add(post);
                    _uow.SaveChange();

                    return RedirectToAction("Index");
                }
            }

            var categories = _uow.CategoryRepository.GetAll();
            var list = new List<SelectListItem>();

            foreach (var category in categories)
            {
                list.Add(new SelectListItem { Value = category.CategoryId.ToString(), Text = category.Name });
            }

            ViewData["categories"] = list;

            return View(post);
        }

        // GET: PostManageController/Edit/5
        [Authorize(Roles = ("Admin, Blog Owner, Contributor"))]
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cate = _uow.CategoryRepository.GetAll();
            var list = new List<SelectListItem>();
            foreach (var item in cate)
            {
                list.Add(new SelectListItem() { Value = item.CategoryId.ToString(), Text = item.Name });
            }
            ViewData["categories"] = list;

            Post posts = _uow.PostRepository.GetEntityById(id.Value);

            if (posts == null)
            {
                return NotFound();
            }
            return View(posts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post posts)
        {
            //if (ModelState.IsValid)
            //{
            //    // Check if title is already taken
            //    bool isTitleTaken = _uow.PostRepository.GetAll().Any(p => p.PostId != posts.PostId && p.Title == posts.Title);
            //    if (isTitleTaken)
            //    {
            //        TempData["Message"] = "The title is already taken. Please choose a different title!";
            //    }
            //    else
            //    {
            //        posts.UrlSlug = SeoUrlHepler.ToUrlSlug(posts.Title);
            //        posts.PostedOn = DateTime.Now;
            //        posts.Modified = DateTime.Now;
            //        _uow.PostRepository.Update(posts);
            //        _uow.SaveChange();
            //        // Detach the entity from the DbContext to prevent tracking conflicts
            //        //_uow.PostRepository.Detach(posts);
            //        return RedirectToAction("Index");
            //    }
            //}

            //var categories = _uow.CategoryRepository.GetAll();
            //var list = new List<SelectListItem>();
            //foreach (var category in categories)
            //{
            //    list.Add(new SelectListItem { Value = category.CategoryId.ToString(), Text = category.Name });
            //}
            //ViewData["categories"] = list;

            //return View(posts);


            posts.UrlSlug = SeoUrlHepler.ToUrlSlug(posts.Title);
            posts.PostedOn = DateTime.Now;
            posts.Modified = DateTime.Now;
            _uow.PostRepository.Update(posts);
            _uow.SaveChange();
            // Detach the entity from the DbContext to prevent tracking conflicts
            //_uow.PostRepository.Detach(posts);
            return RedirectToAction("Index");
        }

        // GET: PostManageController/Delete/5
        [Authorize(Roles = ("Admin, Blog Owner"))]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                _uow.PostRepository.Delete(id.Value);
                _uow.SaveChange();
            }
            return RedirectToAction("Index");
        }

        public ActionResult LastedPost()
        {

            var posts = _uow.PostRepository.GetLatestPost(5);

            return View(posts.ToList());
        }

        public ActionResult MostViewedPosts()
        {
            var posts = _uow.PostRepository.GetMostViewedPost(5);

            return View(posts.ToList());
        }

       [Authorize(Roles = ("Admin, Blog Owner"))]
        public ActionResult PublisedPosts()
        {
            var posts = _uow.PostRepository.GetPublisedPosts();

            return View(posts.ToList());
        }

        [Authorize(Roles = ("Admin, Blog Owner"))]
        public ActionResult UnpublisedPosts()
        {
            var posts = _uow.PostRepository.GetUnpublisedPosts();

            return View(posts.ToList());
        }

        public IActionResult SearchPost(string? searchTerm)
        {

            var posts = _uow.PostRepository.GetPostsByTitle(searchTerm);
            ViewBag.SearchTerm = searchTerm;
            if (!posts.Any())
            {
                ViewBag.Message = "Không tim thấy \"" + searchTerm + "\".";
            }
            return View(posts);
        }
    }
}
