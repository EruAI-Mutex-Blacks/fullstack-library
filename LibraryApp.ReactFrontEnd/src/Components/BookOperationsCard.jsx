import { useNavigate } from "react-router-dom";
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"
import { useState } from "react";

//TODO operations diye parent component oluştur ve ona mousedown eventi ekleyip position ayarla animasyon olarak. aynı zamanda solda tüm sayfayı kaplayabilir 100 vh şeklinde. alttaki componentlarda ise buton clicklerini handlelarsın.
function BookOperationsCard() {
    const nav = useNavigate();

    const [bookQuery, setBookQuery]= useState('');

    function handleInputChange(e)
    {
        setBookQuery(e.target.value);
    }
    //TODO Direkt link kullan to ile birlikte niye button kullanıyosam
    function handleSearchBtnClick() {
        //pretending like getting array of books from api and sending it to search book page.
        //or send input to that route as query parameter and take data from api there.
        nav("/SearchBook?book=" + bookQuery);
    }

    const items = (
        <>
            <li className="mb-4">
                <div className="input-group">
                    <input type="text"  className="form-control" placeholder="Book's name" onChange={handleInputChange}/>
                    <button className="btn bg-custom-primary" onClick={handleSearchBtnClick}>Search book</button>
                </div>
            </li>
            <li className="">
                <button className="btn bg-custom-primary" href="#">View borrowed books</button>
            </li>
        </>
    );

    return (
        <HomeGeneralOperationsCard title="Book Operations" items={items} />
    )
}

export default BookOperationsCard