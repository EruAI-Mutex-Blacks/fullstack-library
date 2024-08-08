import HomeGeneralOperationsCard from "../Components/HomeGeneralOperationsCard"


function GeneralOperationsPage(props) {
    return (
        //TODO burası component drilling oluyor sanırım bunu ilerde düzeltebilirim.
        <div className="d-flex flex-fill flex-row justify-content-between">
            <div className="w-25 text-break">
                <HomeGeneralOperationsCard title={props.title + "qwdqwdqwdqwdqwdqwdqwdqd"} items={props.items} />
            </div>
            <div className=" flex-fill m-5 p-4 border border-dark rounded">
                {props.rightPanel}
            </div>
        </div>
    )
}

export default GeneralOperationsPage