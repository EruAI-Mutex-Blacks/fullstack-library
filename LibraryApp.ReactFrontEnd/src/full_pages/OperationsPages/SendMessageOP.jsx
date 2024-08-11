import MessageOperationsCard from "../../Components/OperationsCards/MessageOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"


function SendMessageOP() {
    //TODO need messageactivity table for database 
    //there will be users to send message which populated depended on current logged in users's role.
    const rightPanel = (
        <form className="">
            <div className="mb-3">
                <label htmlFor="sendingTo" className="form-label">Select receiver</label>
                <select id="sendingTo" className="form-select">
                    <option value="">Select someone</option>
                </select>
            </div>
            <div className="mb-3">
                <label htmlFor="message" className="form-label">Your message</label>
                <textarea type="text" className="form-control" rows={10} cols={10} style={{ resize: "none" }}></textarea>
            </div>
            <div className="d-flex justify-content-end">
                <button className="btn btn-success py-2 px-4">Send</button>
            </div>
        </form>
    );

    return (<GeneralOperationsPage leftPanel={(<MessageOperationsCard />)} rightPanel={rightPanel} />)
}

export default SendMessageOP