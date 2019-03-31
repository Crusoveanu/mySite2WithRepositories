using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mySite2.Data.Interfaces;
using mySite2.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mySite2.Controllers
{
    public class LendController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public LendController(IBookRepository bookRepostiroy, ICustomerRepository customerRepoistory)
        {
            _bookRepository = bookRepostiroy;
            _customerRepository = customerRepoistory;
        }
        [Route("Lend")]
        public IActionResult List()
        {
            //load all available books
            var availableBooks = _bookRepository.FindWithAutor(x => x.BorrowerId == 0);

            if (availableBooks.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(availableBooks);
            }
        }

        public IActionResult LendBook(int bookId)
        {
            var lendVM = new LendViewModel()
            {
                Book = _bookRepository.GetById(bookId),
                Customers = _customerRepository.GetAll()
            };

            return View(lendVM);
        }

        [HttpPost]
        public IActionResult LendBook(LendViewModel lendViewModel)
        {
            var book = _bookRepository.GetById(lendViewModel.Book.BookId);
            var customer = _customerRepository.GetById(lendViewModel.Book.BorrowerId);
            book.Borrower = customer;
            _bookRepository.Update(book);
            return RedirectToAction("List");
        }
    }
}
