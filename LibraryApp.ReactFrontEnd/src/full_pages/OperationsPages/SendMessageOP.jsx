import { Link } from "react-router-dom";
import MessageOperationsCard from "../../Components/OperationsCards/MessageOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useUser } from '../../AccountOperations/UserContext'
import { useEffect, useState } from "react";

function SendMessageOP() {

    const [receivers, setReceivers] = useState([]);
    const { user } = useUser();
    const [receiverId, setReceiverId] = useState(0);
    const [title, setTitle] = useState("");
    const [message, setMessage] = useState("");

    const getReceivers = async function () {
        const res = await fetch(`http://localhost:5109/api/User/GetMsgReceivers?roleId=${user.roleId}&userId=${user.id}`, {
            method: "GET"
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

        const messageDTO = {
            senderId: user.id,
            receiverId: receiverId,
            title: title,
            details: message,
        }

        const res = await fetch("http://localhost:5109/api/User/SendMessage", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(messageDTO),
        });

        if(!res.ok) return;
        const data = await res.json();
        console.log(data);
    }

    //consider adding security bc people can change value of option and we can send random person a msg
    const rightPanel = (
        <form className="flex-fill">
            <div className="mb-3">
                <label htmlFor="sendingTo" className="form-label">Select receiver</label>
                <select id="sendingTo" className="form-select" onChange={e => setReceiverId(e.target.value)}>
                    <option value="0">Select someone</option>
                    {receivers.map((rc, index) => (
                        <option key={index} value={rc.id}>{rc.name + " - " + rc.roleName}</option>
                    ))}
                </select>
            </div>
            <div className="mb-3">
                <label htmlFor="title" className="form-label">Title</label>
                <input type="text" id="title" className="form-control" onChange={e => setTitle(e.target.value)} />
            </div>
            <div className="mb-3">
                <label htmlFor="message" className="form-label">Your message</label>
                <textarea type="text" id="message" className="form-control" rows={3} style={{ resize: "none" }} onChange={e => setMessage(e.target.value)}></textarea>
            </div>
            <div className="d-flex justify-content-end">
                <button onClick={e => handleSendClick(e)} className="btn btn-success py-2 px-4">Send</button>
            </div>
        </form>
    );

    return (<GeneralOperationsPage leftPanel={(<MessageOperationsCard />)} rightPanel={rightPanel} />)
}

export default SendMessageOP