using BookKeeper_2.Dal.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookKeeper_2.Dal.Impl.Repositories
{
    public class GenericReposiotry<TKey,Tentity> : IGenericRepository<TKey,Tentity> where Tentity : class
    {
    }
}
