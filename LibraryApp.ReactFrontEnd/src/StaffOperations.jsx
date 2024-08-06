

function StaffOperations() {
    return (
        <div className="text-center d-flex flex-column bg-custom-secondary rounded p-4 my-5">
            <div className="text-white mb-3 pt-1">
                <h3>Staff Operations</h3>
                <hr />
            </div>
            <div className="flex-fill d-flex flex-column ">
                <ul className="list-inline flex-fill d-flex flex-column  align-items-center">
                    <li className="mb-4">
                        <button className="btn bg-custom-primary" href="#">Change role of someone</button>
                    </li>
                    <li className="">
                        <button className="btn bg-custom-primary" href="#">Punish a staff</button>
                    </li>
                </ul>
            </div>
        </div>
    )
}

export default StaffOperations