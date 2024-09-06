import { Link } from 'react-router-dom'
import { useUser } from '../AccountOperations/UserContext.jsx';
import { useState } from 'react';

function Navbar() {
    const { user, logout } = useUser();
    const [isDropdownSelected, setIsDropdownSelected] = useState(false);

    const handleLogoutClick = function () {
        setIsDropdownSelected(false);
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
                <div className='hidden lg:flex lg:flex-row'>
                    <div className=''>
                        <Link className='cursor-default py-3 lg:p-3 xl:p-3 text-xs lg:text-base xl:text-base' aria-current="page">{user.roleName + " - " + user.name + " " + user.surname}</Link>
                    </div>
                    {(user?.roleName === "manager") && (
                        <div className=''>
                            <Link className='py-3 lg:p-3 xl:p-3 lg:text-base xl:text-base hover:bg-gray-400/10 transition-all duration-100 rounded' to="/Reports" aria-current="page">Reports</Link>
                            <Link className='py-3 lg:p-3 xl:p-3 lg:text-base xl:text-base hover:bg-gray-400/10 transition-all duration-100 rounded' to="/Settings" aria-current="page">Settings</Link>
                        </div>)}
                    <div className=''>
                        <Link className=' hover:bg-gray-400/10 rounded py-3 lg:p-3 xl:p-3 transition-all duration-100' aria-current="page" to="/" onClick={handleLogoutClick}>Logout</Link>
                    </div>
                </div>
                <div className="relative lg:hidden block">
                    <button id="dropdownButton" className="text-white px-4 py-2 bg-gray-700 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500" onClick={() => setIsDropdownSelected(!isDropdownSelected)}>
                        Options
                    </button>

                    <ul className={`absolute right-0 mt-2 w-48 bg-gray-700 rounded-lg shadow-lg ${isDropdownSelected ? "" : "hidden"}`}>
                        {(user?.roleName === "manager") && (
                            <>
                                <li className=''>
                                    <Link className='rounded block px-4 py-2 text-gray-200 hover:bg-gray-800' to="/Reports" aria-current="page">Reports</Link>
                                </li>
                                <li className=''>

                                    <Link className='block px-4 py-2 text-gray-200 hover:bg-gray-800 rounded' to="/Settings" aria-current="page">Settings</Link>
                                </li>
                            </>
                        )}
                        <li className=''>
                            <Link className=' block px-4 py-2 text-gray-200 hover:bg-gray-800 rounded' aria-current="page" to="/" onClick={handleLogoutClick}>Logout</Link>
                        </li>
                    </ul>
                </div>
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
                        <div className='flex items-center flex-row space-x-3 lg:space-x-0 xl:space-x-0'>
                            {topRightLinks}
                        </div>
                    </li>
                </ul>
            </div>
        </nav>
    )
}

export default Navbar;