using System.Data.Entity;

namespace DAL
{
    public class BillboardContext : DbContext
    {
        public DbSet<DBBillboard> BillboardInf { get; set; }
    }
}
