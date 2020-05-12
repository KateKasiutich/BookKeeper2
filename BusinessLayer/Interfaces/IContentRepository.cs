using DBLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

//TODO: Move in DAL (DAO) 
//TODO: Controller -> inoke service -(Map DTO -> Entity)> invoke repository(ies) -> SQL 
//DAL(Impl,Abstract), BL(Impl,Abstract), DTO, Entity, Web proj
namespace BusinessLayer.Interfaces
{
    public interface IContentRepository
    {
        IEnumerable<Content> GetAllBooks(bool includeDirectory = false);
        Content GetBookById(int bookId, bool includeDirectory = false);
        void SaveBook(Content content);
        void DeleteBook(Content content);
    }
}
