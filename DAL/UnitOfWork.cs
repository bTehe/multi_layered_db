using System;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        private BillboardContext db = new BillboardContext();
        private BillboardRepository billboardRepository;
        private bool _disposed = false;
        
        public BillboardRepository Billboards
        {
            get
            {
                if (billboardRepository == null) billboardRepository = new BillboardRepository(db);
                return billboardRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool displosing)
        {
            if (!_disposed) db.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
