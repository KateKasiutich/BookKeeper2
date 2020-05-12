using BusinessLayer.Interfaces;
using DBLayer;
using DBLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessLayer.Implementations
{
    public class EFContentImplementation : IContentRepository
    {
        private EFDBContext context;
        public void EFContentRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Content> GetAllBooks(bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Content>().Include(x => x.Directory).AsNoTracking().ToList();
            else
                return context.Books.ToList();
        }

        public Content GetBookById(int bookId, bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Content>().Include(x => x.Directory).AsNoTracking().FirstOrDefault(x => x.Id == bookId);
            else
                return context.Books.FirstOrDefault(x => x.Id == bookId);
        }

        public void SaveBook(Content book)
        {
            if (book.Id == 0)
                context.Books.Add(book);
            else
                context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteBook(Content book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
        }
    }
}
