import 'bootstrap/dist/css/bootstrap.min.css';
import BookOperationsCard from '../Components/BookOperationsCard.jsx';
import MessageOperationsCard from '../Components/MessageOperationsCard.jsx';
import MemberOperationsCard from '../Components/MemberOperationsCard.jsx';
import StaffOperationsCard from '../Components/StaffOperationsCard.jsx';
import AuthorOperationsCard from '../Components/AuthorOperationsCard.jsx';

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