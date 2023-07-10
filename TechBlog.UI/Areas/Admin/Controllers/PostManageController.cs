
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            var posts = _uow.PostRepository.GetAll()
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
                var post = _uow.PostRepository.GetEntityById(id.Value);
                if (post != null)
                {
                    return View(post);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: PostManageController/Create
        [Authorize(Roles = ("Admin, Blog Owner, Contributor"))]
        public ActionResult Create()
        {
            var cate = _uow.CategoryRepository.GetAll();
            var list = new List<SelectListItem>();
            foreach (var item in cate)
            {
                list.Add(new SelectListItem() { Value = item.CategoryId.ToString(), Text = item.Name });
            }
            ViewData["categories"] = list;
        
            return View();
        }

        // POST: PostManageController/Create
        [Authorize(Roles = ("Admin, Blog Owner, Contributor"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post posts)
        {
            posts.UrlSlug = SeoUrlHepler.ToUrlSlug(posts.Title);
            posts.PostedOn = DateTime.Now;
            posts.Modified = DateTime.Now;

            _uow.PostRepository.Add(posts);
            _uow.SaveChange();
            return RedirectToAction("Index");
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

        // POST: PostManageController/Edit/5
        [Authorize(Roles = ("Admin, Blog Owner, Contributor"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post posts)
        {
            posts.UrlSlug = SeoUrlHepler.ToUrlSlug(posts.Title);
            posts.PostedOn = DateTime.Now;
            posts.Modified = DateTime.Now;
            _uow.PostRepository.Update(posts);
            _uow.SaveChange();
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
    }
}
