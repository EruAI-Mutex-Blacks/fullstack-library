import { Link } from "react-router-dom";
import { useUser } from "../AccountOperations/UserContext";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useFetch } from "../Context/FetchContext";
import DefaultTableTemplate from "../Components/DefaultTableTemplate";

function MyBooksOP() {

    const { user } = useUser();
    const [myBooks, setMyBooks] = useState([]);
    const { fetchData } = useFetch();

    const fetchBooks = async function () {
        const data = await fetchData("/api/Book/GetBooksByAuthor?userId=" + user.id, "GET");

        var newMyBooks = data?.map(mb => ({
            bookId: mb.bookId,
            oldBookName: mb.bookName,
            newBookName: mb.bookName,
            publishDate: mb.publishDate,
            status: mb.status,
        }));
        setMyBooks(newMyBooks ?? []);
    }

    useEffect(() => {
        fetchBooks();
    }, []);

    const handleRequestClick = async function (bookId) {
        fetchData("/api/Book/RequestPublishment", "POST", bookId)
            .then(() => {
                fetchBooks();
            });
    }

    const handleCreateClick = async function () {
        fetchData("/api/Book/CreateBook", "POST", user.id)
            .then(() => {
                fetchBooks();
            });
    }

    const handleChangeClick = async function (book) {
        if (book.oldBookName === book.newBookName) {
            toast.error("You did not changed the name");
            return;
        }

        const bookDTO = {
            bookId: book.bookId,
            bookName: book.newBookName,
            publishDate: book.publishDate,
            status: book.status,
        }

        fetchData("/api/Book/UpdateBookName", "PUT", bookDTO)
            .then(() => {
                fetchBooks();
            });
    }

    const handleTitleChange = function (book, e) {
        book.newBookName = e.target.value;
    }

    //TODO logged out navbar küçülüyor pysi veya mysi

    const headersArray = ["Book name", "Status", "Publish date", "Actions"];
    const datasArray = myBooks.map(mb => [
        mb.oldBookName,
        mb.status,
        new Date(mb.publishDate).toLocaleDateString("en-us"),
        (<>
            {(mb.status !== "Published") && <>
                <div className="flex mb-2">
                    <input type="text" className="px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" placeholder="Enter new name" onChange={(e) => handleTitleChange(mb, e)} />
                    <button className="border border-transparent inline-block rounded-e px-4 py-2 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900 me-2" onClick={() => handleChangeClick(mb)}>Change</button>
                </div>
                <Link className="border border-transparent inline-block rounded px-4 py-2 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900 me-2 mb-2" to={"/WriteBook?bookId=" + mb.bookId}>Write</Link>
                <button className="border border-transparent inline-block rounded px-4 py-2 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900 me-2 mb-2" onClick={e => handleRequestClick(mb.bookId)}>Request publishment</button>
            </>}
            <Link className="border border-transparent inline-block rounded px-4 py-2 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900 me-2 mb-2" to={"/ReadBook?bookId=" + mb.bookId}>Read</Link>
        </>),
    ]);


    return (
        <div className="container lg:px-16 mx-auto grow w-full flex flex-col text-white">
            <div className="flex flex-row justify-between px-1 pt-4 pb-2 border-gray-300 items-end">
                <h1 className="text-3xl ms-2">My Books</h1>
                <button onClick={handleCreateClick} className="border border-transparent inline-block rounded px-4 py-2 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900">Create a book</button>
            </div>
            <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
        </div>
    )
}

export default MyBooksOP;