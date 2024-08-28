import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";


function Register() {

    const [name, setName] = useState("");
    const [surname, setSurname] = useState("");
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [birthDate, setBirthDate] = useState("");
    const [gender, setGender] = useState("");

    const navigate = useNavigate();

    const handleRegisterClick = async function (e) {
        e.preventDefault();

        if (!name || !surname || !username || !password || !confirmPassword || !birthDate || !gender) {
            toast.error("Please fill all the fields.");
            return;
        }

        if(password !== confirmPassword)
        {
            toast.error("Both password must be same.");
            return;
        }

        const registerDTO = {
            name: name,
            surname: surname,
            username: username,
            password: password,
            birthDate: birthDate,
            gender: gender,
        }

        try {
            const response = await fetch("http://localhost:5109/api/Account/Register", {
                method: "POST",
                headers: { "Content-Type": "application/json",Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
                body: JSON.stringify(registerDTO),
            });
            if (!response.ok) return;
            const data = await response.json();
            toast.success("Registiration request has sent to staffs.");
            toast.info("Directing to login page.");
            navigate("/Login");
        } catch (error) {
            console.log("there was an error", error);
        }
    };

    return (
        <div className="grow flex justify-center items-center my-5">
            <div className=" bg-gray-500 p-3 rounded">
                <form className="flex flex-col">
                    <div className="mb-3 flex justify-between">
                        <div className="me-1">
                            <label className="text-gray-200 block font-medium mb-1" htmlFor="name">Name </label>
                            <input id="name" className="form-control px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="text" onChange={(e) => setName(e.target.value)} />
                        </div>
                        <div className="ms-1">
                            <label className="text-gray-200 block font-medium mb-1" htmlFor="surname">Surname</label>
                            <input id="surname" className="form-control px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="text" onChange={(e) => setSurname(e.target.value)} />
                        </div>
                    </div>
                    <div className="mb-3">
                        <label className="text-gray-200 block font-medium mb-1" htmlFor="username">Username</label>
                        <input id="username" className="px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="text" onChange={(e) => setUsername(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <label className="text-gray-200 block font-medium mb-1" htmlFor="password">Password</label>
                        <input id="password" className="px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="password" onChange={(e) => setPassword(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <label className="text-gray-200 block font-medium mb-1" htmlFor="confirmPassword">Confirm password</label>
                        <input id="confirmPassword" className="px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="password" onChange={(e) => setConfirmPassword(e.target.value)} />
                    </div>

                    <div className="mb-3 flex justify-between ">
                        <div className="me-1 grow">
                            <label className="text-gray-200 block font-medium mb-1" htmlFor="birthDate">Birth date</label>
                            <input id="birthDate" className="px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="date" onChange={(e) => setBirthDate(e.target.value)} />
                        </div>
                        <div className="ms-1 grow">
                            <label className="text-gray-200 block font-medium mb-1" htmlFor="gender">Gender</label>
                            <select id="gender" className="px-4 py-2 w-full bg-gray-700 text-white rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" aria-label="Gender selection" onChange={(e) => setGender(e.target.value)} >
                                <option value="">Select</option>
                                <option value="M">Male</option>
                                <option value="F">Female</option>
                            </select>
                        </div>
                    </div>
                    <button type="submit" className="border border-transparent inline-block rounded px-4 py-2 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900 self-end" onClick={handleRegisterClick}>Register</button>
                </form>
            </div>
        </div>)
}

export default Register