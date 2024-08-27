import { useNavigate, Link, Navigate } from "react-router-dom";
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"
import { useState } from "react";
import CardLink from "../CardLink";

function BookOperationsCard({ onSearch }) {

    const [bookQuery, setBookQuery] = useState('');
    const nav = useNavigate();

    function handleInputChange(e) {
        setBookQuery(e.target.value);
    }

    const searchBookLink = "/SearchBook?book=" + bookQuery;
    function handleSearchClick() {
        if (onSearch) {
            onSearch(bookQuery);
            nav(searchBookLink);
        }
        else
            nav(searchBookLink);
    }


    const items = (
        <>
            <li className="mb-4">
                <div className="flex grow ">
                    
                    <input type="text" className="px-4 py-2 rounded-s bg-white border border-gray-300 focus:ring-rose-600 focus:border-rose-600 focus:border-2 focus:outline-none" placeholder="Book's name" onChange={handleInputChange} />
                    <button className="rounded-e bg-rose-600 border border-transparent inline-block px-5 py-1 hover:bg-rose-700 transition-all duration-300 text-white/80 font-semibold hover:text-white hover:border-white ease-in-out" onClick={handleSearchClick}>Search book</button>
                </div>
            </li>
            <li className="">
                <CardLink url="/BorrowedBooks" text="View borrowed books"/>
            </li>
        </>
    );

    return (
        <HomeGeneralOperationsCard title="Book Operations" items={items} />
    )
}

export default BookOperationsCard