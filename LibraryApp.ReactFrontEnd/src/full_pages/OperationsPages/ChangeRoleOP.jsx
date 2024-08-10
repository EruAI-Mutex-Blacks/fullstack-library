import StaffOperationsCard from "../../Components/OperationsCards/StaffOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"

function ChangeRoleOP() {
    //users will be listed that has lower role from manager. currently logged in user can change role of them to make it lower or manager
    const rightPanel = "";

    return (<GeneralOperationsPage leftPanel={(<StaffOperationsCard />)} rightPanel={rightPanel} />)
}

export default ChangeRoleOP