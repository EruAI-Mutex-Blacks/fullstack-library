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

    //TODO ayın elemanı
    //TODO üstlere de mesaj atılabilmesi
    //TODO profile page of authors
    //TODO Book covers
    //TODO better design mobile first
    //TODO animations
 
    const items = (
        <>
            <li className="mb-4">
                <div className="flex grow ">
                    <input type="text" className="px-4 py-3 text-sm w-full rounded-s bg-white border border-gray-300 focus:ring-2 focus:ring-rose-500 focus:outline-none hover:ring-rose-800 hover:ring-2" placeholder="Book's name" onChange={handleInputChange} />
                    <button className="text-xs rounded-e bg-rose-700 border border-transparent inline-block px-5 py-1 hover:bg-rose-800 transition-all duration-100 text-white/80 font-semibold hover:text-white hover:border-white ease-in-out active:bg-rose-900" onClick={handleSearchClick}>Search</button>
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