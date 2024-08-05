import 'bootstrap/dist/css/bootstrap.min.css';
import BookOperations from '../BookOperations.jsx';

function Home() {
    return (
        <div className='container'>
            <div className="row">
                <div className="col-4">
                    <BookOperations></BookOperations>
                </div>
            </div>
        </div>
    )
}

export default Home;