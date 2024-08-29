import { useEffect, useState } from "react";
import { Link, useLocation } from "react-router-dom";
import { useUser } from "../AccountOperations/UserContext";
import { useFetch } from "../Context/FetchContext";

function BookReadingPage() {

    const [book, setBook] = useState({});
    const location = useLocation();
    const bookId = new URLSearchParams(location.search).get("bookId");
    const [pageNum, setPageNum] = useState();
    const [pageContent, setPageContent] = useState("");
    const { user } = useUser();
    const { fetchData } = useFetch();

    const fetchBook = async function () {
        fetchData("/api/Book/GetBook?bookId=" + bookId, "GET")
            .then((book) => {
                book.pages.sort((a, b) => a.pageNumber - b.pageNumber);

                const isMemberOrAuthor = ["member", "author"].includes(user.roleName);
                const isBorrowedByUser = book.borrowedById == user.id;
                const isWrittenByUser = book.authorIds?.includes(user.id);

                book.pages = !isMemberOrAuthor || isBorrowedByUser || isWrittenByUser ? book.pages : book.pages.slice(0, 3);
                book.title = !isMemberOrAuthor || isBorrowedByUser || isWrittenByUser ? book.title : book.title + " [Preview]";
                setBook(book);
                setPageContent(book.pages[0].content);
                setPageNum(book.pages[0].pageNumber);
            });
    }

    useEffect(() => {
        fetchBook();
    }, []);

    const handlePageClick = function (p) {
        setPageContent(p.content);
        setPageNum(p.pageNumber);
    }

    return (
        <div className=" lg:px-16 xl:px-16 flex flex-col grow items-center space-y-4 text-gray-200">
            <h2 className="mb-0 mt-4 p-0 text-3xl">{book.title}</h2>
            <div className="container space-x-2 mb-5 mt-4 p-2 bg-gray-500 rounded flex text-center grow">
                <div className="w-5/6">
                    <div className="flex justify-center text-xl bg-gray-600 border-b border-gray-300 px-3 pt-3 pb-1 rounded mb-2">
                        <h5>Page {pageNum}</h5>
                    </div>
                    <div className="p-3 bg-gray-600 rounded">
                        <p>{pageContent}</p>
                    </div>
                </div>
                <div className="w-1/6">
                    <div className="flex justify-center bg-gray-600 border-b border-gray-300 px-3 pt-3 pb-2 rounded mb-2">
                        <h4>Pages</h4>
                    </div>
                    <div className="flex items-center justify-center ps-6 p-3 flex-wrap bg-gray-600 rounded">
                        {book?.pages?.map((p, index) => (
                            <button key={index} className="border border-transparent rounded px-3 py-1 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 active:bg-green-900 me-2 mb-2" onClick={() => handlePageClick(p)}>{p.pageNumber}</button>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    );
}

export default BookReadingPage;