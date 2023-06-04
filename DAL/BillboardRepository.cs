using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BillboardRepository : IRepository<DBBillboard>
    {
        private BillboardContext db;

        public BillboardRepository(BillboardContext context) { db = context; }

        public void Create(DBBillboard item)
        {
            db.BillboardInf.Add(item);
        }

        public void Delete(int id)
        {
            DBBillboard billboard = db.BillboardInf.Find(id);
            if (billboard != null) db.BillboardInf.Remove(billboard);
        }

        public DBBillboard Get(int id)
        {
            return db.BillboardInf.Find(id);
        }

        public IEnumerable<DBBillboard> GetAll()
        {
            return db.BillboardInf;
        }

        public void Update(DBBillboard item)
        {
           // db.Entry(item).State = EntityState.Modified;
        }
    }
}
