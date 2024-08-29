import { Link } from "react-router-dom";
import BookOperationsCard from "../../Components/OperationsCards/BookOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext";
import { toast } from "react-toastify";
import { useFetch } from "../../Context/FetchContext";
import DefaultTableTemplate from "../../Components/DefaultTableTemplate";


function BorrowedBooksOP() {

    const { user } = useUser();
    const [books, setBooks] = useState([]);
    const { fetchData } = useFetch();

    const fetchBorrowedBooks = async function () {
        const data = await fetchData("/api/Book/BorrowedBooks?userId=" + user.id, "GET");
        setBooks(data ?? []);
    }

    useEffect(() => {
        fetchBorrowedBooks();
    }, []);

    const handleReturnClick = async (book) => {
        const data = fetchData("/api/Book/ReturnBook", "PUT", book.id);
        fetchBorrowedBooks();
    }

    const headersArray = ["Title", "Authors", "Publish Date", "Borrowed Date", "Return Date", "Actions"];
    const datasArray = books.map(b => [
        b.bookDTO.title,
        b.bookDTO.authors.join(", "),
        new Date(b.bookDTO.publishDate).toLocaleDateString("en-us"),
        new Date(b.borrowDate).toLocaleDateString("en-us"),
        new Date(b.returnDate).toLocaleDateString("en-us"),
        (<ul className="flex justify-start">
            <li className="me-2"><Link to={`/ReadBook?bookId=` + b.bookDTO.id} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Read</Link></li>
            <li className="me-2"><Link onClick={() => { handleReturnClick(b.bookDTO) }} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Return</Link></li>
        </ul>),
    ]);


    const rightPanel = (
        <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
    )

    return (<GeneralOperationsPage leftPanel={(<BookOperationsCard />)} rightPanel={rightPanel} />)
}

export default BorrowedBooksOP