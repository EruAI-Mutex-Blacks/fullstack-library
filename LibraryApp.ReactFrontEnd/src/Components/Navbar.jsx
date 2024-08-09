import 'bootstrap/dist/css/bootstrap.min.css'
import { Link } from 'react-router-dom'

function Navbar() {
    return (
        <nav className="navbar navbar-expand-lg  navbar-dark bg-custom-secondary">
            <div className="container-fluid">
                <Link className="navbar-brand" to="/">Navbar</Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse " id="navbarNav">
                    <ul className="navbar-nav w-100 d-flex flex-row justify-content-between">
                        <li className="nav-item d-flex flex-row justify-content-evenly">
                            <Link className="nav-link active" aria-current="page" to="/">Home</Link>
                        </li>
                        <li>
                            <ul className='nav-item d-flex flex-row justify-content-evenly'>
                                <li>
                                    <Link className="nav-link active" aria-current="page" to="/Login">Login</Link>
                                </li>
                                <li>
                                    <Link className="nav-link active" aria-current="page" to="/Register">Register</Link>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    )
}

export default Navbar;