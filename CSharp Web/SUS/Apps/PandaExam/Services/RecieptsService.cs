namespace PandaExam.Services
{
    using PandaExam.Data;
    using System;
    using System.Linq;

    public class RecieptsService : IRecieptsService
    {
        private readonly ApplicationDbContext db;

        public RecieptsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateFromPackage(decimal weight, string packageId, string recipientId)
        {
            var reciept = new Receipt
            {
                PackageId = packageId,
                RecipientId = recipientId,
                Fee = weight * 2.67M,
                IssuedOn = DateTime.UtcNow,
            };

            this.db.Receipts.Add(reciept);
            this.db.SaveChanges();
        }

        public IQueryable<Receipt> GetAll()
        {
            return this.db.Receipts.AsQueryable();
        }
    }
}
