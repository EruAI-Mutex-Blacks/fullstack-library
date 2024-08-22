import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext";


function PunishMemberOP() {
    const [lowerRoleUsers, setLowerRoleUsers] = useState([]);
    const { user } = useUser();
    const [selectedUser, setSelectedUser] = useState({});

    const getLowerRoleUsers = async function () {
        const res = await fetch(`http://localhost:5109/api/User/GetUsersForPunishment?roleId=${user.roleId}&userId=${user.id}`, {
            method: "GET"
        });

        if (!res.ok) return;

        setLowerRoleUsers(await res.json());
    }

    useEffect(() => {
        getLowerRoleUsers();
    }, []);

    const handleSelectionChange = function (e) {
        if (e.target.value) {
            setSelectedUser(lowerRoleUsers.find(lru => lru.id == e.target.value));
            console.log(lowerRoleUsers.find(lru => lru.id == e.target.value));
        }
    }

    const handlePunishClick = function (id) {
    }

    const rightPanel = (

        <div className="flex-fill">
            <div className="mb-3 border-bottom border-dark p-3 border rounded">
                <label htmlFor="sendingTo" className="form-label">Select user to view punishment status</label>
                <select id="sendingTo" className="form-select" onChange={e => handleSelectionChange(e)}>
                    <option value="">Select someone</option>
                    {lowerRoleUsers.map((lru, index) => (
                        <option key={index} value={lru.id}>{lru.name + " - " + lru.roleName}</option>
                    ))}
                </select>
            </div>
            <div className="row m-0 p-0">
                <div className="col border border-dark rounded p-3 me-2">
                    <h5 className="border-bottom border-dark pb-1">Punish user</h5>
                    <form>
                        <div className="my-3 px-2 row">
                            <div className="col text-start pe-0">
                                <p>Delayed days</p>
                                <p>{6} </p>
                            </div>
                            <p className="col-1 align-self-center p-0 m-0">X</p>
                            <div className=" col text-center ">
                                <label className="form-label" htmlFor="finePerDay">Fine amount per day ($)</label>
                                <input id="finePerDay" className="form-control d-inline" type="number" min={0} step={0.1} />
                            </div>
                            <p className="col-1 align-self-center ps-3 m-0">=</p>
                            <div className="col text-end ps-0">
                                <p>Total fine</p>
                                <p>{"15$"}</p>
                            </div>
                        </div>
                        <div className="mb-0">
                            <label htmlFor="message" className="form-label">Cause & details of punishment</label>
                            <div className="d-flex align-items-center">
                                <textarea type="text" className="form-control me-2" rows={2} style={{ resize: "none" }}></textarea>
                                <Link onClick={() => { handlePunishClick(id) }} className="btn btn-danger py-2 px-4">Punish</Link>
                            </div>
                        </div>
                        <div className="d-flex justify-content-end">
                        </div>
                    </form>
                </div>
                <div className="col border border-dark rounded p-3 ms-2">
                    <h5 className="border-bottom border-dark pb-1">Punishment status of {selectedUser.name}</h5>
                    <div className="my-3 mb-2">
                        <label htmlFor="isPunished" className="form-label  me-2">Is user punished?</label>
                        <input type="checkbox" id="isPunished" name="isPunished" className="form-check-input" checked={selectedUser.isPunished} />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="fineAmount" className="form-label">User's current total fine</label>
                        <input id="finePerDay" className="form-control" type="number" value={selectedUser.fineAmount} min={0} step={0.1} />
                    </div>
                    <Link onClick={() => { handlePunishClick(id) }} className="btn btn-success py-2 px-4">Update</Link>
                </div>
            </div>
        </div>
    );
    return (<GeneralOperationsPage leftPanel={(<MemberOperationsCard />)} rightPanel={rightPanel} />)
}

export default PunishMemberOP