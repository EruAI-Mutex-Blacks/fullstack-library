import { Link } from "react-router-dom";
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"


function MemberOperationsCard() {

    const items = (
        <>
            <li className="mb-4">
                <Link className="btn bg-custom-primary" to="/BorrowRequets">See pending borrow requests</Link>
            </li>
            <li className="mb-4">
                <Link className="btn bg-custom-primary" to="/MemberRegistirations">Approve member registiration</Link>
            </li>
            <li className="">
                <Link className="btn bg-custom-primary" to="/PunishMember">Punish a member</Link>
            </li>
        </>
    )

    return (
        <HomeGeneralOperationsCard title="Member Operations" items={items} />
    )
}

export default MemberOperationsCard