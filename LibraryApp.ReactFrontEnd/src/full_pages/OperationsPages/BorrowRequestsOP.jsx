import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { toast } from "react-toastify";


function BorrowRequestsOP() {

    //borrow requests from members that has sent to currently logged in staff

    const [bookBorrowDTOS, setBookBorrowDTOS] = useState([]);

    const getBorrowRequests = async function () {
        try {
            const response = await fetch("http://localhost:5109/api/Book/BorrowRequests", {
                method: "GET",
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }
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

    async function handleClick(isApproved, id) {
        const br = {
            id: id,
            isApproved: isApproved,
        }

        const res = await fetch("http://localhost:5109/api/Book/SetBorrowRequest", {
            method: "POST",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(br),
        })

        if (!res.ok) return;
        const data = await res.json();

        if (isApproved) toast.success("Request approved");
        else toast.error("Request rejected");

        await getBorrowRequests();
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