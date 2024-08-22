import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";


function BorrowRequestsOP() {

    //borrow requests from members that has sent to currently logged in staff

    const [bookBorrowDTOS, setBookBorrowDTOS] = useState([]);

    const getBorrowRequests = async function () {
        try {
            const response = await fetch("http://localhost:5109/api/Book/BorrowRequests", {
                method: "GET",
            });

            if (!response.ok) return;

            const bookBorrowDTOS = await response.json();
            setBookBorrowDTOS(bookBorrowDTOS);

        } catch (error) {
            console.log("there was an error in fetching", error);
        }
    };

    useEffect(() => {
        getBorrowRequests();
    }, []);

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
                    <th>Requestor</th>
                    <th>Borrow Date</th>
                    <th>Return Date</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {bookBorrowDTOS.map((b, index) => (
                    <tr key={index}>
                        <td>{b.bookDTO.title}</td>
                        <td>{b.requestorName}</td>
                        <td>{new Date(b.borrowDate).toLocaleDateString("en-US")}</td>
                        <td>{new Date(b.returnDate).toLocaleDateString("en-us")}</td>
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

    return (<GeneralOperationsPage leftPanel={(<MemberOperationsCard />)} rightPanel={rightPanel} />)
}

export default BorrowRequestsOP