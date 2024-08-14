import { useNavigate, Link } from "react-router-dom";
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"
import { useState } from "react";

function BookOperationsCard() {
    const nav = useNavigate();

    const [bookQuery, setBookQuery] = useState('');

    function handleInputChange(e) {
        setBookQuery(e.target.value);
    }

    const searchBookLink = "/SearchBook?book=" + bookQuery;

    const items = (
        <>
            <li className="mb-4">
                <div className="input-group">
                    <input type="text" className="form-control" placeholder="Book's name" onChange={handleInputChange} />
                    <Link className="btn bg-custom-primary" to={searchBookLink}>Search book</Link>
                </div>
            </li>
            <li className="">
                <Link className="btn bg-custom-primary" to="/BorrowedBooks">View borrowed books</Link>
            </li>
        </>
    );

    return (
        <HomeGeneralOperationsCard title="Book Operations" items={items} />
    )
}

export default BookOperationsCard