import HomeGeneralOperationsCard from "../../Components/OperationsCards/HomeGeneralOperationsCard"


function GeneralOperationsPage(props) {
    return (
        <div className="flex grow">
            <div className="w-1/6">
                {props.leftPanel}
            </div>
            <div className="flex grow">
                {props.rightPanel}
            </div>
        </div>
    )
}

export default GeneralOperationsPage