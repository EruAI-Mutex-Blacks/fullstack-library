import { useEffect, useState } from "react";
import MessageOperationsCard from "../../Components/OperationsCards/MessageOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useUser } from "../../AccountOperations/UserContext"

function ViewInboxOP() {
    //TODO maybe do message card jsx component for left panel to not repeat same codes
    //TODO add title of message

    const { user } = useUser();
    const [messages, setMessages] = useState([]);
    const [senderName, setSenderName] = useState("iniital?");
    const [msgDetails, setMsgDetails] = useState("determine what to put here as initially");
    const [msgTitle, setMsgTitle] = useState("hey");

    const getInbox = async function () {
        const res = await fetch("http://localhost:5109/api/User/GetInbox?userId=" + user.id);
        if (!res.ok) return;
        const messages = await res.json();
        setMessages(messages);
        console.log(messages);
    }

    useEffect(() => {
        getInbox();
    }, []);

    //when click on a message from left fetch that message or just filter fetched messages list so we need messageId

    const handleMsgCardClick = async function (message) {
        setSenderName(message.senderName);
        setMsgDetails(message.details);
        setMsgTitle(message.title);

        //TODO add extra read state and when unmount fetch db to update readstates here
    }

    const rightPanel = (
        <div className="d-flex container p-0 flex-fill justify-content-between">
            <div className="col-3 me-2 p-2 bg-light rounded" style={{ height: "65vh", overflow: "auto" }}>
                {messages.map((m, index) =>
                (
                    <div key={index} onClick={() => { handleMsgCardClick(m) }} className="mb-2 d-flex flex-column border border-dark rounded p-2 bg-success-subtle btn">
                        <div className="d-flex mb-2 justify-content-between border-bottom border-dark">
                            <p className="mb-1 pe-1 text-start fs-7">{m.title}</p>
                            <p className="mb-1 ps-1 fs-8 text-end"><b>{m.senderName}</b></p>
                        </div>
                        <div className="d-flex justify-content-between">
                            <p className="pt-1 fs-8 mb-2 text-start">{m.details.slice(0, 20) + "..."}</p>
                            <span className="badge text-bg-danger align-self-center ms-2 p-1">unread</span>
                        </div>
                    </div>
                )
                )}
            </div>
            <div className="col-9 p-2 bg-light rounded d-flex flex-column" style={{ height: "65vh" }}>
                <div className="d-flex justify-content-between bg-success-subtle border-bottom border-dark px-3 pt-3 pb-0 rounded mb-2">
                    <div className="text-start">{msgTitle}</div>
                    <h5 className="text-end">{senderName}</h5>
                </div>
                <div className="p-3 bg-success-subtle px-3 pt-3 pb-0 rounded flex-fill" style={{ overflow: "auto" }}>
                    <p>{msgDetails}</p>
                </div>
            </div>
        </div>
    );
    //FIXME yazı uzayınca nedense genişliyor
    return (<GeneralOperationsPage leftPanel={(<MessageOperationsCard />)} rightPanel={rightPanel} />)
}

export default ViewInboxOP