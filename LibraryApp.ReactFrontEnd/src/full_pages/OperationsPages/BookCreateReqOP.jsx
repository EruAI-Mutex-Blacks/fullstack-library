import { Link } from "react-router-dom"
import AuthorOperationsCard from "../../Components/OperationsCards/AuthorOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"

function BookCreateReqOP() {
    //Book creation requests that has sent to logged in manager
    //TODO need to do reading page for books
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

    function handleApproveClick(book) {
        window.alert("approved");
    }

    function handleRejectClick(book) {
        window.alert("rejected");
    }

    const rightPanel = (
        <table className="table table-light table-striped table-hover flex-fill">
            <thead>
                <tr>
                    <th>Book</th>
                    <th>Author</th>
                    <th>Request Date</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {seedBooks.map(b => (
                    <tr>
                        <td>{b.title}</td>
                        <td>{"hey"}</td>
                        <td>{new Date().getFullYear()}</td>
                        <td>
                            <ul className="list-inline d-flex justify-content-start">
                                <li className="me-2"><Link onClick={() => { handleApproveClick(b) }} className={`py-1 px-2 btn btn-success`}>Approve</Link></li>
                                <li className="me-2"><Link onClick={() => { handleRejectClick(b) }} className={`py-1 px-2 btn btn-danger`}>Reject</Link></li>
                            </ul>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table >
    )

    return (<GeneralOperationsPage leftPanel={(<AuthorOperationsCard />)} rightPanel={rightPanel} />)
}

export default BookCreateReqOP