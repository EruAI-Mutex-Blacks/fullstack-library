import { useLocation } from "react-router-dom";
import BookOperationsCard from "../../Components/BookOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"


function SearchBookOP() {
    const location = useLocation();
    const bookQuery = new URLSearchParams(location.search).get('book');

    const rightPanel = "";

    return (<GeneralOperationsPage leftPanel={(<BookOperationsCard />)} rightPanel={bookQuery} />)
}

export default SearchBookOP