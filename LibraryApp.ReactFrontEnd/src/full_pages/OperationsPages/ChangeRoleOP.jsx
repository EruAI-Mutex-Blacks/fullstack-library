import { Link } from "react-router-dom";
import GeneralOperationsCard from "../../Components/OperationsCards/GeneralOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext";
import { toast } from "react-toastify";

function ChangeRoleOP() {
    //users will be listed that has lower role from manager. currently logged in user can change role of them to make it lower or manager

    const { user } = useUser();
    const [lowerRoleUsers, setLowerRoleUsers] = useState([]);
    const [selectedUser, setSelectedUser] = useState({});
    const [allRemainingRoles, setAllRemainingRoles] = useState([]);
    const [selectedRoleId, setSelectedRoleId] = useState(0);

    const getLowerRoleUsers = async function () {
        const res = await fetch(`http://localhost:5109/api/User/GetUsersOfLowerRole?roleId=${user.roleId}&userId=${user.id}`, {
            method: "GET", headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }

        });

        if (!res.ok) return;

        setLowerRoleUsers(await res.json());
    }

    const getAllRemainingRoles = async function (roleId) {
        //getting all roles
        const res = await fetch(`http://localhost:5109/api/User/GetAllRoles?roleId=${roleId}`, {
            method: "GET",
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }
        });
        if (!res.ok) return;
        setAllRemainingRoles(await res.json());
    }

    const handleUserSelection = function (e) {
        const selectedUser = lowerRoleUsers.find(lru => lru.id == e.target.value);
        setSelectedUser(selectedUser);
        if (!selectedUser) {
            setAllRemainingRoles([]);
            return;
        }
        getAllRemainingRoles(selectedUser.roleId);
    }

    const handleUpdateClick = async function () {
        if (!selectedRoleId || !selectedUser) {
            toast.error("Please select one.");
            return;
        }

        const changeRoleDTO = {
            userId: selectedUser.id,
            newRoleId: selectedRoleId,
        }

        const res = await fetch(`http://localhost:5109/api/User/ChangeRole`, {
            method: "PUT",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(changeRoleDTO)
        });

        const data = await res.json();
        console.log(data);
        if (!res.ok) return;

        toast.success("Role has changed");

        setSelectedUser({});
        setSelectedRoleId(0);
        setLowerRoleUsers([]);
        getLowerRoleUsers();
        setAllRemainingRoles([]);
    }

    useEffect(() => {
        getLowerRoleUsers();
    }, []);

    const rightPanel = (
        <div className="grow flex flex-col justify-start items-center px-12 py-5">
            <div className="mb-3 w-full">
                <label htmlFor="userToChange" className="block text-white font-medium mb-1">Select user</label>
                <select name="userToChange" id="userToChange" className="px-4 py-2 bg-gray-700 text-white block w-full focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2 rounded" onChange={e => handleUserSelection(e)}>
                    <option value="">Select someone</option>
                    {lowerRoleUsers.map((lru, index) => (
                        <option key={index} value={lru.id}>{lru.name + " - " + lru.roleName}</option>
                    ))}
                </select>
            </div>
            <div className="mb-7 w-full">
                <label htmlFor="role" className="block text-white font-medium mb-1">Role</label>
                <select name="role" id="role" className="px-4 py-2 bg-gray-700 text-white block w-full focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2 rounded" onChange={e => setSelectedRoleId(e.target.value)}>
                    <option value="">Select another role</option>
                    {allRemainingRoles.map((arr, index) => (
                        <option key={index} value={arr?.id}>{arr?.name}</option>
                    ))}
                </select>
            </div>
            <div className="mb-3 self-end">
                <button onClick={handleUpdateClick} className="border border-transparent inline-block rounded px-6 py-3 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900">Update</button>
            </div>
        </div>
    );

    return (<GeneralOperationsPage leftPanel={(<GeneralOperationsCard />)} rightPanel={rightPanel} />)
}

export default ChangeRoleOP