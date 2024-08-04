import 'bootstrap/dist/css/bootstrap.min.css'
import { Link } from 'react-router-dom'

function Footer() {
    return (
        <>
            <hr className="m-0" />
            <div className="d-flex flex-row justify-content-end p-2 bg-dark">
                <div className="d-flex flex-column align-items-end">
                    <p className="my-0 text-white text-opacity-75">Made by black group for Erciyes University's artifical intelligence club's mutex algorithm bootcamp in 2024</p>
                    <footer className="blockquote-footer text-white text-opacity-25 my-0">Black group members: Turker [LinkedIn], Feyza [LinkedIn], Fatih [LinkedIn], Necati [LinkedIn]</footer>
                </div>
                </div>
        </>
    )
}

export default Footer;