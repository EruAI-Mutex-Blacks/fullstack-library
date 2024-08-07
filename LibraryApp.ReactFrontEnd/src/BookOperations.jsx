
//TODO operations diye parent component oluştur ve ona mousedown eventi ekleyip position ayarla animasyon olarak. aynı zamanda solda tüm sayfayı kaplayabilir 100 vh şeklinde. alttaki componentlarda ise buton clicklerini handlelarsın.
function BookOperations() {
    return (
        <div className="text-center d-flex flex-column bg-custom-secondary rounded p-4 mt-5">
            <div className="text-white mb-3 pt-1">
                <h3>Book Operations</h3>
                <hr />
            </div>
            <div className="flex-fill d-flex flex-column ">
                <ul className="list-inline flex-fill d-flex flex-column  align-items-center">
                    <li className="mb-4">
                        <div className="input-group">
                            <input type="text" name="" id="" className="form-control" placeholder="Book's name" />
                            <button className="btn bg-custom-primary" href="#">Search book</button>
                        </div>
                    </li>
                    <li className="">
                        <button className="btn bg-custom-primary" href="#">View borrowed books</button>
                    </li>
                </ul>
            </div>
        </div>
    )
}

export default BookOperations