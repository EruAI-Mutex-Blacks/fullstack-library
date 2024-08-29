import HomeGeneralOperationsCard from "./OperationsCards/HomeGeneralOperationsCard"
import { useFetch } from "../Context/FetchContext";
import { useEffect, useState } from "react";

function StaffOfMonthCard() {
    const { fetchData } = useFetch();
    const [staffOfMonth, setStaffOfMonth] = useState({});

    const fetchStaffOfMonth = async () => {
        const data = await fetchData("/api/User/GetStaffOfMonth", "GET");
        setStaffOfMonth(data);
    }

    //FIXME currently i am not integrating staff of month instead i integrated a top board like who has most point, show him. instead do 2 column. 1 big column shows past month's staff, small column shows name + score of top 3 of current month.
    //FIXME send score to frontend too to if it is 0 make it no winner past month

    useEffect(() => {
        fetchStaffOfMonth();
    }, []);

    const items = (
        <>
            <li className="text-gray-300 text-3xl mt-5">
                {staffOfMonth.name + " " + staffOfMonth.surname}
            </li>
            <li className="text-gray-300 text-md">
                {"Birthdate: " + new Date(staffOfMonth.birthDate).toLocaleDateString("en-us")}
            </li>
            <li className="text-gray-300 text-md">
                {"Gender: " + (staffOfMonth.gender === "M" ? "Male" : "Female")}
            </li>
        </>
    );

    return <HomeGeneralOperationsCard title="Current staff of month" items={items} />
}

export default StaffOfMonthCard