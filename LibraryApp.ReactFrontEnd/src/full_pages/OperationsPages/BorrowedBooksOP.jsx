import { Link } from "react-router-dom";
import BookOperationsCard from "../../Components/OperationsCards/BookOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext";
import { toast } from "react-toastify";


function BorrowedBooksOP() {

    const { user } = useUser();
    const [books, setBooks] = useState([]);

    const getBorrowedBooks = async function () {
        var response = await fetch("http://localhost:5109/api/Book/BorrowedBooks?userId=" + user.id, {
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }
        });
        var books = await response.json();
        console.log(books);
        setBooks(books);
    }

    useEffect(() => {
        getBorrowedBooks();
    }, []);

    async function handleReturnClick(book) {
        console.log(book.id);
        const res = await fetch("http://localhost:5109/api/Book/ReturnBook", {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}`
            },
            body: JSON.stringify(book.id),
        });

        const data = await res.json();
        if (!res.ok) return;
        toast.success(data.message);
        getBorrowedBooks();
    }

    const rightPanel = (
        <div class="grow overflow-x-auto bg-gray-800 border border-gray-300">
            <table class="w-full text-sm text-left rtl:text-right text-gray-400">
                <thead class="text-xs uppercase bg-gray-700 text-gray-400">
                    <tr>
                        <th className="px-6 py-3">Title</th>
                        <th className="px-6 py-3">Authors</th>
                        <th className="px-6 py-3">Publish Date</th>
                        <th className="px-6 py-3">Borrowed Date</th>
                        <th className="px-6 py-3">Return Date</th>
                        <th className="px-6 py-3">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {books.map((b, index) => (
                        <tr key={index} className="border-b bg-gray-800 border-gray-700">
                            <td className="px-6 py-4 font-medium whitespace-nowrap text-white">{b.bookDTO.title}</td>
                            <td className="px-6 py-4">{b.bookDTO.authors.join(", ")}</td>
                            <td className="px-6 py-4">{new Date(b.bookDTO.publishDate).toLocaleDateString("en-us")}</td>
                            <td className="px-6 py-4">{new Date(b.borrowDate).toLocaleDateString("en-us")}</td>
                            <td className="px-6 py-4">{new Date(b.returnDate).toLocaleDateString("en-us")}</td>
                            <td className="px-6 py-4">
                                <ul className="flex justify-start">
                                    <li className="me-2"><Link to={`/ReadBook?bookId=` + b.bookDTO.id} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-300 text-gray-300 active:bg-green-950">Read</Link></li>
                                    <li className="me-2"><Link onClick={() => { handleReturnClick(b.bookDTO) }} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-300 text-gray-300 active:bg-green-950">Return</Link></li>
                                </ul>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table >
        </div>
    )

    return (<GeneralOperationsPage leftPanel={(<BookOperationsCard />)} rightPanel={rightPanel} />)
}

export default BorrowedBooksOP