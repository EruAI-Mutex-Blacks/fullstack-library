import { Link } from "react-router-dom";
import BookOperationsCard from "../../Components/OperationsCards/BookOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"


function BorrowedBooksOP() {

    //borrowed books will be fetched from api using current logged in user's id.
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

    function handleReturnClick(book) {
    }

    const rightPanel = (
        <table className="table table-light table-striped table-hover flex-fill">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Title</th>
                    <th>Publish Date</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {seedBooks.map(b => (
                    <tr>
                        <td>{b.id}</td>
                        <td>{b.title}</td>
                        <td>{b.publishDate}</td>
                        <td>
                            <ul className="list-inline d-flex justify-content-start">
                                <li className="me-2"><Link to={`/ReadBook?bookId=` + b.id} className={`py-1 px-2 btn btn-danger`}>Read</Link></li>
                                <li className="me-2"><Link onClick={() => { handleReturnClick(b) }} className={`py-1 px-2 btn btn-success`}>Return</Link></li>
                            </ul>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table >
    )

    return (<GeneralOperationsPage leftPanel={(<BookOperationsCard />)} rightPanel={rightPanel} />)
}

export default BorrowedBooksOP