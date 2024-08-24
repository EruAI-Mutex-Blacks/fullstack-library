using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;


namespace LibraryApp.Data.Abstract
{
    public interface IBookService
    {
        void writeBook(string title, string authorName, string content);
        void uploadBook(string title, string authorName, Stream pdfStream);
    }
}
