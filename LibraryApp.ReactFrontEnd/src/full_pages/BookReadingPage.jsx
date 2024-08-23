import { useEffect, useState } from "react";
import { Link, useLocation } from "react-router-dom";
import { useUser } from "../AccountOperations/UserContext";

function BookReadingPage() {

    const [book, setBook] = useState({});
    const location = useLocation();
    const bookId = new URLSearchParams(location.search).get("bookId");
    const [pageNum, setPageNum] = useState();
    const [pageContent, setPageContent] = useState("");
    const { user } = useUser();

    const getBook = async function () {
        const res = await fetch("http://localhost:5109/api/Book/GetBook?bookId=" + bookId, {
            method: "GET"
        });
        if (!res.ok) return;
        const book = await res.json();
        book.pages = book.borrowedById == user.id ? book.pages : book.pages.slice(0, 3);
        book.title = book.borrowedById == user.id ? book.title : book.title + " [Preview]";
        setBook(book);
    }

    useEffect(() => {
        getBook();
    }, []);

    const handlePageClick = function (p) {
        setPageContent(p.content);
        setPageNum(p.pageNumber);
    }

    return (
        <div className="d-flex flex-column flex-fill align-items-center">
            <h2 className="mb-0 mt-4 p-0">{book.title}</h2>
            <div className="container mb-5 mt-4 p-2 bg-light rounded d-flex text-center flex-fill">
                <div className="col-9 pe-2">
                    <div className="d-flex justify-content-center bg-success-subtle border-bottom border-dark px-3 pt-3 rounded mb-2">
                        <h5>Page {pageNum}</h5>
                    </div>
                    <div className="p-3 bg-success-subtle rounded">
                        <p>{pageContent}</p>
                    </div>
                </div>
                <div className="col-3 ps-2">
                    <div className="d-flex justify-content-center bg-success-subtle border-bottom border-dark px-3 pt-3 pb-0 rounded mb-2">
                        <h4>Pages</h4>
                    </div>
                    <div className="d-flex justify-content-center flex-wrap p-3 bg-success-subtle rounded">
                        {book?.pages?.map((p, index) => (
                            <button key={index} className="btn btn-success me-2 mb-2" onClick={() => handlePageClick(p)}>{p.pageNumber}</button>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    );
}

export default BookReadingPage;