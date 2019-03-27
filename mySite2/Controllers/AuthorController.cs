using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mySite2.Data.Interfaces;
using mySite2.Data.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mySite2.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [Route("Author")]
        public IActionResult List()
        {
            var authors = _authorRepository.GetAllWithBooks();

            if(authors.Count() == 0)
            {
                return RedirectToAction("Empty");
            }

            return View(authors);
        }

        public IActionResult Update(int id)
        {
            var authors = _authorRepository.GetById(id);

            if (authors == null) return NotFound();

            return View(authors);
        }
        [HttpPost]
        public IActionResult Update(Author authors)
        {
            _authorRepository.Update(authors);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author authors)
        {
            _authorRepository.Create(authors);

            return RedirectToAction("List");
        }

        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var authors = _authorRepository.GetById(id);
            _authorRepository.Delete(authors);

            return RedirectToAction("List");
        }
    }
}
