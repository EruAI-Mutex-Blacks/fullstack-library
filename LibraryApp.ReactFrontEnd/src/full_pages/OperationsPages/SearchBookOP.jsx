import { useLocation, Link } from "react-router-dom";
import BookOperationsCard from "../../Components/OperationsCards/BookOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext"
import { toast } from "react-toastify";
import { useFetch } from "../../Context/FetchContext";
import DefaultTableTemplate from "../../Components/DefaultTableTemplate";

function SearchBookOP() {
    const [books, setBooks] = useState([]);
    const location = useLocation();
    const bookName = new URLSearchParams(location.search).get("book");
    const { user } = useUser();
    const { fetchData } = useFetch();

    const onSearch = async function (bookQuery) {
        const data = await fetchData("/api/Book/SearchBook?bookName=" + encodeURIComponent(bookQuery), "GET");
        setBooks(data ?? []);
    };

    useEffect(() => {
        onSearch(bookName);
    }, [])

    const handleBorrowClick = async (book) => {
        const bookDTO = { userId: user.id, bookId: book.id }
        const data = await fetchData("/api/Book/BorrowBook", "POST", bookDTO);
    }

    const headersArray = ["Title", "Publish date", "Is Borrowed", "Actions"];
    const datasArray = books.map(b => [
        b.title,
        new Date(b.publishDate).toLocaleDateString("en-us"),
        b.isBorrowed ? "Yes" : "No",
        (<ul className="flex justify-start">
            <li className="me-2">
                <Link to={`/ReadBook?bookId=` + b.id} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Preview the book</Link>
            </li>
            <li className="me-2">
                <button onClick={() => { handleBorrowClick(b) }} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 disabled:bg-green-800/40 disabled:border-none active:bg-green-950" disabled={b.isBorrowed}>Borrow</button>
            </li>
        </ul>)
    ]);

    const rightPanel = (
        <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
    )

    return (<GeneralOperationsPage leftPanel={(<BookOperationsCard onSearch={onSearch} />)} rightPanel={rightPanel} />)
}

export default SearchBookOP