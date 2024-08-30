import HomeGeneralOperationsCard from "./OperationsCards/HomeGeneralOperationsCard"
import { useFetch } from "../Context/FetchContext";
import { useEffect, useState } from "react";

function StaffOfMonthCard() {
    const { fetchData } = useFetch();
    const [staffOfMonthDTO, setStaffOfMonthDTO] = useState({});

    const fetchStaffOfMonth = async () => {
        fetchData("/api/User/GetStaffOfMonth", "GET")
            .then(data => {
                setStaffOfMonthDTO(data ?? {});
            });
        console.log(staffOfMonthDTO);
    }

    //FIXME currently i am not integrating staff of month instead i integrated a top board like who has most point, show him. instead do 2 column. 1 big column shows past month's staff, small column shows name + score of top 3 of current month.
    //FIXME send score to frontend too to if it is 0 make it no winner past month

    useEffect(() => {
        fetchStaffOfMonth();
    }, []);

    const items = (
        <>
            <li className="flex space-x-5 justify-center items-center">
                <div>
                    <h6 className="text-2xl text-gray-300 border-b pb-1">Staff of previous month</h6>
                    <ul>
                        <li className="text-gray-300 text-xl mt-2">
                            {staffOfMonthDTO?.staffOfPrevMonth?.name + " " + staffOfMonthDTO?.staffOfPrevMonth?.surname}
                        </li>
                        <li className="text-gray-300 text-md">
                            {"Birthdate: " + new Date(staffOfMonthDTO?.staffOfPrevMonth?.birthDate).toLocaleDateString("en-us")}
                        </li>
                        <li className="text-gray-300 text-md">
                            {"Gender: " + (staffOfMonthDTO?.staffOfPrevMonth?.gender === "M" ? "Male" : "Female")}
                        </li>
                    </ul>
                </div>
                <div>
                    {(staffOfMonthDTO?.currentTop3Staff?.length === 3) && (
                        <>
                            <h6 className="text-md border-b pb-1 pt-10 mb-2 text-gray-300">Current Month's Top 3</h6>
                            <ul className="flex flex-col items-start">
                                <li className="text-sm text-gray-300">1-) {staffOfMonthDTO?.currentTop3Staff[0]?.name + " " + staffOfMonthDTO?.currentTop3Staff[0]?.surname + " - " + staffOfMonthDTO?.currentTop3Staff[0]?.monthlyScore}</li>
                                <li className="text-sm text-gray-300">2-) {staffOfMonthDTO?.currentTop3Staff[1]?.name + " " + staffOfMonthDTO?.currentTop3Staff[1]?.surname + " - " + staffOfMonthDTO?.currentTop3Staff[0]?.monthlyScore}</li>
                                <li className="text-sm text-gray-300">3-) {staffOfMonthDTO?.currentTop3Staff[1]?.name + " " + staffOfMonthDTO?.currentTop3Staff[2]?.surname + " - " + staffOfMonthDTO?.currentTop3Staff[0]?.monthlyScore}</li>
                            </ul>
                        </>)}
                </div>
            </li>
        </>

    );

    return <HomeGeneralOperationsCard title="Hall Of Fame" items={items} />
}

export default StaffOfMonthCard