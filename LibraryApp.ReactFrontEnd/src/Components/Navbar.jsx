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
                    <Link className=" hover:bg-gray-400/10 rounded p-3 transition-all duration-100" aria-current="page" to="/Login">Login</Link>
                </li>
                <li>
                    <Link className=" hover:bg-gray-400/10 rounded p-3 transition-all duration-100" aria-current="page" to="/Register">Register</Link>
                </li>
            </>);
    } else {
        topRightLinks = (
            <>
                <li className=''>
                    <Link className='cursor-default py-3 lg:p-3 xl:p-3 text-xs lg:text-base xl:text-base' aria-current="page">{user.roleName + " - " + user.name + " " + user.surname}</Link>
                </li>
                {(user?.roleName === "manager") && (<li className=''>
                    <Link className='py-3 lg:p-3 xl:p-3 lg:text-base xl:text-base' to="/Settings" aria-current="page">S</Link>
                </li>)}
                <li className=''>
                    <Link className=' hover:bg-gray-400/10 rounded py-3 lg:p-3 xl:p-3 transition-all duration-100' aria-current="page" to="/" onClick={handleLogoutClick}>Logout</Link>
                </li>
            </>
        )
    }

    return (
        <nav className="bg-gray-800 text-white">
            <div className="mx-auto flex items-center justify-between px-4 py-2 lg:py-4 lg:px-10 ">
                <Link className="text-xl font-bold" to="/">Navbar</Link>
                <ul className="items-center justify-between space-x-14 lg:space-x-0 xl:space-x-0 px-2 lg:px-5 xl:px-5 pt-1 w-full flex flex-row">
                    <li className=''>
                        <ul className='flex items-center'>
                            <li className="">
                                <Link className="hover:bg-gray-400/10 rounded p-3 transition-all duration-100" to="/">Home</Link>
                            </li>
                            <li className="">
                                {
                                    (user?.roleName === "author" && !user?.isPunished) && (<Link className="hover:bg-gray-400/10 rounded py-3 lg:p-3 xl:p-3 transition-all duration-100 inline-block" to="/MyBooks">My books</Link>)
                                }
                            </li>
                        </ul>
                    </li>
                    <li>
                        <ul className='flex items-center flex-row space-x-3 lg:space-x-0 xl:space-x-0'>
                            {topRightLinks}
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>
    )
}

export default Navbar;