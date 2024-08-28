import { useNavigate } from "react-router-dom"

function HomeGeneralOperationsCard(props) {

    return (
        <div className="text-center h-full flex flex-col bg-gray-800 p-8 px-4 pb-16">
            <div className="text-white border-b mb-6">
                <h3 className="text-2xl mb-2">{props.title}</h3>
            </div>
            <div className="grow flex flex-col">
                <ul className="grow flex flex-col items-center space-y-2">
                    {props.items}
                </ul>
            </div>
        </div>
    );
}

export default HomeGeneralOperationsCard;