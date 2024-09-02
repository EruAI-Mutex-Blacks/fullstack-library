import { Link } from "react-router-dom";
import MessageOperationsCard from "../../Components/OperationsCards/MessageOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useUser } from '../../AccountOperations/UserContext'
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useFetch } from "../../Context/FetchContext";


function SendMessageOP() {

    const [receivers, setReceivers] = useState([]);
    const { user } = useUser();
    const [receiverId, setReceiverId] = useState(0);
    const [title, setTitle] = useState("");
    const [message, setMessage] = useState("");
    const { fetchData } = useFetch();

    const fetchReceivers = async function () {
        const data = await fetchData(`/api/User/GetUsersOfLowerUpperRole?roleId=${user.roleId}&userId=${user.id}`, "GET");
        setReceivers(data ?? []);
    }

    useEffect(() => {
        fetchReceivers();
        console.log(receivers);
    }, []);

    const handleSendClick = async function (e) {
        e.preventDefault();

        if (!receiverId || !title || !message) {
            toast.error("Please fill all the fields");
            return;
        }

        const messageDTO = {
            senderId: user.id,
            receiverId: receiverId,
            title: title,
            details: message,
        }

        fetchData("/api/User/SendMessage", "POST", messageDTO)
            .then(() => {
                setReceiverId(0);
                setTitle("");
                setMessage("");
            });
    }

    const rightPanel = (
        <form className="grow flex flex-col px-14 py-6">
            <div className="mb-3">
                <label htmlFor="sendingTo" className="text-white block font-medium mb-1">Select an option</label>
                <select id="sendingTo" className="px-4 py-2 w-full bg-gray-700 text-white rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" onChange={e => setReceiverId(e.target.value)}>
                    <option value="">Select receiver</option>
                    {receivers.map((rc, index) => (
                        <option key={index} value={rc.id}>{rc.name + " - " + rc.roleName}</option>
                    ))}
                </select>
            </div>
            <div className="mb-3">
                <label htmlFor="title" className="text-white font-medium mb-1 block">Title</label>
                <input type="text" id="title" className="px-4 py-2 w-full bg-gray-700 text-white rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" onChange={e => setTitle(e.target.value)} value={title} maxLength={75} />
            </div>
            <div className="mb-3 grow flex flex-col">
                <label htmlFor="message" className="block text-white font-medium mb-1">Your message</label>
                <textarea type="text" id="message" className="grow px-4 py-2 w-full bg-gray-700 text-white rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" style={{ resize: "none" }} value={message} onChange={e => setMessage(e.target.value)}></textarea>
            </div>
            <div className="self-end">
                <button onClick={e => handleSendClick(e)} className="border border-transparent inline-block rounded px-6 py-3 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900">Send</button>
            </div>
        </form>
    );

    return (<GeneralOperationsPage leftPanel={(<MessageOperationsCard />)} rightPanel={rightPanel} />)
}

export default SendMessageOP