using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridSimple.Services.Base
{
    public class BaseService:IDisposable
    {
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ;//
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}