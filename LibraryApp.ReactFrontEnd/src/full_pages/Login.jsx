

function Login() {
    return (
        <div className="bg-info flex-fill d-flex justify-content-center align-items-center">
            <div className="w-25">
                <form action="">
                    <div className="mb-3">
                        <label className="form-label" htmlFor="username">Username</label>
                        <input id="username" className="form-control" type="text" />
                    </div>

                    <div className="mb-3">
                        <label className="form-label" htmlFor="password">Password</label>
                        <input id="password" className="form-control" type="password" />
                    </div>
                    <button type="submit" class="btn btn-primary">Login</button>
                </form>
            </div>
        </div>
    )
}

export default Login