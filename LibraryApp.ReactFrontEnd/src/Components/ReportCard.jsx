
function ReportCard({ title, items }) {
    return (
        <div className="bg-gray-500 grow mt-4 rounded flex flex-col">
            <h4 className="border-b rounded text-center text-2xl py-2 text-gray-200 font-medium">{title}</h4>
            <ul className="flex flex-col p-4 self-center grow">
                {(items.length < 1) && (<p className="text-3xl text-center font-bold text-white">N/A</p>)}
                {items?.map((i, index) => (
                    <li className="flex grow" key={index}>
                        <p className={`${i.key !== "" ? "text-2xl" : "text-5xl lg:text-9xl grow self-center"} text-start font-bold text-white`}>{(i.key !== "" ? `${index + 1}- ${i.key.replace(i.key[0], i.key[0].toUpperCase())}: ` : "") + i.value}</p>
                    </li>
                ))}
            </ul>
        </div>)
}

export default ReportCard;