import { Link } from "react-router-dom"
import AuthorOperationsCard from "../../Components/OperationsCards/AuthorOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react"

function BookCreateReqOP() {

    const [requests, setRequests] = useState([]);

    const getPendingRequests = async function () {
        const response = await fetch("http://localhost:5109/api/Book/BookPublishRequests", {
            method: "GET"
        });

        const data = await response.json();
        if (!response.ok) return;
        setRequests(data);
    }

    useEffect(() => {
        getPendingRequests();
    }, []);

    function handleApproveRejectClick(bookId, isApproved) {

    }

    const rightPanel = (
        <table className="table table-light table-striped table-hover flex-fill">
            <thead>
                <tr>
                    <th>Book Name</th>
                    <th>Authors</th>
                    <th>Request Date</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {requests.map((b, index) => (
                    <tr key={index}>
                        <td>{b.bookName}</td>
                        <td>{b.authors.join(", ")}</td>
                        <td>{new Date(b.requestDate).toLocaleDateString("en-us")}</td>
                        <td>
                            <ul className="list-inline d-flex justify-content-start">
                                <li className="me-2"><Link to={`/ReadBook?bookId=` + b.bookId} className={`py-1 px-2 btn btn-danger`}>Read the book</Link></li>
                                <li className="me-2"><button onClick={() => { handleApproveRejectClick(b.id, true) }} className={`py-1 px-2 btn btn-success`}>Approve</button></li>
                                <li className="me-2"><button onClick={() => { handleApproveRejectClick(b.id, false) }} className={`py-1 px-2 btn btn-danger`}>Reject</button></li>
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