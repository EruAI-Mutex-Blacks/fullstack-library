

function OperationsCard(props) {
    return (
        <div className="text-center d-flex flex-column bg-custom-secondary rounded p-4 my-5">
            <div className="text-white mb-3 pt-1">
                <h3>{props.title}</h3>
                <hr />
            </div>
            <div className="flex-fill d-flex flex-column ">
                <ul className="list-inline flex-fill d-flex flex-column  align-items-center">
                    {props.items}
                </ul>
            </div>
        </div>
    );
}

export default OperationsCard;