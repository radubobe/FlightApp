using System;
using 


namespace Repository
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T:class 
    { protected RepositoryContext RepositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        { this.RepositoryContext = repositoryContext; }
    }
}
