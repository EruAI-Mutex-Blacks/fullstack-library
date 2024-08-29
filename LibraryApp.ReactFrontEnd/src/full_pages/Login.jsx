import { Link, useNavigate } from 'react-router-dom'
import { useState, useEffect } from 'react'
import { useUser } from '../AccountOperations/UserContext'
import { toast } from "react-toastify";

function Login() {

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const { user, login } = useUser();
    const navigate = useNavigate();

    useEffect(() => {
        if (user) navigate("/");
    }, [user, navigate])

    const handleLoginClick = async function () {

        if (!username || !password) {
            toast.error("Please fill all the fields");
            return;
        }

        const loginDTO = {
            username: username,
            password: password
        }

        if (username)
            try {
                const response = await fetch("http://localhost:5109/api/Account/Login", {
                    method: "POST",
                    headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
                    body: JSON.stringify(loginDTO)
                });
                if (!response.ok) {
                    const data = await response.json();
                    toast.error(data.message || 'An error occurred. Please try again.');
                    return;
                }

                const data = await response.json();
                localStorage.setItem("token", JSON.stringify(data.token));

                login(data.userDTO);
                navigate("/");
            } catch (error) {
                console.log("There was an error in the process", error);
            }
    };

    return (
        <div className="grow flex justify-center items-center p-10 my-5">
            <div className="bg-gray-500 p-3 rounded">
                <form className='flex flex-col'>
                    <div className="mb-3">
                        <label className="text-gray-200 block font-medium mb-1" htmlFor="username">Username</label>
                        <input id="username" className="px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="text" onChange={e => setUsername(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <label className="text-gray-200 block font-medium mb-1" htmlFor="password">Password</label>
                        <input id="password" className="px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="password" onChange={e => setPassword(e.target.value)} />
                    </div>
                    <div className="mb-3 px-1">
                        <p className="text-xs inline me-1 text-gray-200">Are you not signed up yet?</p><Link className="text-xs border-b border-transparent hover:border-b-blue-300 text-blue-400 font-medium" to="/Register">Create an account</Link>
                    </div>
                    <Link className="border border-transparent inline-block rounded px-4 py-2 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900 self-end" onClick={handleLoginClick}>Login</Link>
                </form>
            </div>
        </div>
    )
}

export default Login