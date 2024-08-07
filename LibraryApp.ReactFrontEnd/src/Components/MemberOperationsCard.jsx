import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"


function MemberOperationsCard() {
    const items = (
        <>
            <li className="mb-4">
                <button className="btn bg-custom-primary" href="#">See pending borrow requests</button>
            </li>
            <li className="mb-4">
                <button className="btn bg-custom-primary" href="#">Approve member registiration</button>
            </li>
            <li className="">
                <button className="btn bg-custom-primary" href="#">Punish a member</button>
            </li>
        </>
    )

    return (
        <HomeGeneralOperationsCard title="Member Operations" items={items} />
    )
}

export default MemberOperationsCard