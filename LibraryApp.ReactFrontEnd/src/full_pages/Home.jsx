import 'bootstrap/dist/css/bootstrap.min.css';
import BookOperations from '../BookOperations.jsx';
import MessageOperations from '../MessageOperations.jsx';
import MemberOperations from '../MemberOperations.jsx';
import StaffOperations from '../StaffOperations.jsx';
import AuthorOperations from '../AuthorOperations.jsx';

function Home() {
    return (
        <div className='container'>
            <div className="row d-flex flex-row justify-content-around">
                <div className="col-4">
                    <BookOperations/>
                </div>
                <div className="col-4">
                    <MessageOperations/>
                </div>
                <div className="col-4">
                    <MemberOperations/>
                </div>
                <div className="col-4">
                    <StaffOperations/>
                </div>
                <div className="col-4">
                    <AuthorOperations/>
                </div>
            </div>
        </div>
    )
}

export default Home;