import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { toast } from "react-toastify";


function MemberRegistirationsOP() {

    //TODO wrap all fetchs with try catch and give user feedback about all actions
    const [pendingUsers, setPendingUsers] = useState([]);

    const fetchRegistirations = async function () {
        const res = await fetch("http://localhost:5109/api/User/MemberRegistirations", {
            method: "GET", headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }

        });
        if (!res.ok) return;

        setPendingUsers(await res.json());
    }

    useEffect(() => {
        fetchRegistirations();
    }, []);

    async function handleClick(user, isApproved) {

        const regisDTO = {
            userId: user.id,
            isApproved: isApproved,
        }

        const res = await fetch("http://localhost:5109/api/User/SetRegistirationRequest", {
            method: "PUT",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(regisDTO),
        });

        if (!res.ok) return;

        const data = await res.json();

        if (isApproved) toast.success("Request approved");
        else toast.error("Request rejected");

        fetchRegistirations();
    }

    const rightPanel = (
        <div class="grow overflow-x-auto bg-gray-800 border border-gray-300">
            <table class="w-full text-sm text-left rtl:text-right text-gray-400">
                <thead class="text-xs uppercase bg-gray-700 text-gray-400">
                    <tr>
                        <th className="px-6 py-4">Full name</th>
                        <th className="px-6 py-4">Username</th>
                        <th className="px-6 py-4">Gender</th>
                        <th className="px-6 py-4">Birthdate</th>
                        <th className="px-6 py-4">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {pendingUsers.map((pu, index) => (
                        <tr key={index} className="border-b bg-gray-800 border-gray-700">
                            <td className="px-6 py-4 font-medium whitespace-nowrap text-white">{pu.name + " " + pu.surname}</td>
                            <td className="px-6 py-4">{pu.username}</td>
                            <td className="px-6 py-4">{pu.gender}</td>
                            <td className="px-6 py-4">{new Date(pu.birthDate).toLocaleDateString("en-us")}</td>
                            <td className="px-6 py-4">
                                <ul className="flex justify-start">
                                    <li className="me-2"><Link onClick={() => { handleClick(pu, true) }} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Approve</Link></li>
                                    <li className="me-2"><Link onClick={() => { handleClick(pu, false) }} className="border border-transparent inline-block rounded px-4 py-2 bg-red-800 hover:bg-red-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-red-950">Reject</Link></li>
                                </ul>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table >
        </div>
    )
    return (<GeneralOperationsPage leftPanel={(<MemberOperationsCard />)} rightPanel={rightPanel} />)
}

export default MemberRegistirationsOP