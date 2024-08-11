import { useLocation, Link } from "react-router-dom";
import BookOperationsCard from "../../Components/OperationsCards/BookOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"


function SearchBookOP() {
    const location = useLocation();
    const bookQuery = new URLSearchParams(location.search).get('book');

    const seedBook = {
        id: 1,
        title: "Book 1",
        publishDate: `${new Date().getDate()}-${new Date().getUTCMonth()}-${new Date().getFullYear()}`,
        isBorrowed: false
    }

    //TODO need reading page for books

    const seedBooks = [];
    seedBooks.push(seedBook);
    seedBooks.push(seedBook);
    seedBooks.push(seedBook);
    seedBooks.push(seedBook);
    seedBooks.push(seedBook);
    seedBooks.push(seedBook);

    function handleBorrowClick(book) {
        if (book.isBorrowed) {
            window.alert("already borrowed");
        }
        else {
            window.alert("can be borrowed");
        }
    }
    
    const rightPanel = (
        <table className="table table-light table-striped table-hover flex-fill">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Title</th>
                    <th>Publish Date</th>
                    <th>Is Borrowed</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {seedBooks.map(b => (
                    <tr>
                        <td>{b.id}</td>
                        <td>{b.title}</td>
                        <td>{b.publishDate}</td>
                        <td>{b.isBorrowed ? "Yes" : "No"}</td>
                        <td>
                            <ul className="list-inline d-flex justify-content-start">
                                <li className="me-2"><Link onClick={() => { handleBorrowClick(b) }} className={`py-1 px-2 btn btn-success ${b.isBorrowed ? "disabled" : ""}`}>Borrow</Link></li>
                            </ul>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table >
    )

    return (<GeneralOperationsPage leftPanel={(<BookOperationsCard />)} rightPanel={rightPanel} />)
}

export default SearchBookOP