import MessageOperationsCard from "../../Components/OperationsCards/MessageOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"


function ViewInboxOP() {
    //TODO need messages table for database need read or unread column 
    //TODO maybe do message card component for left panel
    
    const handleMsgCardClick = function()
    {
    }

    //messages that has sent to currently logged in user
    const rightPanel = (
        <div className="d-flex flex-fill justify-content-between">
            <div className="col-3 me-2 p-2 bg-light rounded" style={{height:"65vh",overflow:"auto"}}>
                {/* card */}
                <div onClick={handleMsgCardClick} className="mb-2 d-flex flex-column border border-dark rounded p-2 bg-success-subtle btn">
                    <div className="d-flex mb-2 justify-content-between border-bottom border-dark">
                        <div>sm avt</div>
                        <div><h6 className="align-self-center">Sender 1</h6></div>
                    </div>
                    <div className="d-flex justify-content-between">
                        <p className="pt-1 fs-7 mb-2">small piece..</p>
                        <span className="badge text-bg-danger align-self-center ms-2 p-1">unread</span>
                    </div>
                </div>
                {/* card */}
                <div onClick={handleMsgCardClick} className="mb-2 d-flex flex-column border border-dark rounded p-2 bg-success-subtle btn">
                    <div className="d-flex mb-2 justify-content-between border-bottom border-dark">
                        <div>sm avt</div>
                        <div><h6 className="align-self-center">Sender 1</h6></div>
                    </div>
                    <div className="d-flex justify-content-between">
                        <p className="pt-1 fs-7 mb-2">small piece..</p>
                        <span className="badge text-bg-danger align-self-center ms-2 p-1">unread</span>
                    </div>
                </div>{/* card */}
                <div onClick={handleMsgCardClick} className="mb-2 d-flex flex-column border border-dark rounded p-2 bg-success-subtle btn">
                    <div className="d-flex mb-2 justify-content-between border-bottom border-dark">
                        <div>sm avt</div>
                        <div><h6 className="align-self-center">Sender 1</h6></div>
                    </div>
                    <div className="d-flex justify-content-between">
                        <p className="pt-1 fs-7 mb-2">small piece..</p>
                        <span className="badge text-bg-danger align-self-center ms-2 p-1">unread</span>
                    </div>
                </div>{/* card */}
                <div onClick={handleMsgCardClick} className="mb-2 d-flex flex-column border border-dark rounded p-2 bg-success-subtle btn">
                    <div className="d-flex mb-2 justify-content-between border-bottom border-dark">
                        <div>sm avt</div>
                        <div><h6 className="align-self-center">Sender 1</h6></div>
                    </div>
                    <div className="d-flex justify-content-between">
                        <p className="pt-1 fs-7 mb-2">small piece..</p>
                        <span className="badge text-bg-danger align-self-center ms-2 p-1">unread</span>
                    </div>
                </div>
            </div>
            <div className="col-9 p-3 bg-light rounded"></div>
        </div>
    );

    return (<GeneralOperationsPage leftPanel={(<MessageOperationsCard />)} rightPanel={rightPanel} />)
}

export default ViewInboxOP