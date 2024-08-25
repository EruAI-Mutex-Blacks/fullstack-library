import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";

function WriteBook() {
    const location = useLocation();
    const bookId = new URLSearchParams(location.search).get("bookId");
    const [book, setBook] = useState({});
    const [pageContent, setPageContent] = useState("");
    const [pageNum, setPageNum] = useState(0);

    const fetchBook = async function () {
        const res = await fetch("http://localhost:5109/api/Book/GetBook?bookId=" + bookId, {
            method: "GET",
        });

        if (!res.ok) return;
        const data = await res.json();
        setBook(data);
    }

    useEffect(() => {
        fetchBook();
    }, []);

    return (
        <div className="d-flex flex-column flex-fill align-items-center">
            <h3 className="mb-2 mt-4 p-0 border-bottom border-dark">{book?.title}</h3>
            <div className="mb-5 p-2 bg-light rounded d-flex text-center flex-fill container">
                <div className="flex-fill col-9">
                    <div className="d-flex justify-content-center align-items-center bg-success-subtle border-bottom border-dark pt-3 pb-2 rounded mb-2">
                        <div className="d-flex align-items-center">
                            <h5>Page</h5><input type="number" className="ms-4 form-control d-inline" min={0} placeholder="Enter the page number" />
                        </div>
                    </div>
                    <div className="bg-success-subtle rounded d-flex mb-2">
                        <textarea className="rounded flex-fill bg-success-subtle px-4 py-3" placeholder="Enter the content of page" rows={9} maxLength={1250} style={{ resize: "none" }}></textarea>
                    </div>
                    <div className="d-flex justify-content-end">
                        <button className="btn btn-success px-5">Save</button>
                    </div>
                </div>

                <div className="col-3 ps-2">
                    <div className="d-flex justify-content-center bg-success-subtle border-bottom border-dark px-3 pt-4 pb-1 rounded mb-2">
                        <h5>Current pages</h5>
                    </div>
                    <div className="d-flex justify-content-center flex-wrap p-3 bg-success-subtle rounded">
                        {book?.pages?.map((p, index) => (
                            <p key={index} className="border border-dark rounded px-2 py-0 me-2 mb-2">{p.pageNumber}</p>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    )
}

export default WriteBook