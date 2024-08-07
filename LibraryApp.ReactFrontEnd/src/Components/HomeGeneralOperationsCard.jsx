import { useNavigate } from "react-router-dom"

function HomeGeneralOperationsCard(props) {
    const id = props.title.replace(" ", "");

    //TODO animasyon eklemeyi falan sonra düşünürüm.
    //burdan hepsine operations page ini açtıracak bir method eklerim event olarak 
    //daha sonra her birinden özel olarak her butonun ne yapacağını da eklerim event olarak.

    return (
        <div id={id} className="text-center d-flex flex-column bg-custom-secondary rounded p-4 my-5">
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

export default HomeGeneralOperationsCard;