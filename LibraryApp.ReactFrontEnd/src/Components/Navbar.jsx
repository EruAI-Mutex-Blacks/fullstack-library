import { Link } from 'react-router-dom'
import { useUser } from '../AccountOperations/UserContext.jsx';

function Navbar() {
    const { user, logout } = useUser();

    const handleLogoutClick = function () {
        logout();
    }

    let topRightLinks = "";

    if (!user) {
        topRightLinks = (
            <>
                <li>
                    <Link className="nav-link active" aria-current="page" to="/Login">Login</Link>
                </li>
                <li>
                    <Link className="nav-link active" aria-current="page" to="/Register">Register</Link>
                </li>
            </>);
    } else {
        topRightLinks = (
            <>
                <li>
                    <Link className='nav-link active disabled' aria-current="page">{user.roleName + " - " + user.name + " " + user.surname}</Link>
                </li>
                <li>
                    <Link className='nav-link active' aria-current="page" to="/" onClick={handleLogoutClick}>Logout</Link>
                </li>
            </>
        )
    }

    return (
        <nav className="bg-gray-800 text-white">
            <div className="container mx-auto flex items-center justify-between p-4">
                <Link className="text-xl font-bold" to="/">Navbar</Link>
                <ul className="navbar-nav w-100 d-flex flex-row justify-content-between">
                    <li className=''>
                        <ul className='d-flex list-inline'>
                            <li className="">
                                <Link className="nav-link active" aria-current="page" to="/">Home</Link>
                            </li>
                            <li className="">
                                {
                                    (user?.roleName === "author") && (<Link className="nav-link active" aria-current="page" to="/MyBooks">My books</Link>)
                                }
                            </li>
                        </ul>
                    </li>
                    <li>
                        <ul className='list-inline nav-item d-flex flex-row justify-content-evenly'>
                            {topRightLinks}
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
    )
}

export default Navbar;