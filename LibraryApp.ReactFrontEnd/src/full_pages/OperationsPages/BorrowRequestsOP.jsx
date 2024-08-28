import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useFetch } from "../../Context/FetchContext";


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

    const rightPanel = (
        <div class="grow overflow-x-auto bg-gray-800 border border-gray-300">
            <table class="w-full text-sm text-left rtl:text-right text-gray-400">
                <thead class="text-xs uppercase bg-gray-700 text-gray-400">
                    <tr>
                        <th className="px-6 py-3">Book</th>
                        <th className="px-6 py-3">Requestor</th>
                        <th className="px-6 py-3">Borrow Date</th>
                        <th className="px-6 py-3">Return Date</th>
                        <th className="px-6 py-3">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {bookBorrowDTOS.map((b, index) => (
                        <tr key={index} className="border-b bg-gray-800 border-gray-700">
                            <td className="px-6 py-4 font-medium whitespace-nowrap text-white">{b.bookDTO.title}</td>
                            <td className="px-6 py-4">{b.requestorName}</td>
                            <td className="px-6 py-4">{new Date(b.borrowDate).toLocaleDateString("en-US")}</td>
                            <td className="px-6 py-4">{new Date(b.returnDate).toLocaleDateString("en-us")}</td>
                            <td className="px-6 py-4">
                                <ul className="flex justify-start">
                                    <li className="me-2"><Link onClick={() => { handleClick(true, b.id) }} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Approve</Link></li>
                                    <li className="me-2"><Link onClick={() => { handleClick(false, b.id) }} className="border border-transparent inline-block rounded px-4 py-2 bg-red-800 hover:bg-red-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-red-950">Reject</Link></li>
                                </ul>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table >
        </div>
    )

    return (<GeneralOperationsPage leftPanel={(<MemberOperationsCard />)} rightPanel={rightPanel} />)
}

export default BorrowRequestsOP