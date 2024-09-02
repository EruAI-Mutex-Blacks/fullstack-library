import { useEffect, useState } from "react";
import MessageOperationsCard from "../../Components/OperationsCards/MessageOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useUser } from "../../AccountOperations/UserContext"
import { useFetch } from "../../Context/FetchContext";

function ViewInboxOP() {
    const { user } = useUser();
    const [messages, setMessages] = useState([]);
    const [senderName, setSenderName] = useState("");
    const [msgDetails, setMsgDetails] = useState("");
    const [msgTitle, setMsgTitle] = useState("");
    const { fetchData } = useFetch();

    const fetchInbox = async function () {
        const data = await fetchData("/api/User/GetInbox?userId=" + user.id, "GET");
        setMessages(data ?? []);
    }

    const updateReadMsg = async function (msgId) {
        await fetchData("/api/User/UpdateMessageReadState", "PUT", msgId);
    }

    useEffect(() => {
        fetchInbox();
    }, []);

    const handleMsgCardClick = async function (message) {
        setSenderName(message.senderName);
        setMsgDetails(message.details);
        setMsgTitle(message.title);

        if (!message.isReceiverRead) {
            updateReadMsg(message.id);

            message.isReceiverRead = true;

            //to make react re render page
            const updatedMessages = messages.map(m =>
                m.id === message.id ? { ...m, isReceiverRead: true } : m
            );
            setMessages(updatedMessages);
        }
    }
    const rightPanel = (
        <div className="flex flex-col grow px-1 lg:px-10 xl:px-10 pt-3 pb-8 text-gray-100">
            <h6 className="text-start ms-1 lg:ms-5 xl:ms-5 mb-1 font-bold ">[ {messages.filter(m => !m.isReceiverRead).length} unread messages ]</h6>
            <div className="grid grid-cols-4 container p-0 grow h-full">
                <div className="bg-gray-700 col-span-1 me-2 p-2 rounded overflow-y-auto" >
                    {messages.map((m, index) =>
                    (
                        <div key={index} onClick={() => { handleMsgCardClick(m) }} className="hover:cursor-pointer hover:bg-gray-600 hover:ring-1 hover:ring-gray-400 mb-2 flex flex-col rounded p-2 bg-gray-500 transition-all duration-100">
                            <div className="flex mb-2 justify-between border-b border-gray-300">
                                <p className="mb-1 pe-1 text-start text-sm hidden lg:block xl:block">{m.title.slice(0, 10) + "..."}</p>
                                <p className="mb-1 ps-1 text-sm text-center lg:text-end xl:text-end"><b>{m.senderName}</b></p>
                            </div>
                            <div className="flex justify-center lg:justify-between xl:justify-between">
                                <p className="pt-1 text-md mb-2 text-start hidden lg:block xl:block">{m.details.slice(0, 20) + "..."}</p>
                                <span className={`rounded px-2 py-1 ms-2 self-center text-xs text-white font-medium ${m.isReceiverRead ? "bg-blue-700" : "bg-red-700"} `}>{m.isReceiverRead ? "read" : "unread"}</span>
                            </div>
                        </div>
                    )
                    )}
                    
                </div>
                <div className="col-span-3 bg-gray-700 p-2 rounded flex flex-col">
                    <div className="flex justify-between bg-gray-500 border-b border-gray-300 px-3 pt-3 pb-1 rounded mb-2">
                        <div className="text-start text-lg">{msgTitle}</div>
                        <h5 className="text-end font-bold text-lg">{senderName}</h5>
                    </div>
                    <div className="p-3 bg-gray-500 px-3 pt-3 pb-0 rounded grow overflow-y-auto" >
                        <p>{msgDetails}</p>
                    </div>
                </div>
            </div>
        </div>
    );
    return (<GeneralOperationsPage leftPanel={(<MessageOperationsCard />)} rightPanel={rightPanel} />)
}

export default ViewInboxOP

//FIXME read message tasarımı bozuk.
//FIXME mesajlar olduğu kadar büyüyor. overflow y yap