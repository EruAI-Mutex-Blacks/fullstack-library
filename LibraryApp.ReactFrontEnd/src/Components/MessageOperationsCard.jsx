import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"


function MessageOperationsCard() {
    const items = (
        <>
            <li className="mb-4">
                <button className="btn bg-custom-primary" href="#">Send message</button>
            </li>
            <li className="">
                <button className="btn bg-custom-primary" href="#">View inbox</button>
            </li>
        </>)

    return (
        <HomeGeneralOperationsCard title="Message Operations" items={items} />
    )
}

export default MessageOperationsCard