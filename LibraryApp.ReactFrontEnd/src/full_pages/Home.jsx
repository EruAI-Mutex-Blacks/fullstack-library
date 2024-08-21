import 'bootstrap/dist/css/bootstrap.min.css';
import BookOperationsCard from '../Components/OperationsCards/BookOperationsCard.jsx';
import MessageOperationsCard from '../Components/OperationsCards/MessageOperationsCard.jsx';
import MemberOperationsCard from '../Components/OperationsCards/MemberOperationsCard.jsx';
import StaffOperationsCard from '../Components/OperationsCards/StaffOperationsCard.jsx';
import AuthorOperationsCard from '../Components/OperationsCards/AuthorOperationsCard.jsx';
import { useUser } from '../AccountOperations/UserContext.jsx';

function Home() {
    const { user } = useUser();

    return (
        <div className='container'>
            <div className="row d-flex flex-row justify-content-around">
                {(["member", "staff", "manager"].includes(user.roleName)) && (
                    <>
                        <div className="col-4">
                            <BookOperationsCard />
                        </div>
                        < div className="col-4">
                            <MessageOperationsCard />
                        </div>
                    </>
                )}
                {
                    (["staff", "manager"].includes(user.roleName)) && (
                        < div className="col-4">
                            <MemberOperationsCard />
                        </div>
                    )}
                {
                    (user.roleName === "manager") && (
                        <>
                            < div className="col-4">
                                <StaffOperationsCard />
                            </div>
                            < div className="col-4">
                                <AuthorOperationsCard />
                            </div>
                        </>
                    )}
            </div>
        </div >
    )
}

export default Home;