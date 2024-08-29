import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { toast } from "react-toastify";
import { useFetch } from "../Context/FetchContext";

function WriteBook() {
    const location = useLocation();
    const bookId = new URLSearchParams(location.search).get("bookId");
    const [book, setBook] = useState({});
    const [pageContent, setPageContent] = useState("");
    const [pageNum, setPageNum] = useState(0);
    const { fetchData } = useFetch();

    const fetchBook = async function () {
        const data = await fetchData("/api/Book/GetBook?bookId=" + bookId, "GET");

        data?.pages?.sort((a, b) => a.pageNumber - b.pageNumber);
        setBook(data ?? []);
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

        fetchData("/api/Book/WritePage", "POST", pageDTO)
            .then(() => {
                setPageContent("");
                setPageNum(0);
                fetchBook();
            });
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
        <div className="flex flex-col w-screen lg:container lg:mx-auto lg:px-16 xl:px-16 grow items-center text-gray-200">
            <h3 className="mb-2 mt-4 p-0 text-3xl">{book?.title}</h3>
            <div className="mb-5 p-2 bg-gray-500 rounded flex text-center grow flex-col-reverse lg:flex-row w-full">
                <div className="grow flex flex-col">
                    <div className="flex justify-center items-center bg-gray-600 border-b border-gray-300 pt-3 pb-2 rounded mb-2">
                        <div className="flex items-center">
                            <h5 className="text-xl">Page</h5><input type="number" className="ms-4 px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" min={0} placeholder="Enter the page number" value={pageNum} onChange={e => setPageNum(e.target.value)} />
                        </div>
                    </div>
                    <div className="rounded flex mb-2 grow ">
                        <textarea className="px-4 py-2 w-full bg-gray-700 grow text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" placeholder="Enter the content of page" maxLength={1250} style={{ resize: "none" }} onChange={e => setPageContent(e.target.value)} value={pageContent}></textarea>
                    </div>
                    <div className="flex justify-center flex-col items-end lg:flex-row lg:justify-end">
                        <label className="lg:self-center lg:me-2 hover:cursor-pointer" htmlFor="fileUpload">Import text from .txt file:</label>
                        <input class="p-1 bg-gray-600 rounded hover:ring-2 hover:cursor-pointer transition-all duration-100 active:bg-gray-700 lg:self-center lg:me-2" id="fileUpload" type="file" onChange={e => handleFileSelection(e)} accept=".txt" />
                        <button className="mt-2 lg:mt-0 border border-transparent inline-block rounded px-6 py-2 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900 self-end" onClick={handleSaveClick}>Save</button>
                    </div>
                </div>

                <div className="lg:ps-2 mb-2 lg:mb-0">
                    <div className="flex justify-center lg:justify-start text-xl bg-gray-600 border-b border-gray-300 px-3 pt-4 pb-4 rounded lg:mb-2">
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