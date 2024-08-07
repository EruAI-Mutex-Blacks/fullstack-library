import OperationsCard from "./OperationsCard"

function StaffOperations() {
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
        <OperationsCard title="Staff Operations" items={items} />
    )
}

export default StaffOperations