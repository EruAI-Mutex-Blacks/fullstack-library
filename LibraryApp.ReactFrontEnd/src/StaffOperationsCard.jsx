import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"

function StaffOperationsCard() {
    const items = (
        <>
            <li className="mb-4">
                <button className="btn bg-custom-primary" href="#">Change role of someone</button>
            </li>
            <li className="">
                <button className="btn bg-custom-primary" href="#">Punish a staff</button>
            </li>
        </>
    )

    return (
        <HomeGeneralOperationsCard title="Staff Operations" items={items} />
    )
}

export default StaffOperationsCard