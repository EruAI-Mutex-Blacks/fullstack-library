import { Link } from "react-router-dom";
import StaffOperationsCard from "../../Components/OperationsCards/StaffOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext";

function ChangeRoleOP() {
    //users will be listed that has lower role from manager. currently logged in user can change role of them to make it lower or manager

    const { user } = useUser();
    const [lowerRoleUsers, setLowerRoleUsers] = useState([]);
    const [selectedUser, setSelectedUser] = useState({});
    const [allRemainingRoles, setAllRemainingRoles] = useState([]);

    const getLowerRoleUsers = async function () {
        const res = await fetch(`http://localhost:5109/api/User/GetUsersOfLowerRole?roleId=${user.roleId}&userId=${user.id}`, {
            method: "GET"
        });

        if (!res.ok) return;

        setLowerRoleUsers(await res.json());
    }

    const getAllRemainingRoles = async function (roleId) {
        //getting all roles
        const res = await fetch(`http://localhost:5109/api/User/GetAllRoles?roleId=${roleId}`, {
            method: "GET"
        });
        if (!res.ok) return;
        setAllRemainingRoles(await res.json());
    }

    const handleSelectionChange = function (e) {
        const selectedUser = lowerRoleUsers.find(lru => lru.id == e.target.value);
        setSelectedUser(selectedUser);
        if(!selectedUser)
        {
            setAllRemainingRoles([]);
            return;
        }
        getAllRemainingRoles(selectedUser.roleId);
    }

    useEffect(() => {
        getLowerRoleUsers();
    }, []);

    const rightPanel = (
        <div className="flex-fill">
            <div className="mb-3">
                <label htmlFor="userToChange" className="form-label">Select user</label>
                <select name="userToChange" id="userToChange" className="form-select" onChange={e => handleSelectionChange(e)}>
                    <option value="">Select someone</option>
                    {lowerRoleUsers.map((lru, index) => (
                        <option key={index} value={lru.id}>{lru.name + " - " + lru.roleName}</option>
                    ))}
                </select>
            </div>
            <div className="mb-3">
                <label htmlFor="role" className="form-label">Role</label>
                <select name="role" id="role" className="form-select">
                    <option value="">Select another role</option>
                    {allRemainingRoles.map((arr, index) => (
                        <option key={index} value={arr?.id}>{arr?.name}</option>
                    ))}
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