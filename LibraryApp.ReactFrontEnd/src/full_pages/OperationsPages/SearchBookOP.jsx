import { useLocation, Link } from "react-router-dom";
import BookOperationsCard from "../../Components/OperationsCards/BookOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";

//TODO en son güvenlik modu kapatılabilir 2 kere çağrılıyor sayfalar
function SearchBookOP() {
    const [books, setBooks] = useState([]);
    const location = useLocation();
    const bookName = new URLSearchParams(location.search).get("book");

    const onSearch = async function (bookQuery) {
        try {
            const response = await fetch("http://localhost:5109/api/Book/SearchBook?bookName=" + encodeURIComponent(bookQuery), {
                method: "GET",
            });

            if (!response.ok) return;

            const bookDTOS = await response.json();
            console.log(bookDTOS);
            setBooks(bookDTOS);

        } catch (error) {
            console.log("there was an error in fetching", error);
        }
    };

    useEffect(() => {
        onSearch(bookName);
    }, [])

    function handleBorrowClick(book) {

    }

    const rightPanel = (
        <table className="table table-light table-striped table-hover flex-fill">
            <thead>
                <tr>
                    <th>Cover</th>
                    <th>Title</th>
                    <th>Publish Date</th>
                    <th>Is Borrowed</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {books.map(b => (
                    <tr>
                        <td>{b.Cover}</td>
                        <td>{b.title}</td>
                        <td>{b.publishDate}</td>
                        <td>{b.isBorrowed ? "Yes" : "No"}</td>
                        <td>
                            <ul className="list-inline d-flex justify-content-start">
                                {/* TODO find a way to make it readable for only first 3 pages of the book without creating extra page. maybe send another parameter*/}
                                <li className="me-2"><Link to={`/ReadBook?bookId=` + b.id} className={`py-1 px-2 btn btn-danger`}>Preview the book</Link></li>
                                <li className="me-2"><Link onClick={() => { handleBorrowClick(b) }} className={`py-1 px-2 btn btn-success ${b.isBorrowed ? "disabled" : ""}`}>Borrow</Link></li>
                            </ul>
                        </td>
                    </tr>
                ))
                }
            </tbody>
        </table >
    )

    return (<GeneralOperationsPage leftPanel={(<BookOperationsCard onSearch={onSearch} />)} rightPanel={rightPanel} />)
}

export default SearchBookOP