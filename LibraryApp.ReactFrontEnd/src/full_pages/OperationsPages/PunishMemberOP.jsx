import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"


function PunishMemberOP() {

    //onchange of select setvalue and send id of selected

    //punishing a member
    const handlePunishClick = function (id) {
    }

    const rightPanel = (
        <form className="flex-fill">
            <div className="mb-3">
                <label htmlFor="sendingTo" className="form-label">Select to punish</label>
                <select id="sendingTo" className="form-select">
                    <option value="">Select someone</option>
                    <option value="1">Turker sur - Author</option>
                    <option value="2">Mehmet kap - Staff</option>
                    <option value="3">Aslı bım - Member</option>
                </select>
            </div>
            <div className="mb-3 d-flex justify-content-between">
                <div className="me-5 flex-fill">
                    <p>Delayed days</p>
                    <p>{6} </p>
                </div>
                <div className="me-5 flex-fill">
                    <label className="form-label" htmlFor="finePerDay">Fine amount per day</label>
                    <input id="finePerDay" className="form-control d-inline" type="number" min={0.1} step={0.1} />
                </div>
                <div className="flex-fill">
                    <p>Total fine</p>
                    <p>{"15$"}</p>
                </div>
            </div>
            <div className="mb-3">
                <label htmlFor="message" className="form-label">Cause & details of punishment</label>
                <textarea type="text" className="form-control" rows={4} style={{ resize: "none" }}></textarea>
            </div>
            <div className="d-flex justify-content-end">
                <Link onClick={() => { handlePunishClick(id) }} className="btn btn-danger py-2 px-4">Punish</Link>
            </div>
        </form>
    );
    return (<GeneralOperationsPage leftPanel={(<MemberOperationsCard />)} rightPanel={rightPanel} />)
}

export default PunishMemberOP