import OperationsCard from "./OperationsCard"

function AuthorOperations() {

    const items = (
        <>
            <li className="">
                <button className="btn bg-custom-primary" href="#">See pending book creation requests</button>
            </li>
        </>
    );

    return (
        <>
            <OperationsCard title="Author operations" items={items} />
        </>
    )
}

export default AuthorOperations