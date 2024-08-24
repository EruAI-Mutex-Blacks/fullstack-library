using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
namespace LibraryApp.Data.Concrete
{
    public class BookService 
    {
        private readonly LibraryDbContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly IBookAuthorRepository _bookAuthorRepository;

        public BookService(IBookRepository bookRepository, IBookAuthorRepository bookAuthorRepository)
        {
            _bookRepository = bookRepository;
            _bookAuthorRepository = bookAuthorRepository;
        }


        public void WriteBook(string title, string authorName, string content)
        {
            var author = new User { Name = authorName };
            var book = new Book { Title = title };

            var bookAuthor = new BookAuthor
            {
                User = author,
                Book = book
            };

            var pages = SplitContentIntoPages(content, 200);
            foreach (var pageContent in pages)
            {
                var page = new Page { Content = pageContent };
                book.Pages.Add(page);
            }

            _context.Books.Add(book);
            _context.BookAuthors.Add(bookAuthor);
            _context.SaveChanges();

            SendAdminNotification(book);
        }
        private List<string> SplitContentIntoPages(string content, int wordsPerPage)
        {
            var words = content.Split(' ');
            var pages = new List<string>();
            for (int i = 0; i < words.Length; i += wordsPerPage)
            {
                var pageContent = string.Join(" ", words.Skip(i).Take(wordsPerPage));
                pages.Add(pageContent);
            }
            return pages;
        }
        private void SendAdminNotification(Book book)
        {
            Console.WriteLine($"Sent to admin: {book.Title}");
        }
        public void uploadBook(string title, string authorName, Stream pdfStream)
        {
            var author = _bookAuthorRepository.BookAuthors
                .FirstOrDefault(a => a.User.Name == authorName)?.User;

            if (author == null)
            {
                author = new User { Name = authorName };
            }

            var book = new Book { Title = title };

            var pages = ExtractPagesFromPdf(pdfStream);
            foreach (var pageContent in pages)
            {
                var page = new Page { Content = pageContent };
                book.Pages.Add(page);
            }

            _bookRepository.CreateBook(book);
            _bookAuthorRepository.CreateBookAuthor(new BookAuthor { Book = book, User = author });

            SendAdminNotification(book);
        }

        public List<string> ExtractPagesFromPdf(Stream pdfStream)
        {
            var pages = new List<string>();

            using (var reader = new iText.Kernel.Pdf.PdfReader(pdfStream))
            using (var pdfDoc = new iText.Kernel.Pdf.PdfDocument(reader))
            {
                var pageCount = pdfDoc.GetNumberOfPages();
                for (int i = 1; i <= pageCount; i++)
                {
                    var page = pdfDoc.GetPage(i);
                    var strategy = new LocationTextExtractionStrategy();
                    var extractedText = PdfTextExtractor.GetTextFromPage(page, strategy);
                    pages.Add(extractedText);
                }
            }

            return pages;
        }

    }

}