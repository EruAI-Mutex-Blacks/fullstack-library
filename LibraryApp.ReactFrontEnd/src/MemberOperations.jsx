

function MemberOperations() {
    return (
        <div className="text-center d-flex flex-column bg-custom-secondary rounded p-4 mt-5">
            <div className="text-white mb-3 pt-1">
                <h3>Member Operations</h3>
                <hr />
            </div>
            <div className="flex-fill d-flex flex-column ">
                <ul className="list-inline flex-fill d-flex flex-column  align-items-center">
                    <li className="mb-4">
                        <button className="btn bg-custom-primary" href="#">See pending borrow requests</button>
                    </li>
                    <li className="mb-4">
                        <button className="btn bg-custom-primary" href="#">Approve member registiration</button>
                    </li>
                    <li className="">
                        <button className="btn bg-custom-primary" href="#">Punish a member</button>
                    </li>
                </ul>
            </div>
        </div>
    )
}

export default MemberOperations