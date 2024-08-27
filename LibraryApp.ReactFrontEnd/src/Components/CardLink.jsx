import { Link } from "react-router-dom";


function CardLink(props) {
    return (<Link className="rounded bg-rose-600 border border-transparent inline-block px-5 py-1 hover:bg-rose-700 transition-all duration-300 text-white/80 font-semibold hover:text-white hover:border-white ease-in-out" to={props.url}>{props.text}</Link>);
}

export default CardLink