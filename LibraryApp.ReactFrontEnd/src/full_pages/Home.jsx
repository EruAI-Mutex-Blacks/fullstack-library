import BookOperationsCard from '../Components/OperationsCards/BookOperationsCard.jsx';
import MessageOperationsCard from '../Components/OperationsCards/MessageOperationsCard.jsx';
import MemberOperationsCard from '../Components/OperationsCards/MemberOperationsCard.jsx';
import GeneralOperationsCard from '../Components/OperationsCards/GeneralOperationsCard.jsx';
import AuthorOperationsCard from '../Components/OperationsCards/AuthorOperationsCard.jsx';
import { useUser } from '../AccountOperations/UserContext.jsx';

function Home() {
    const { user } = useUser();

    let mainContent = "";

    if (!user)
        mainContent = (<div className='grow self-center text-center'>
            <div>
                <h1 className='text-4xl mb-4'>Welcome to the library</h1>
                <p>Please <b>login or register</b> to our library from the <b>top right corner</b> to be able to do any kind of operations.</p>
            </div>
        </div>);
    else if (user.isPunished)
        mainContent = (<div className='grow self-center text-center'>
            <div>
                <h1>Welcome to the library</h1>
                <p>You are <b>punished</b> from library. Please contact with the staffs for further operations.</p>
            </div>
        </div>)
    else if (user.roleName === "pendingUser")
        mainContent = (<div className='grow self-center text-center'>
            <div>
                <h1>Welcome to the library</h1>
                <p>Please wait for your account <b>approval</b>. Our personnel will check soon.</p>
            </div>
        </div>)
    else if (user)
        mainContent = (
            <div className="grid grid-cols-3 gap-x-12 container mx-24 my-10">
                {(["member", "staff", "manager", "author"].includes(user.roleName)) && (
                    <>
                        <div className="">
                            <BookOperationsCard />
                        </div>
                        < div className="">
                            <MessageOperationsCard />
                        </div>
                    </>
                )}
                {
                    (["staff", "manager"].includes(user.roleName)) && (
                        < div className="">
                            <MemberOperationsCard />
                        </div>
                    )}
                {
                    (user.roleName === "manager") && (
                        <>
                            < div className="">
                                <GeneralOperationsCard />
                            </div>
                            < div className="">
                                <AuthorOperationsCard />
                            </div>
                        </>
                    )}
            </div>
        );

    return mainContent;
}

export default Home;