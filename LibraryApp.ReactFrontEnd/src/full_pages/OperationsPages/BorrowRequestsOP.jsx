import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useFetch } from "../../Context/FetchContext";
import DefaultTableTemplate from "../../Components/DefaultTableTemplate";


function BorrowRequestsOP() {

    const [bookBorrowDTOS, setBookBorrowDTOS] = useState([]);
    const { fetchData } = useFetch();

    const fetchBorrowRequests = async function () {
        const data = await fetchData("/api/Book/BorrowRequests", "GET");
        setBookBorrowDTOS(data, []);
    };

    useEffect(() => {
        fetchBorrowRequests();
    }, []);

    const handleClick = async (isApproved, id) => {
        const br = {
            id: id,
            isApproved: isApproved,
        }

        const data = await fetchData("/api/Book/SetBorrowRequest", "POST", br);
        await fetchBorrowRequests();
    }

    const headersArray = ["Book", "Requestor", "Borrow Date", "Return Date", "Actions"];
    const datasArray = bookBorrowDTOS.map(b => [
        b.bookDTO.title,
        b.requestorName,
        new Date(b.borrowDate).toLocaleDateString("en-US"),
        new Date(b.returnDate).toLocaleDateString("en-US"),
        (<ul className="flex justify-start">
            <li className="me-2"><Link onClick={() => { handleClick(true, b.id) }} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Approve</Link></li>
            <li className="me-2"><Link onClick={() => { handleClick(false, b.id) }} className="border border-transparent inline-block rounded px-4 py-2 bg-red-800 hover:bg-red-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-red-950">Reject</Link></li>
        </ul>),
    ]);

    const rightPanel = (
        <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
    )

    return (<GeneralOperationsPage leftPanel={(<MemberOperationsCard />)} rightPanel={rightPanel} />)
}

export default BorrowRequestsOP