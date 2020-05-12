using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBLayer
{
    public class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if(!context.Directory.Any())
            {
                context.Directory.Add(new Entityes.Directory() {Title = "First Direcroty", Html="<b>Directory Content/<b>" });
                context.Directory.Add(new Entityes.Directory() {Title = "Second Direcroty", Html="<b>Directory Content/<b>" });
                context.Directory.Add(new Entityes.Directory() { Title = "Third Direcroty", Html = "<b>Directory Content/<b>" });
                context.SaveChanges();

                context.Books.Add(new Entityes.Content() { Title = "1984", Html = "<i>Book Description/<i>", DirectoryId = context.Directory.First().Id });
                context.SaveChanges();
            }
        }
    }
}
