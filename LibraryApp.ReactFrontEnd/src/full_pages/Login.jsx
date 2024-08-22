import { Link, useNavigate } from 'react-router-dom'
import { useState, useEffect } from 'react'
import { useUser } from '../AccountOperations/UserContext'

function Login() {

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const { user, setUser } = useUser();
    const navigate = useNavigate();

    useEffect(() => {
        if (user) navigate("/");
    }, [user, navigate])
    //TODO change links to buttons link being used for navigation

    const loginDTO = {
        username: username,
        password: password
    }

    const handleLoginClick = async function () {
        try {
            const response = await fetch("http://localhost:5109/api/Account/Login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(loginDTO)
            });
            if (!response.ok) {
                return;
            }

            const userDTO = await response.json();
            //FIXME use cookies or smt like that to keep user logged in until it logs out. jwt to send token when we need to do any kind of operations. it needs to check if user is real otherwise some people can send a placholder user to server. or if you need basic make a currentuser in backend and want password for every action to check if they are same
            setUser(userDTO);
            navigate("/");
        } catch (error) {
            console.log("There was an error in the process", error);
        }
    };

    return (
        <div className="text-black flex-fill d-flex justify-content-center align-items-center my-5">
            <div className="w-25 bg-custom-fourth p-3 rounded">
                <form action="">
                    <div className="mb-3">
                        <label className="form-label" htmlFor="username">Username</label>
                        <input id="username" className="form-control" type="text" onChange={e => setUsername(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <label className="form-label" htmlFor="password">Password</label>
                        <input id="password" className="form-control" type="password" onChange={e => setPassword(e.target.value)} />
                    </div>
                    <div className="mb-3 px-1">
                        <p className="fs-9">Are you not signed up? <Link className="link-offset-2 link-offset-3-hover link-underline link-underline-opacity-0 link-underline-opacity-75-hover" to="/Register">Create an account</Link></p>
                    </div>
                    <Link className="text-white btn bg-custom-secondary" onClick={handleLoginClick}>Login</Link>
                </form>
            </div>
        </div>
    )
}

export default Login