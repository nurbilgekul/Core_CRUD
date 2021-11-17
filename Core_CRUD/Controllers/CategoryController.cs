using Core_CRUD.Infrastructure.Repositories.Interface;
using Core_CRUD.Models.DTOs;
using Core_CRUD.Models.Entities.Abstract;
using Core_CRUD.Models.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IBaseRepository<Category> _repo;

        public CategoryController(IBaseRepository<Category> repo)
        {
            this._repo = repo;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.Description = model.Description;
                _repo.Add(category);
                return View();
            }
            else return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            return View (_repo.Get(x => x.Status != Status.Passive));
        }

        public IActionResult Delete(Category item)
        {
            Category category = _repo.FirstByDefault(x => x.Id == item.Id);
            _repo.Delete(category);
            return RedirectToAction("List");

        }

        public IActionResult Update(int id)
        {
            Category category = _repo.FirstByDefault(x => x.Id == id);
            UpdateCategoryDTO model = new UpdateCategoryDTO();
            model.Name = category.Name;
            model.Description = category.Description;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = _repo.FirstByDefault(x => x.Id == model.Id);
                category.Name = model.Name;
                category.Description = model.Description;
                _repo.Update(category);
                return RedirectToAction("List");
            }
            else
                return View(model);
        }

    }
}
