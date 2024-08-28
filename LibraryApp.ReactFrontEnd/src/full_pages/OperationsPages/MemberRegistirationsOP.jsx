import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useFetch } from "../../Context/FetchContext";


function MemberRegistirationsOP() {

    //TODO refactor code use usecontext for fetching and get all methods outside of our component function
    const [pendingUsers, setPendingUsers] = useState([]);
    const { fetchData } = useFetch();


    const fetchRegistirations = async function () {
        const data = await fetchData("/api/User/MemberRegistirations", "GET");
        setPendingUsers(data ?? []);
    }

    useEffect(() => {
        fetchRegistirations();
    }, []);

    const handleClick = async (user, isApproved) => {
        const regisDTO = {
            userId: user.id,
            isApproved: isApproved,
        }

        fetchData("/api/User/SetRegistirationRequest", "PUT", regisDTO)
            .then(() => {
                fetchRegistirations();
            });
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