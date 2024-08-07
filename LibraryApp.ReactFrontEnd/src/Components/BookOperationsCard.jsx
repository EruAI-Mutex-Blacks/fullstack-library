import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"

//TODO operations diye parent component oluştur ve ona mousedown eventi ekleyip position ayarla animasyon olarak. aynı zamanda solda tüm sayfayı kaplayabilir 100 vh şeklinde. alttaki componentlarda ise buton clicklerini handlelarsın.
function BookOperationsCard() {
    const items = (
        <>
            <li className="mb-4">
                <div className="input-group">
                    <input type="text" name="" id="" className="form-control" placeholder="Book's name" />
                    <button className="btn bg-custom-primary" href="#">Search book</button>
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