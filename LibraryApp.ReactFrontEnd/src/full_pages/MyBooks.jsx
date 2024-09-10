import { Link } from "react-router-dom";
import { useUser } from "../AccountOperations/UserContext";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useFetch } from "../Context/FetchContext";
import DefaultTableTemplate from "../Components/DefaultTableTemplate";
import SuccessButton from "../Components/SuccessButton";
import DefaultLink from "../Components/DefaultLink";

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
    const datasArray = myBooks.map((mb,index) => [
        mb.oldBookName,
        mb.status,
        new Date(mb.publishDate).toLocaleDateString("en-us"),
        (<div key={index} className="gap-2 flex-wrap flex w-full">
            {(mb.status !== "Published") && <>
                <div className="flex mb-2 w-full">
                    <input type="text" className="px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded-s" placeholder="Enter new name" onChange={(e) => handleTitleChange(mb, e)} />
                    <SuccessButton callback={() => handleChangeClick(mb)} text={"Change"} />
                </div>
                <DefaultLink url={"/WriteBook?bookId=" + mb.bookId} text={"Write"} />
                <SuccessButton callback={e => handleRequestClick(mb.bookId)} text={"Request publishment"} />
            </>}
            <DefaultLink url={"/ReadBook?bookId=" + mb.bookId} text={"Read"} />
        </div>),
    ]);


    return (
        <div className="container lg:px-16 mx-auto grow w-full flex flex-col text-text">
            <div className="flex flex-row justify-between px-1 pt-4 pb-2 border-text items-end">
                <h1 className="text-3xl ms-2">My Books</h1>
                <SuccessButton callback={handleCreateClick} text={"Create a book"} />
            </div>
            <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
        </div>
    )
}

export default MyBooksOP;