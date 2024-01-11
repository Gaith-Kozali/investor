using Investor.Data;
using Investor.Models;
using Investor.Models.Investor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using static Azure.Core.HttpHeader;
using static System.Reflection.Metadata.BlobBuilder;

namespace Investor.Controllers
{
    public class InvestorController : Controller
    {

        public InvestorController(AppDbContext db) {
            _db = db;
        
        }

        private readonly AppDbContext _db;

        //Get
        public IActionResult Details()
        {
            // IEnumerable<Book> bookData = _db.book.ToList();
            createSelecteBook();
            return View();
        }
        void createSelecteBook(int selecteId = 1) {

            List<Book> books = _db.book.Where(q => q.CouponId == null).ToList();
           // SelectList listBook = new SelectList(books, "Id", "name",selecteId);
            ViewBag.bookList = books;

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(DetailsModel detailsModel)
        {
           

            if (ModelState.IsValid)
            {
                Coupon coupon = new Coupon
                {
                    code = detailsModel.code,
                    discount = detailsModel.discount,
                    timePeriodc = detailsModel.timePeriodc,
                };
                _db.coupon.Add(coupon);
                _db.SaveChanges();
               
                UpdateBooksCouponId(coupon.id, detailsModel.bookId);

                return RedirectToAction("ViewItems");
            }
            else
            {
                return View();
            }
        }

        private void UpdateBooksCouponId(int couponId, int bookId)
        {
            Book book = _db.book.FirstOrDefault(b => b.Id == bookId);
            

            if (book != null)
            {
                book.CouponId = couponId;
                _db.Update(book);
                _db.SaveChanges();
            }


            }

        public IActionResult ViewItems()
        {
            List<Book> booksItem = _db.book.Where(q => q.InvestoreAccountId == 1).Include(c => c.Coupon).ToList();

            return View(booksItem);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int bookId)
        {

            Book bookToDelete = _db.book.FirstOrDefault(q => q.Id == bookId);

            if (bookToDelete != null)
            {
                _db.book.Remove(bookToDelete);
                _db.SaveChanges();
            }

            return RedirectToAction("ViewItems");
        }

        // Get
        public IActionResult AddItem()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddItem(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.book.Add(book);
                _db.SaveChanges();
                return RedirectToAction("ViewItems");
            }
            else
            {
                return View(book);
            }
        }

        public IActionResult Setting()
        {
            return View();
        }

        public IActionResult ViewCoupon()
        {
           List<Coupon> coupon= _db.coupon.Include(c => c.book).ToList();
            return View(coupon);
        }

        // get
        public IActionResult EditCoupon(int ? id)
        {
            if (id == null || id == 0) { 
            
            return NotFound();
            
            }
            var item = _db.coupon.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return View(item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCoupon(Coupon coupon)
        {
            if (ModelState.IsValid)
            {

                _db.coupon.Update(coupon);
                _db.SaveChanges();

                return RedirectToAction("ViewItems");
            }
            else {
                return View();
            }

          
        }



        public IActionResult DeleteCoupon(int id)
        {
            Coupon coupon = _db.coupon.Include(c => c.book).FirstOrDefault(q => q.id == id);

            if (coupon != null)
            {
                // Delete associated books first
               // foreach (var book in coupon.book.ToList())
                //{
                  //  _db.book.Remove(book);
                //}

                _db.coupon.Remove(coupon);
                _db.SaveChanges();
            }

            return RedirectToAction("ViewItems");
        }

       
        // get 
        public IActionResult EditItem(int? id)
        {
            if (id == null || id == 0)
            {

                return NotFound();

            }
            var item = _db.book.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditItem(Book book)
        {
            if (ModelState.IsValid)
            {

                _db.book.Update(book);
                _db.SaveChanges();

                return RedirectToAction("ViewItems");
            }
            else
            {
                return View();
            }


        }





    }
}
