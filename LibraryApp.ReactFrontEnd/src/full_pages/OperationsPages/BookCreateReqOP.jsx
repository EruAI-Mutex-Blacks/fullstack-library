import { Link } from "react-router-dom"
import AuthorOperationsCard from "../../Components/OperationsCards/AuthorOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react"
import { toast } from "react-toastify";

function BookCreateReqOP() {

    const [requests, setRequests] = useState([]);

    const getPendingRequests = async function () {
        const response = await fetch("http://localhost:5109/api/Book/BookPublishRequests", {
            method: "GET",
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }
        });

        const data = await response.json();
        if (!response.ok) return;
        setRequests(data);
    }

    useEffect(() => {
        getPendingRequests();
    }, []);

    async function handleApproveRejectClick(requestId, isApproved) {
        const publishBookDTO = {
            requestId: requestId,
            isApproved: isApproved,
        }

        const response = await fetch("http://localhost:5109/api/Book/SetPublishing", {
            method: "PUT",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(publishBookDTO),
        });

        const data = await response.json();
        console.log(data);
        if (!response.ok) return;

        if (isApproved) toast.success("Request approved");
        else toast.error("Request rejected");

        const updatedRequests = requests.filter(r => r.id != requestId);
        setRequests(updatedRequests);
    }

    const rightPanel = (
        <div class="grow overflow-x-auto bg-gray-800 border border-gray-300">
            <table class="w-full text-sm text-left rtl:text-right text-gray-400">
                <thead class="text-xs uppercase bg-gray-700 text-gray-400">
                    <tr>
                        <th class="px-6 py-3">
                            Book name
                        </th>
                        <th class="px-6 py-3">
                            Author
                        </th>
                        <th class="px-6 py-3">
                            Request date
                        </th>
                        <th class="px-6 py-3">
                            Actions
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {requests.map((b, index) => (
                        <tr key={index} className="border-b bg-gray-800 border-gray-700">
                            <td className="px-6 py-4 font-medium whitespace-nowrap text-white">{b.bookName}</td>
                            <td className="px-6 py-4">{b.authors.join(", ")}</td>
                            <td className="px-6 py-4">{new Date(b.requestDate).toLocaleDateString("en-us")}</td>
                            <td className="px-6 py-4">
                                <ul className="flex justify-start">
                                    <li className="me-2"><Link to={`/ReadBook?bookId=` + b.bookId} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Read the book</Link></li>
                                    <li className="me-2"><button onClick={() => { handleApproveRejectClick(b.id, true) }} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Approve</button></li>
                                    <li className="me-2"><button onClick={() => { handleApproveRejectClick(b.id, false) }} className="border border-transparent inline-block rounded px-4 py-2 bg-red-800 hover:bg-red-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-red-950">Reject</button></li>
                                </ul>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>

        // <div className="grow ">
        //     <table className="min-w-full bg-white">
        //         <thead className="">
        //             <tr className="bg-gray-800 text-white border border-gray-300">
        //                 <th className="border-collapse border-gray-300 py-2 px-4 text-left">Book Name</th>
        //                 <th className="border-collapse border-gray-300 py-2 px-4 text-left">Authors</th>
        //                 <th className="border-collapse border-gray-300 py-2 px-4 text-left">Request Date</th>
        //                 <th className="border-collapse border-gray-300 py-2 px-4 text-left">Actions</th>
        //             </tr>
        //         </thead>
        //         <tbody>
        //             {requests.map((b, index) => (
        //                 <tr key={index} className="">
        //                     <td className="border-e border-collapse border-gray-300 py-2 px-4 text-left">{b.bookName}</td>
        //                     <td className="border-e border-collapse border-gray-300 py-2 px-4 text-left">{b.authors.join(", ")}</td>
        //                     <td className="border-e border-collapse border-gray-300 py-2 px-4 text-left">{new Date(b.requestDate).toLocaleDateString("en-us")}</td>
        //                     <td className="border-e border-collapse border-gray-300 py-2 px-4 text-left">
        //                         <ul className="flex justify-start">
        //                             <li className="me-2"><Link to={`/ReadBook?bookId=` + b.bookId} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-white transition-all duration-100 text-gray-300">Read the book</Link></li>
        //                             <li className="me-2"><button onClick={() => { handleApproveRejectClick(b.id, true) }} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-white transition-all duration-100 text-gray-300">Approve</button></li>
        //                             <li className="me-2"><button onClick={() => { handleApproveRejectClick(b.id, false) }} className="border border-transparent inline-block rounded px-4 py-2 bg-red-800 hover:bg-red-900 hover:border-white transition-all duration-100 text-gray-300">Reject</button></li>
        //                         </ul>
        //                     </td>
        //                 </tr>
        //             ))}
        //         </tbody>
        //     </table >
        // </div>
    )

    return (<GeneralOperationsPage leftPanel={(<AuthorOperationsCard />)} rightPanel={rightPanel} />)
}

export default BookCreateReqOP