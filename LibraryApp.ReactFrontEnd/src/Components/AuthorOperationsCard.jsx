import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"

function AuthorOperationsCard() {

    const items = (
        <>
            <li className="">
                <button className="btn bg-custom-primary" href="#">See pending book creation requests</button>
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