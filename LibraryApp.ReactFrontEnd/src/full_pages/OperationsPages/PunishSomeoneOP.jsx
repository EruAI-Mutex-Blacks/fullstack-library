import { Link } from "react-router-dom";
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext";
import GeneralOperationsCard from "../../Components/OperationsCards/GeneralOperationsCard";
import { toast } from "react-toastify";

function PunishSomeoneOP() {
    const [lowerRoleUsers, setLowerRoleUsers] = useState([]);
    const { user } = useUser();
    const [selectedUser, setSelectedUser] = useState();
    const [delayedDays, setDelayedDays] = useState(0);
    const [finePerDay, setFinePerDay] = useState(0);
    const [details, setDetails] = useState("");
    const [totalFine, setTotalFine] = useState(0);

    const fetchLowerRoleUsers = async function () {
        const res = await fetch(`http://localhost:5109/api/User/GetUsersOfLowerRole?roleId=${user.roleId}&userId=${user.id}`, {
            method: "GET",
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }

        });

        if (!res.ok) return;

        setLowerRoleUsers(await res.json());
    }

    useEffect(() => {
        fetchLowerRoleUsers();
    }, []);

    const handleSelectionChange = function (e) {
        setDelayedDays(0);
        setFinePerDay(0);
        setTotalFine(0);
        setSelectedUser(lowerRoleUsers.find(lru => lru.id == e.target.value));
    }

    const handleInputChange = function (e, callback) {
        callback(prev => prev = e.target.value);
    }

    //FIXME for example 4 is the fine at first then i make it 6 directly then i changed delayeddays calculation it is 0.4. it is making total fine 4.4 instead of 6.4
    useEffect(() => {
        setTotalFine((selectedUser?.fineAmount ?? 0) + Math.round(delayedDays * finePerDay * 10) / 10);
    }, [delayedDays, finePerDay, selectedUser])

    const handleUpdateClick = async function (e) {
        e.preventDefault();

        if (!selectedUser) {
            toast.error("Please select someone");
            return;
        }

        if (selectedUser.fineAmount === totalFine) {
            toast.error("Nothing changed");
            return;
        }

        const punishUserDTO = {
            userId: selectedUser.id,
            punisherId: user.id,
            isPunished: totalFine > 0,
            fineAmount: totalFine,
            details: details,
        }

        const res = await fetch(`http://localhost:5109/api/User/SetPunishment`, {
            method: "PUT",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(punishUserDTO),
        });

        const data = await res.json();
        console.log(data);
        if (!res.ok) return;
        toast.success(selectedUser.isPunished ? "Updated." : "User punished");
        setDelayedDays(0);
        setFinePerDay(0);
        setTotalFine(0);
        setLowerRoleUsers([]);
        setDetails("");
        setSelectedUser();
        fetchLowerRoleUsers();
    }

    const rightPanel = (
        <div className="grow flex flex-col justify-start px-12 py-4">
            <div className="mb-3 p-3 border rounded">
                <label htmlFor="sendingTo" className="block text-white font-medium mb-1">Select user to view punishment status</label>
                <select id="sendingTo" className="px-4 py-2 bg-gray-700 text-white block w-full focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2 rounded" onChange={e => handleSelectionChange(e)}>
                    <option value="">Select someone</option>
                    {lowerRoleUsers.map((lru, index) => (
                        <option key={index} value={lru.id}>{lru.name + " - " + lru.roleName}</option>
                    ))}
                </select>
            </div>
            <div className="grow border rounded p-3 flex">
                <div className="flex flex-col grow">
                    <h5 className="border-b pb-1 text-white font-bold">Punishment of {selectedUser?.name}</h5>
                    <form className="flex flex-col grow">
                        <div className="flex mb-3">
                            <div className="my-3 mb-2 grow flex">
                                <label htmlFor="isPunished" className="text-white font-medium mb-1 me-2">Is user already punished?</label>
                                <input type="checkbox" id="isPunished" name="isPunished" className="mt-1 w-4 h-4 text-blue-600  focus:ring-blue-700 ring-offset-gray-800 focus:ring-2" checked={selectedUser?.isPunished ?? false} onChange={e => selectedUser?.isPunished} />
                            </div>
                        </div>
                        <div className="mb-3 flex space-x-5 justify-between">
                            <div className="self-center text-start">
                                <label className="text-white font-medium mb-1" htmlFor="delayedDays">Delayed days</label>
                                <input id="delayedDays" value={delayedDays} className="px-4 py-2 w-full bg-gray-700 text-white rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="number" min={0} step={1} onChange={e => handleInputChange(e, setDelayedDays)} />
                            </div>
                            <div className="text-center self-center">
                                <label className="text-white font-medium mb-1" htmlFor="finePerDay">Fine amount per day ($)</label>
                                <input id="finePerDay" className="px-4 py-2 w-full bg-gray-700 text-white rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="number" min={0} step={0.1} value={finePerDay} onChange={e => handleInputChange(e, setFinePerDay)} />
                            </div>
                            <div className="self-center text-end">
                                <label htmlFor="fineAmount" className="text-white mb-1 font-bold">User's final total fine</label>
                                <input id="finePerDay" className="px-4 py-2 w-full bg-gray-700 text-white rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="number" value={totalFine} onChange={e => setTotalFine(e.target.value)} min={0} step={0.1} />
                            </div>
                        </div>
                        <div className="mb-3 grow flex flex-col">
                            <label htmlFor="message" className="block text-white font-medium mb-1">Cause & details of punishment</label>
                            <textarea value={details} type="text" className="grow px-4 py-2 w-full bg-gray-700 text-white rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2 me-2" style={{ resize: "none" }} onChange={e => handleInputChange(e, setDetails)}></textarea>
                        </div>
                        <button onClick={(e) => { handleUpdateClick(e) }} className={`self-end border border-transparent inline-block rounded px-6 py-3 bg-${selectedUser?.isPunished ? "green" : "red"}-700 hover:bg-${selectedUser?.isPunished ? "green" : "red"}-800 hover:ring-${selectedUser?.isPunished ? "green" : "red"}-500 hover:ring-2 transition-all duration-100 text-white active:bg-${selectedUser?.isPunished ? "green" : "red"}-900`}>{selectedUser?.isPunished ? "Update" : "Punish"}</button>
                    </form>
                </div>
            </div>
        </div>
    );
    return (<GeneralOperationsPage leftPanel={(<GeneralOperationsCard />)} rightPanel={rightPanel} />)
}

export default PunishSomeoneOP