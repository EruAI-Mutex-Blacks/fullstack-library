import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"


function MemberRegistirationsOP() {

    //member registiration requests from users that has sent to currently logged in staff
    const seedPerson = {
        fullName: "turko",
        username: "tkrkrkr",
        email: "fefefew",
    }

    const seedPersons = [];
    seedPersons.push(seedPerson);
    seedPersons.push(seedPerson);
    seedPersons.push(seedPerson);
    seedPersons.push(seedPerson);
    seedPersons.push(seedPerson);
    seedPersons.push(seedPerson);

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
                    <th>User's full name</th>
                    <th>Username</th>
                    <th>Email</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {seedPersons.map(u => (
                    <tr>
                        <td>{u.fullName}</td>
                        <td>{u.username}</td>
                        <td>{u.email}</td>
                        <td>
                            <ul className="list-inline d-flex justify-content-start">
                                <li className="me-2"><Link onClick={() => { handleApproveClick(u) }} className={`py-1 px-2 btn btn-success`}>Approve</Link></li>
                                <li className="me-2"><Link onClick={() => { handleRejectClick(u) }} className={`py-1 px-2 btn btn-danger`}>Reject</Link></li>
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