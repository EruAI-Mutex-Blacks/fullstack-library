import { Link } from "react-router-dom"
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"
import CardLink from "../CardLink"

function GeneralOperationsCard() {
    const items = (
        <>
            <li className="mb-4">
                <CardLink url="/ChangeRole" text="Change role of someone" />
            </li>
            <li className="">
                <CardLink url="/PunishSomeone" text="Punish a user"/>
            </li>
        </>
    )

    return (
        <HomeGeneralOperationsCard title="General Operations" items={items} />
    )
}

export default GeneralOperationsCard