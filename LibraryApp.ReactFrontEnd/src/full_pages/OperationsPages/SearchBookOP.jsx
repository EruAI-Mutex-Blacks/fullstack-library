import { useLocation, Link } from "react-router-dom";
import BookOperationsCard from "../../Components/OperationsCards/BookOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext"
import { toast } from "react-toastify";
import { useFetch } from "../../Context/FetchContext";

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

    //FIXME cannot send multiple borrow requests

    useEffect(() => {
        onSearch(bookName);
    }, [])

    const handleBorrowClick = async (book) => {
        const bookDTO = { userId: user.id, bookId: book.id }
        const data = await fetchData("/api/Book/BorrowBook", "POST", bookDTO);
    }

    const rightPanel = (
        <div class="grow overflow-x-auto bg-gray-800 border border-gray-300">
            <table class="w-full text-sm text-left rtl:text-right text-gray-400">
                <thead class="text-xs uppercase bg-gray-700 text-gray-400">
                    <tr>
                        <th className="px-6 py-4">Title</th>
                        <th className="px-6 py-4">Publish Date</th>
                        <th className="px-6 py-4">Is Borrowed</th>
                        <th className="px-6 py-4">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {books.map((b, index) => (
                        <tr key={index} className="border-b bg-gray-800 border-gray-700">
                            <td className="px-6 py-4 font-medium whitespace-nowrap text-white">{b.title}</td>
                            <td className="px-6 py-4">{new Date(b.publishDate).toLocaleDateString("en-us")}</td>
                            <td className="px-6 py-4">{b.isBorrowed ? "Yes" : "No"}</td>
                            <td className="px-6 py-4">
                                <ul className="flex justify-start">
                                    <li className="me-2">
                                        <Link to={`/ReadBook?bookId=` + b.id} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Preview the book</Link>
                                    </li>
                                    <li className="me-2">
                                        <button onClick={() => { handleBorrowClick(b) }} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 disabled:bg-green-800/40 disabled:border-none active:bg-green-950" disabled={b.isBorrowed}>Borrow</button>
                                    </li>
                                </ul>
                            </td>
                        </tr>
                    ))
                    }
                </tbody>
            </table >
        </div>
    )

    return (<GeneralOperationsPage leftPanel={(<BookOperationsCard onSearch={onSearch} />)} rightPanel={rightPanel} />)
}

export default SearchBookOP