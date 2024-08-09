import { Link } from "react-router-dom";
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"

function AuthorOperationsCard() {

    //TODO new table required for book creations

    const items = (
        <>
            <li className="">
                <Link className="btn bg-custom-primary" to="/BookCreateRequests">See pending book creation requests</Link>
            </li>
        </>
    );

    return (
        <>
            <HomeGeneralOperationsCard title="Author operations" items={items} />
        </>
    )
}

export default AuthorOperationsCard