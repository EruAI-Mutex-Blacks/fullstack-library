import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { toast } from "react-toastify";

function WriteBook() {
    const location = useLocation();
    const bookId = new URLSearchParams(location.search).get("bookId");
    const [book, setBook] = useState({});
    const [pageContent, setPageContent] = useState("");
    const [pageNum, setPageNum] = useState(0);

    const fetchBook = async function () {
        const res = await fetch("http://localhost:5109/api/Book/GetBook?bookId=" + bookId, {
            method: "GET",
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }

        });

        if (!res.ok) return;
        const data = await res.json();
        data.pages.sort((a, b) => a.pageNumber - b.pageNumber);
        setBook(data);
    };

    useEffect(() => {
        fetchBook();
    }, []);

    const handleSaveClick = async function () {
        if (!pageContent || !pageNum) {
            toast.error("Please fill all the fields.");
            return;
        }

        if (book.pages.find(p => p.pageNumber == pageNum)) {
            toast.error("There is a page with that number");
            return;
        }

        const pageDTO = {
            bookId: bookId,
            content: pageContent,
            pageNumber: pageNum,
        };

        const res = await fetch("http://localhost:5109/api/Book/WritePage", {
            method: "POST",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(pageDTO),
        });

        if (!res.ok) {
            const data = await res.json();
            toast.error(data?.message ?? "An error occured");
            return;
        }
        toast.success("Page saved");
        setPageContent("");
        setPageNum(0);
        await fetchBook();
    };

    const handleFileSelection = function (e) {
        const file = e.target.files[0];
        console.log(file);

        if (file) {
            const reader = new FileReader();
            reader.readAsText(file);
            reader.onload = () => {
                setPageContent(prev => prev + reader.result);
            }
        }
    }

    return (
        <div className="flex flex-col container mx-auto px-16  grow items-center text-gray-200">
            <h3 className="mb-2 mt-4 p-0 text-3xl">{book?.title}</h3>
            <div className="mb-5 p-2 bg-gray-500 rounded flex text-center grow container">
                <div className="grow flex flex-col col-9">
                    <div className="flex justify-center items-center bg-gray-600 border-b border-gray-300 pt-3 pb-2 rounded mb-2">
                        <div className="flex items-center">
                            <h5 className="text-xl">Page</h5><input type="number" className="ms-4 px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" min={0} placeholder="Enter the page number" value={pageNum} onChange={e => setPageNum(e.target.value)} />
                        </div>
                    </div>
                    <div className="rounded flex mb-2 grow ">
                        <textarea className="px-4 py-2 w-full bg-gray-700 grow text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" placeholder="Enter the content of page" maxLength={1250} style={{ resize: "none" }} onChange={e => setPageContent(e.target.value)} value={pageContent}></textarea>
                    </div>
                    <div className="flex justify-end ">
                        <label className="self-center me-2 hover:cursor-pointer" htmlFor="fileUpload">Import text from .txt file:</label>
                        <input class="p-1 bg-gray-600 rounded hover:ring-2 hover:cursor-pointer transition-all duration-100 active:bg-gray-700 self-center me-2" id="fileUpload" type="file" onChange={e => handleFileSelection(e)} accept=".txt" />
                        <button className="border border-transparent inline-block rounded px-6 py-2 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900 self-end" onClick={handleSaveClick}>Save</button>
                    </div>
                </div>

                <div className="ps-2">
                    <div className="flex text-xl bg-gray-600 border-b border-gray-300 px-3 pt-4 pb-4 rounded mb-2">
                        <h5 className="">Current pages</h5>
                    </div>
                    <div className="flex justify-center flex-wrap p-3 bg-gray-600 rounded">
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