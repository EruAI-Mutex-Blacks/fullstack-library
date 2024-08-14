import { Link } from "react-router-dom";
import StaffOperationsCard from "../../Components/OperationsCards/StaffOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"

function ChangeRoleOP() {
    //users will be listed that has lower role from manager. currently logged in user can change role of them to make it lower or manager
    const rightPanel = (
        <div className="flex-fill">
            <div className="mb-3">
                <label htmlFor="userToChange" className="form-label">Select user</label>
                <select name="userToChange" id="userToChange" className="form-select">
                    <option value="">Select someone</option>
                    <option value="1">Test1</option>
                    <option value="2">Test2</option>
                    <option value="3">Test3</option>
                </select>
            </div>
            <div className="mb-3">
                <label htmlFor="role" className="form-label">Role</label>
                <select name="role" id="role" className="form-select">
                    <option value="">Current role</option>
                    <option value="">Another role</option>
                    <option value="">Another role</option>
                    <option value="">Another role</option>
                </select>
            </div>
            <div className="mb-3 d-flex justify-content-end">
                <Link className="btn btn-success">Update</Link>
            </div>


        </div>
    );

    return (<GeneralOperationsPage leftPanel={(<StaffOperationsCard />)} rightPanel={rightPanel} />)
}

export default ChangeRoleOP