import { Link } from "react-router-dom"
import AuthorOperationsCard from "../../Components/OperationsCards/AuthorOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react"
import { toast } from "react-toastify";
import { useFetch } from "../../Context/FetchContext";

function BookCreateReqOP() {

    const [requests, setRequests] = useState([]);
    const { fetchData } = useFetch();

    const fetchPendingRequests = async function () {
        const data = await fetchData("/api/Book/BookPublishRequests", "GET");
        setRequests(data ?? []);
    }

    useEffect(() => {
        fetchPendingRequests();
    }, []);

    async function handleApproveRejectClick(requestId, isApproved) {
        const publishBookDTO = {
            requestId: requestId,
            isApproved: isApproved,
        }

        const data = await fetchData("/api/Book/SetPublishing", "PUT", publishBookDTO);

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
    )

    return (<GeneralOperationsPage leftPanel={(<AuthorOperationsCard />)} rightPanel={rightPanel} />)
}

export default BookCreateReqOP