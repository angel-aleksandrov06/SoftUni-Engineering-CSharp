using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public UpsertModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            this.Book = new Book();
            if (id == null)
            {
                // create
                return Page();
            }

            // update
            this.Book = await this.db.Book.FirstOrDefaultAsync(x => x.Id == id);
            if (this.Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (this.Book.Id == 0)
                {
                    this.db.Book.Add(this.Book);
                }
                else
                {
                    this.db.Book.Update(this.Book);
                }

                await this.db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
