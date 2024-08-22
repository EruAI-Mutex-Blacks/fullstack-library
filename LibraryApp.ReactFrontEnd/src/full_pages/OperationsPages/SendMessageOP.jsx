import { Link } from "react-router-dom";
import MessageOperationsCard from "../../Components/OperationsCards/MessageOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"


function SendMessageOP() {
    //there will be users to send message which populated depended on current logged in userss' role.
    const handleSendClick = function()
    {
        //from logged in user to selected user
    }

    const rightPanel = (
        <form className="flex-fill">
            <div className="mb-3">
                <label htmlFor="sendingTo" className="form-label">Select receiver</label>
                <select id="sendingTo" className="form-select">
                    <option value="">Select someone</option>
                    <option value="1">Turker sur - Author</option>
                    <option value="2">Mehmet kap - Staff</option>
                    <option value="3">Aslı bım - Member</option>
                </select>
            </div>
            <div className="mb-3">
                <label htmlFor="message" className="form-label">Your message</label>
                <textarea type="text" className="form-control" rows={10} cols={10} style={{ resize: "none" }}></textarea>
            </div>
            <div className="d-flex justify-content-end">
                <Link onClick={handleSendClick} className="btn btn-success py-2 px-4">Send</Link>
            </div>
        </form>
    );

    return (<GeneralOperationsPage leftPanel={(<MessageOperationsCard />)} rightPanel={rightPanel} />)
}

export default SendMessageOP