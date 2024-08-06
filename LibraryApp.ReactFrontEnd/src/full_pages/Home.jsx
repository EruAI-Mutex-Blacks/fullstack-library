import 'bootstrap/dist/css/bootstrap.min.css';
import BookOperations from '../BookOperations.jsx';
import MessageOperations from '../MessageOperations.jsx';
import MemberOperations from '../MemberOperations.jsx';
import StaffOperations from '../StaffOperations.jsx';

function Home() {
    return (
        <div className='container'>
            <div className="row">
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
            </div>
        </div>
    )
}

export default Home;