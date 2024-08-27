import HomeGeneralOperationsCard from "../../Components/OperationsCards/HomeGeneralOperationsCard"


function GeneralOperationsPage(props) {
    return (
        //TODO burası component drilling oluyor sanırım bunu ilerde düzeltebilirim.
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