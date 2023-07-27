
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TechBlog.Core.Common;
using TechBlog.Core.Models;
using TechBlog.Core.Repository.UnitOfWork;

namespace TechBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Tag/{action}")]
    [Authorize(Roles = "Admin, Blog Owner, Contributor")]
    public class TagController : Controller
    {
        private readonly IUnitOfWork _uow;
        public TagController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: TagController
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var tags = _uow.TagRepository.GetAll()
                                .OrderByDescending(p => p.TagId)
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            // Pass the records and page information to the view
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = _uow.CategoryRepository.GetAll().Count();
            return View(tags);
        }

        // GET: TagController/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var tag = _uow.TagRepository.GetEntityById(id.Value);
                if (tag != null)
                {
                    return View(tag);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: TagController/Create
        [Authorize(Roles = "Admin, Blog Owner, Contributor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [Authorize(Roles = "Admin, Blog Owner, Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag tags)
        {
            tags.UrlSlug = SeoUrlHepler.ToUrlSlug(tags.Name);

            _uow.TagRepository.Add(tags);
            _uow.SaveChange();

            return RedirectToAction("Index", "Tag");
        }

        // GET: TagController/Edit/5
        [Authorize(Roles = "Admin, Blog Owner, Contributor")]
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Tag tags = _uow.TagRepository.GetEntityById(id.Value);

            if (tags == null)
            {
                return NotFound();
            }

            return View(tags);
        }

        // POST: TagController/Edit/5
        [Authorize(Roles = "Admin, Blog Owner, Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tag tags)
        {
            tags.UrlSlug = SeoUrlHepler.ToUrlSlug(tags.Name);
            _uow.TagRepository.Update(tags);
            _uow.SaveChange();

            return RedirectToAction("Index", "Tag");
        }

        // GET: TagController/Delete/5
        [Authorize(Roles = "Admin, Blog Owner")]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                _uow.CategoryRepository.Delete(id.Value);
                _uow.SaveChange();
            }
            return RedirectToAction("Index", "Category");
        }

        public IActionResult SearchTag(string? searchTerm)
        {

            var tags = _uow.TagRepository.GetTagByName(searchTerm);
            ViewBag.SearchTerm = searchTerm;
            if (!tags.Any())
            {
                ViewBag.Message = "Không tim thấy \"" + searchTerm + "\".";
            }
            return View(tags);
        }
    }
}
