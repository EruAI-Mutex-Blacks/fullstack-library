import { Link } from "react-router-dom";
import { useUser } from "../AccountOperations/UserContext";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";

function MyBooksOP() {

    const { user } = useUser();
    const [myBooks, setMyBooks] = useState([]);

    const fetchBooks = async function () {
        const res = await fetch("http://localhost:5109/api/Book/GetBooksByAuthor?userId=" + user.id, {
            method: "GET",
        });


        if (!res.ok) {
            const ressss = await res.json();
            console.log(ressss);
            return;
        }

        var myBooks = await res.json();
        setMyBooks(myBooks);
        console.log(myBooks);
    }

    useEffect(() => {
        fetchBooks();
    }, []);

    const handleRequestClick = async function (bookId) {
        const res = await fetch("http://localhost:5109/api/Book/RequestPublishment", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(bookId)
        });

        if (!res.ok) {
            const data = await res.json();
            console.log(data);
            toast.error(data || "An error occured");
            return;
        }
        toast.success("Request has sent");
    }

    return (
        <div className="container ">
            <h1 className="row border-bottom border-dark py-4">My Books</h1>
            <div className="row py-2">
                <table className="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>Book Name</th>
                            <th>Status</th>
                            <th>Publish Date</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {myBooks.map((mb, index) => (
                            <tr>
                                <td>{mb.bookName}</td>
                                <td>{mb.status}</td>
                                <td>{new Date(mb.publishDate).toLocaleDateString("en-us")}</td>
                                <td className="">
                                    <Link className="btn btn-success me-2" to={"/ReadBook?bookId=" + mb.bookId}>Read</Link>
                                    <Link className={`btn btn-success me-2 ${mb.status === "Published" ? "disabled" : ""}`} to={"/WriteBook?bookId=" + mb.bookId}>Write</Link>
                                    <button className="btn btn-success me-2" disabled={mb.status === "Published"} onClick={e => handleRequestClick(mb.bookId)}>Request publishment</button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    )
}

export default MyBooksOP;

//TODO create book to db then as writing add pages into that
//TODO if book is published cannot requesst publishment and cannot write. and no more than 1 request
//TODO book writing page with content and page number inputs
//TODO importing a txt file into same page's content field
//TODO profile page?
//TODO authorization at backend too
//TODO JWT
//TODO book returning