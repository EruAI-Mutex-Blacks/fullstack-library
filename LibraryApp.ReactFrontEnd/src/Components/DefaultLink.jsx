import { Link } from "react-router-dom";

function DefaultLink({url, text, callback})
{
    return (<Link to={url} className="border border-transparent inline-block rounded px-4 py-2 bg-success hover:bg-success-dark hover:ring-2 hover:ring-success transition-all duration-100 text-text active:bg-success-dark/60" onClick={callback}>{text}</Link>)
}

export default DefaultLink