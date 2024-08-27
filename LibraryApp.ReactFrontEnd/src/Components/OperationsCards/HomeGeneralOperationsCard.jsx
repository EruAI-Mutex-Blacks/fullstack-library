import { useNavigate } from "react-router-dom"

function HomeGeneralOperationsCard(props) {
    //TODO animasyon eklemeyi falan sonra düşünürüm.

    return (
        <div className="text-center flex flex-col bg-gray-800 rounded p-4 ">
            <div className="text-white mb-3 pt-1 ">
                <h3 className="border-b">{props.title}</h3>
            </div>
            <div className="grow flex flex-col ">
                <ul className="grow flex flex-col items-center">
                    {props.items}
                </ul>
            </div>
        </div>
    );
}

export default HomeGeneralOperationsCard;