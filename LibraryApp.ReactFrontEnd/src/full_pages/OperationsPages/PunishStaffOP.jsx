import StaffOperationsCard from "../../Components/OperationsCards/StaffOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"

function PunishStaffOP() {
    //manager can punish staff
    const rightPanel = "";

    return (<GeneralOperationsPage leftPanel={(<StaffOperationsCard />)} rightPanel={rightPanel} />)
}

export default PunishStaffOP