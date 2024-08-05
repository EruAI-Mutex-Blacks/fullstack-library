

function Register() {
    return (
        <div className="text-black flex-fill d-flex justify-content-center align-items-center my-5">
            <div className="w-25 bg-custom-fourth p-3 rounded">
                <form action="">
                    <div className="mb-3 d-flex justify-content-between">
                        <div className="me-1">
                            <label className="form-label" htmlFor="name">Name </label>
                            <input id="name" className="form-control d-inline" type="text" />
                        </div>
                        <div className="ms-1">
                            <label className="form-label" htmlFor="surname">Surname</label>
                            <input id="surname" className="form-control d-inline" type="text" />
                        </div>
                    </div>
                    <div className="mb-3">
                        <label className="form-label" htmlFor="username">Username</label>
                        <input id="username" className="form-control" type="text" />
                    </div>

                    <div className="mb-3">
                        <label className="form-label" htmlFor="password">Password</label>
                        <input id="password" className="form-control" type="password" />
                    </div>

                    <div className="mb-3">
                        <label className="form-label" htmlFor="confirmPassword">Confirm password</label>
                        <input id="confirmPassword" className="form-control" type="password" />
                    </div>

                    <div className="mb-3 d-flex justify-content-between">
                        <div className="me-1">
                            <label className="form-label" htmlFor="birthDate">Birth date</label>
                            <input id="birthDate" className="form-control" type="date" />
                        </div>
                        <div className="ms-1">
                            <label className="form-label" htmlFor="gender">Gender</label>
                            <select id="gender" class="form-select" aria-label="Gender selection">
                                <option selected>Select</option>
                                <option value="M">Man</option>
                                <option value="W">Woman</option>
                            </select>
                        </div>
                    </div>
                    <button type="submit" className="text-white btn bg-custom-secondary">Login</button>
                </form>
            </div>
        </div>)
}

export default Register