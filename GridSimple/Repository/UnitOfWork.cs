using GridSimple.Model;
using GridSimple.Repository.Base;
using System;

namespace GridSample.Repository.Base
{
    public class UnitOfWork: IDisposable
    {
        private SimpleGridDBEntities context = new SimpleGridDBEntities();

        private IGenericRepository<Person> personRepository;
        public IGenericRepository<Person> PersonRepository
        {
            get
            {
                if (this.personRepository == null)
                {
                    this.personRepository = new GenericRepository<Person>(context);
                }
                return personRepository;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
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