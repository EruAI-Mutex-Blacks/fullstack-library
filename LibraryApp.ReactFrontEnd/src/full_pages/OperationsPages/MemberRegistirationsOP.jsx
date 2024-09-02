import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useFetch } from "../../Context/FetchContext";
import DefaultTableTemplate from "../../Components/DefaultTableTemplate";
import { useUser } from "../../AccountOperations/UserContext";


function MemberRegistirationsOP() {
    const [pendingUsers, setPendingUsers] = useState([]);
    const { fetchData } = useFetch();
    const { user } = useUser();

    const fetchRegistirations = async function () {
        const data = await fetchData("/api/User/MemberRegistirations", "GET");
        setPendingUsers(data ?? []);
    }

    useEffect(() => {
        fetchRegistirations();
    }, []);

    const handleApproveRejectClick = async (userId, isApproved) => {
        const regisDTO = {
            userId: userId,
            isApproved: isApproved,
            staffId: user.id,
        }

        fetchData("/api/User/SetRegistirationRequest", "PUT", regisDTO)
            .then(() => {
                fetchRegistirations();
            });
    }

    const headersArray = ["Full name", "Username", "Gender", "Birthdate", "Actions"];
    const datasArray = pendingUsers.map((pu, index) => [
        pu.name + " " + pu.surname,
        pu.username,
        pu.gender,
        new Date(pu.birthDate).toLocaleDateString("en-us"),
        (<ul key={index}  className="flex justify-start">
            <li className="me-2"><Link onClick={() => { handleApproveRejectClick(pu.id, true) }} className="border border-transparent inline-block rounded px-4 py-2 bg-green-800 hover:bg-green-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-green-950">Approve</Link></li>
            <li className="me-2"><Link onClick={() => { handleApproveRejectClick(pu.id, false) }} className="border border-transparent inline-block rounded px-4 py-2 bg-red-800 hover:bg-red-900 hover:border-gray-400 transition-all duration-100 text-gray-300 active:bg-red-950">Reject</Link></li>
        </ul>),
    ]);

    const rightPanel = (
        <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
    )
    return (<GeneralOperationsPage leftPanel={(<MemberOperationsCard />)} rightPanel={rightPanel} />)
}

export default MemberRegistirationsOP