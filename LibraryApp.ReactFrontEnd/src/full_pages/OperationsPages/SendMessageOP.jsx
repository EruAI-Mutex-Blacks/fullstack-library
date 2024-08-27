import { Link } from "react-router-dom";
import MessageOperationsCard from "../../Components/OperationsCards/MessageOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useUser } from '../../AccountOperations/UserContext'
import { useEffect, useState } from "react";
import { toast } from "react-toastify";


function SendMessageOP() {

    const [receivers, setReceivers] = useState([]);
    const { user } = useUser();
    const [receiverId, setReceiverId] = useState(0);
    const [title, setTitle] = useState("");
    const [message, setMessage] = useState("");

    const getReceivers = async function () {
        const res = await fetch(`http://localhost:5109/api/User/GetUsersOfLowerOrEqualRole?roleId=${user.roleId}&userId=${user.id}`, {
            method: "GET",
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }

        });
        if (!res.ok) return;
        setReceivers(await res.json());
    }

    useEffect(() => {
        getReceivers();
        console.log(receivers);
    }, []);

    //send message to selected one. fetch

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

        const res = await fetch("http://localhost:5109/api/User/SendMessage", {
            method: "POST",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(messageDTO),
        });

        if (!res.ok) return;
        const data = await res.json();
        setReceiverId(0);
        setTitle("");
        setMessage("");
        toast.success("Message has sent");
    }

    //consider adding security bc people can change value of option and we can send random person a msg
    const rightPanel = (
        <form className="grow flex flex-col p-14">
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
            <div className="mb-3 grow">
                <label htmlFor="message" className="block text-white font-medium mb-1">Your message</label>
                <textarea type="text" id="message" className="px-4 py-2 w-full bg-gray-700 text-white rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" rows={8} style={{ resize: "none" }} value={message} onChange={e => setMessage(e.target.value)}></textarea>
            </div>
            <div className="flex justify-end">
                <button onClick={e => handleSendClick(e)} className="border border-transparent inline-block rounded px-8 py-4 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-300 text-white active:bg-green-900">Send</button>
            </div>
        </form>
    );

    return (<GeneralOperationsPage leftPanel={(<MessageOperationsCard />)} rightPanel={rightPanel} />)
}

export default SendMessageOP