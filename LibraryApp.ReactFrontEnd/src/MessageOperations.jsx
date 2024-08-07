import OperationsCard from "./OperationsCard"


function MessageOperations() {
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
        <OperationsCard title="Message Operations" items={items} />
    )
}

export default MessageOperations