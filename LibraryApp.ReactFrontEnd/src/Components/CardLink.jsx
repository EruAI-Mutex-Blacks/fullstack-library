import { Link } from "react-router-dom";


function CardLink(props) {
    return (<Link className="rounded bg-rose-700 border border-transparent inline-block px-6 py-4  hover:bg-rose-800 transition-all duration-100 text-white/80 font-semibold hover:text-white hover:border-white ease-in-out active:bg-rose-900" to={props.url}>{props.text}</Link>);
}

export default CardLink