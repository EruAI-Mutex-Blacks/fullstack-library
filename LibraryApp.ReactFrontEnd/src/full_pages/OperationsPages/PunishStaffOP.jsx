import { Link } from "react-router-dom";
import StaffOperationsCard from "../../Components/OperationsCards/StaffOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"

function PunishStaffOP() {
    //manager can punish staff

    //onchange of select setvalue and send id of selected

    //punishing a member who has lower role
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
            <div className="mb-3">
                <label className="form-label" htmlFor="punishmentDuration">Punishment duration</label>
                <input className="form-control" type="number" id="punishmentDuration" name="punishmentDuration" min="1" max="365" />
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

    return (<GeneralOperationsPage leftPanel={(<StaffOperationsCard />)} rightPanel={rightPanel} />)
}

export default PunishStaffOP