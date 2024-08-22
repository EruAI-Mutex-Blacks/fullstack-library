import { Link } from "react-router-dom"
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"

function StaffOperationsCard() {
    const items = (
        <>
            <li className="mb-4">
                <Link className="btn bg-custom-primary" to="/ChangeRole">Change role of someone</Link>
            </li>
            <li className="">
                <Link className="btn bg-custom-primary" to="/PunishStaff">Punish a staff</Link>
            </li>
        </>
    )

    return (
        <HomeGeneralOperationsCard title="Staff Operations" items={items} />
    )
}

export default StaffOperationsCard