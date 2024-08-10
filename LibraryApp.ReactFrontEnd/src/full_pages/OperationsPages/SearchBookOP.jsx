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
        <table className="table table-light table-striped table-hover">
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
                            <ul className="list-inline d-flex justify-content-around">
                                <li><Link onClick={() => {handleBorrowClick(b)}} className="btn btn-success">Borrow</Link></li>
                                <li><Link onClick={() => {handleBorrowClick(b)}} className="btn btn-success">Borrow</Link></li>
                            </ul>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    )

    return (<GeneralOperationsPage leftPanel={(<BookOperationsCard />)} rightPanel={rightPanel} />)
}

export default SearchBookOP