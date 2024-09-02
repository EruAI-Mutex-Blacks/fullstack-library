import { Link } from "react-router-dom"
import AuthorOperationsCard from "../../Components/OperationsCards/AuthorOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react"
import { useFetch } from "../../Context/FetchContext";
import DefaultTableTemplate from "../../Components/DefaultTableTemplate";
import { useUser } from "../../AccountOperations/UserContext";

function BookCreateReqOP() {

    const [requests, setRequests] = useState([]);
    const [details, setDetails] = useState("");
    const { fetchData } = useFetch();
    const { user } = useUser();

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
            managerId: user.id,
            details: details,
        }

        await fetchData("/api/Book/SetPublishing", "PUT", publishBookDTO);

        const updatedRequests = requests.filter(r => r.id != requestId);
        setRequests(updatedRequests);
    }

    const headersArray = ["Book name", "Author", "Request date", "Actions"];
    const datasArray = requests.map((r, index) => [
        r.bookName,
        r.authors.join(", "),
        new Date(r.requestDate).toLocaleDateString("en-us"),
        (<ul key={index} className="flex justify-start flex-wrap">
            <li className="me-2"><Link to={`/ReadBook?bookId=` + r.bookId} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Read the book</Link></li>
            <li className="me-2"><button onClick={() => { handleApproveRejectClick(r.id, true) }} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Approve</button></li>
            <li className="me-2"><button onClick={() => { handleApproveRejectClick(r.id, false) }} className="border border-transparent inline-block rounded px-4 py-2 bg-red-800 hover:bg-red-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-red-950">Reject</button></li>
            <li className="me-2 grow"><input onChange={e => setDetails(e.target.value)} placeholder="Details" type="text" className="mt-3 lg:mt-0 px-4 py-2 w-full bg-gray-700 text-white rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" /></li>
        </ul>),
    ]);

    const rightPanel = (
        <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
    )

    return (<GeneralOperationsPage leftPanel={(<AuthorOperationsCard />)} rightPanel={rightPanel} />)
}

export default BookCreateReqOP