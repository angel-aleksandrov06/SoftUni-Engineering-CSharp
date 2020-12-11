using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public void Update(Category category)
        {
            var objFromDb = this.db.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = category.Name;

                this.db.SaveChanges();
            }
        }
    }
}
