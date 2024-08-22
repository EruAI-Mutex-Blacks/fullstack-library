import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";


function MemberRegistirationsOP() {

    //TODO wrap all fetchs with try catch and give user feedback about all actions
    const [pendingUsers, setPendingUsers] = useState([]);

    const fetchRegistirations = async function () {
        const res = await fetch("http://localhost:5109/api/User/MemberRegistirations", {
            method: "GET"
        });
        if (!res.ok) return;

        setPendingUsers(await res.json());
    }

    useEffect(() => {
        fetchRegistirations();
    }, []);

    function handleApproveClick(user) {
        window.alert("approved");
    }

    function handleRejectClick(user) {
        window.alert("rejected");
    }

    const rightPanel = (
        <table className="table table-light table-striped table-hover flex-fill">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Full name</th>
                    <th>Username</th>
                    <th>Gender</th>
                    <th>Birthdate</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {pendingUsers.map((r, index) => (
                    <tr key={index}>
                        <td>{r.id}</td>
                        <td>{r.name + " " + r.surname}</td>
                        <td>{r.username}</td>
                        <td>{r.gender}</td>
                        <td>{new Date(r.birthDate).toLocaleDateString("en-us")}</td>
                        <td>
                            <ul className="list-inline d-flex justify-content-start">
                                <li className="me-2"><Link onClick={() => { handleApproveClick(r) }} className={`py-1 px-2 btn btn-success`}>Approve</Link></li>
                                <li className="me-2"><Link onClick={() => { handleRejectClick(r) }} className={`py-1 px-2 btn btn-danger`}>Reject</Link></li>
                            </ul>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table >
    )
    return (<GeneralOperationsPage leftPanel={(<MemberOperationsCard />)} rightPanel={rightPanel} />)
}

export default MemberRegistirationsOP