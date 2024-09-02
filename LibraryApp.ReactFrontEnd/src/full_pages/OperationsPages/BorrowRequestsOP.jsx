import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useFetch } from "../../Context/FetchContext";
import DefaultTableTemplate from "../../Components/DefaultTableTemplate";
import { useUser } from "../../AccountOperations/UserContext";


function BorrowRequestsOP() {

    const [bookBorrowDTOS, setBookBorrowDTOS] = useState([]);
    const [details, setDetails] = useState("");
    const { fetchData } = useFetch();
    const { user } = useUser();

    const fetchBorrowRequests = async function () {
        const data = await fetchData("/api/Book/BorrowRequests", "GET");
        setBookBorrowDTOS(data, []);
    };

    useEffect(() => {
        fetchBorrowRequests();
    }, []);

    const handleApproveRejectClick = async (isApproved, requestId) => {
        const br = {
            id: requestId,
            isApproved: isApproved,
            staffId: user.id,
            details: details,
        }

        fetchData("/api/Book/SetBorrowRequest", "POST", br)
            .then(async () => {
                await fetchBorrowRequests();
            });
    }

    const headersArray = ["Book", "Requestor", "Borrow Date", "Return Date", "Actions"];
    const datasArray = bookBorrowDTOS.map((b, index) => [
        b.bookDTO.title,
        b.requestorName,
        new Date(b.borrowDate).toLocaleDateString("en-US"),
        new Date(b.returnDate).toLocaleDateString("en-US"),
        (<ul key={index} className="flex justify-start ">
            <li className="me-2"><Link onClick={() => { handleApproveRejectClick(true, b.id) }} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Approve</Link></li>
            <li className="me-2"><Link onClick={() => { handleApproveRejectClick(false, b.id) }} className="border border-transparent inline-block rounded px-4 py-2 bg-red-800 hover:bg-red-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-red-950">Reject</Link></li>
            <li className="me-2 grow"><input onChange={e => setDetails(e.target.value)} placeholder="Details" type="text" className="px-4 py-2 bg-gray-700 text-white rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" /></li>
        </ul>),
    ]);

    const rightPanel = (
        <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
    )

    return (<GeneralOperationsPage leftPanel={(<MemberOperationsCard />)} rightPanel={rightPanel} />)
}

export default BorrowRequestsOP