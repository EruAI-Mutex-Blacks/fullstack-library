import { Link } from 'react-router-dom'

function Footer() {
    return (
        <>
            <div className="flex flex-row justify-center p-2 bg-gray-800">
                <div className="flex flex-col items-center">
                    <p className="text-sm italic text-white/75 my-0">Made by black group for Erciyes University's artifical intelligence club's mutex algorithm bootcamp in 2024</p>
                    <footer className="text-xs italic text-white/50 my-0">Black group members: Turker [LinkedIn], Feyza [LinkedIn], Fatih [LinkedIn], Necati [LinkedIn]</footer>
                </div>
            </div>
        </>
    )
}

export default Footer;