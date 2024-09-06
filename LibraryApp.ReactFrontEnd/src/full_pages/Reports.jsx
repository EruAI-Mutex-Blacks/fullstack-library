import { useState } from "react";
import ReportCard from "../Components/ReportCard";
import { useFetch } from "../Context/FetchContext";

function Reports() {

    const [startDate, setStartDate] = useState("");
    const [endDate, setEndDate] = useState("");
    const [reportDTO, setReportDTO] = useState(null);
    const { fetchData } = useFetch();

    const handleGetReportClick = async () => {
        const data = await fetchData(`/api/Reports/GetReports?startDate=${startDate}&endDate=${endDate}`, "GET");
        setReportDTO(data ?? null);
        console.log(startDate);
        console.log(endDate);
    }

    return (
        <div className="container md:mx-20 mx-10 my-4 flex flex-col">
            <div className="flex flex-col">
                <div className="lg:flex lg:space-x-4 lg:space-y-0 space-y-2 grow">
                    <div className="grow">
                        <label className="text-gray-200 block font-medium mb-1" htmlFor="startDate">Start date</label>
                        <input id="startDate" className="px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" onChange={e => setStartDate(e.target.value)} type="date" />
                    </div>
                    <div className="grow">
                        <label className="text-gray-200 block font-medium mb-1" htmlFor="endDate">End date</label>
                        <input id="endDate" className="px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="date" onChange={e => setEndDate(e.target.value)} />
                    </div>
                </div>
                <button type="submit" className="border border-transparent inline-block rounded px-4 py-2 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900 self-end my-4" onClick={handleGetReportClick}>{startDate === "" || endDate === "" ? "Get report of all time" : "Get report in that range"}</button>
            </div>
            {(reportDTO !== null) && (<div className="flex flex-col lg:flex-none lg:grid lg:grid-cols-2 lg:gap-x-10 lg:gap-y-5 lg:grid-rows-3">
                <ReportCard title="Total books published" items={
                    [{ "key": "", "value": reportDTO?.totalBookCount }]
                } />
                <ReportCard title="Most borrowed books" items={reportDTO?.mostBorrowedBooks} />
                <ReportCard title="Total users registered" items={
                    [{ "key": "", "value": reportDTO?.totalUserCount }]
                } />
                <ReportCard title="Users per role" items={reportDTO?.usersPerRole} />
                <ReportCard title="Top members/authors that borrows more" items={reportDTO?.mostBorrowers} />
                <ReportCard title="Top members/authors that returns book fast" items={reportDTO?.mostScoredMembers} />
            </div >
            )}
        </div >
    )
}
export default Reports;
