import 'bootstrap/dist/css/bootstrap.min.css';
import BookOperationsCard from '../Components/OperationsCards/BookOperationsCard.jsx';
import MessageOperationsCard from '../Components/OperationsCards/MessageOperationsCard.jsx';
import MemberOperationsCard from '../Components/OperationsCards/MemberOperationsCard.jsx';
import StaffOperationsCard from '../Components/OperationsCards/StaffOperationsCard.jsx';
import AuthorOperationsCard from '../Components/OperationsCards/AuthorOperationsCard.jsx';

function Home() {
    return (
        <div className='container'>
            <div className="row d-flex flex-row justify-content-around">
                <div className="col-4">
                    <BookOperationsCard/>
                </div>
                <div className="col-4">
                    <MessageOperationsCard/>
                </div>
                <div className="col-4">
                    <MemberOperationsCard/>
                </div>
                <div className="col-4">
                    <StaffOperationsCard/>
                </div>
                <div className="col-4">
                    <AuthorOperationsCard/>
                </div>
            </div>
        </div>
    )
}

export default Home;