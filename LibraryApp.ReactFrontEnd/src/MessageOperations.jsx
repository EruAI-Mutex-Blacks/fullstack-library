

function MessageOperations() {
    return (
        <div className="text-center d-flex flex-column bg-custom-secondary rounded p-4 mt-5">
            <div className="text-white mb-3 pt-1">
                <h3>Message Operations</h3>
                <hr />
            </div>
            <div className="flex-fill d-flex flex-column ">
                <ul className="list-inline flex-fill d-flex flex-column  align-items-center">
                    <li className="mb-4">
                        <button className="btn bg-custom-primary" href="#">Send message</button>
                    </li>
                    <li className="">
                        <button className="btn bg-custom-primary" href="#">View inbox</button>
                    </li>
                </ul>
            </div>
        </div>
    )
}

export default MessageOperations