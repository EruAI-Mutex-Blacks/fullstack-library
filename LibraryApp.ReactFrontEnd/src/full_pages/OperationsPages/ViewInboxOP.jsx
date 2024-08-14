import { useState } from "react";
import MessageOperationsCard from "../../Components/OperationsCards/MessageOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"


function ViewInboxOP() {
    //TODO need messages table for database need read or unread column
    //TODO maybe do message card jsx component for left panel to not repeat same codes
    //TODO add topic of message

    const [username, setUsername] = useState("iniital?");
    const [avatar, setAvatar] = useState("initial?");
    const [msgDetails, setMsgDetails] = useState("determine what to put here as initially");

    const handleMsgCardClick = function (user) {
        //GET message content from api with sender id and receiver id instead of below.
        setMsgDetails("fwefwgwrgwefew wrgwrg erg erg erg r erg et awd af wee sacdasd asda sd asda sd asda sdas");
        setUsername(user.name);
        setAvatar(user.avatar);
        //TODO add extra read state here
    }

    //messages that has sent to currently logged in user
    const rightPanel = (
        <div className="d-flex container flex-fill justify-content-between">
            <div className="col-3 me-2 p-2 bg-light rounded" style={{ height: "65vh", overflow: "auto" }}>
                {/*--------------------------------- card -----------------------------------*/}
                <div onClick={() => { handleMsgCardClick({ id: 1, name: "turker" , avatar:"turko.jpg"}) }} className="mb-2 d-flex flex-column border border-dark rounded p-2 bg-success-subtle btn">
                    <div className="d-flex mb-2 justify-content-between border-bottom border-dark">
                        <div>sm avt</div>
                        <div><h6 className="align-self-center">Sender 1</h6></div>
                    </div>
                    <div className="d-flex justify-content-between">
                        <p className="pt-1 fs-7 mb-2">small piece..</p>
                        <span className="badge text-bg-danger align-self-center ms-2 p-1">unread</span>
                    </div>
                </div>
                {/*--------------------------------- card -----------------------------------*/}
                <div onClick={() => { handleMsgCardClick({ id: 1, name: "mrat" , avatar:"mrat.jpg"}) }} className="mb-2 d-flex flex-column border border-dark rounded p-2 bg-success-subtle btn">
                    <div className="d-flex mb-2 justify-content-between border-bottom border-dark">
                        <div>sm avt</div>
                        <div><h6 className="align-self-center">Sender 1</h6></div>
                    </div>
                    <div className="d-flex justify-content-between">
                        <p className="pt-1 fs-7 mb-2">small piece..</p>
                        <span className="badge text-bg-danger align-self-center ms-2 p-1">unread</span>
                    </div>
                </div>
                {/*--------------------------------- card -----------------------------------*/}
                <div onClick={() => { handleMsgCardClick({ id: 1, name: "hata" , avatar:"hata.jpg"}) }} className="mb-2 d-flex flex-column border border-dark rounded p-2 bg-success-subtle btn">
                    <div className="d-flex mb-2 justify-content-between border-bottom border-dark">
                        <div>sm avt</div>
                        <div><h6 className="align-self-center">Sender 1</h6></div>
                    </div>
                    <div className="d-flex justify-content-between">
                        <p className="pt-1 fs-7 mb-2">small piece..</p>
                        <span className="badge text-bg-danger align-self-center ms-2 p-1">unread</span>
                    </div>
                </div>
            </div>
            <div className="col-9 p-2 bg-light rounded d-flex flex-column" style={{ height: "65vh", overflow: "auto" }}>
                <div className="d-flex justify-content-between bg-success-subtle border-bottom border-dark px-3 pt-3 pb-0 rounded mb-2">
                    <div>{avatar}</div>
                    <h4>{username}</h4>
                </div>
                <div className="p-3 bg-success-subtle px-3 pt-3 pb-0 rounded">
                    <p>{msgDetails}</p>
                </div>
            </div>
        </div>
    );

    return (<GeneralOperationsPage leftPanel={(<MessageOperationsCard />)} rightPanel={rightPanel} />)
}

export default ViewInboxOP