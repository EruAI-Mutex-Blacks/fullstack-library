


function DefaultTableTemplate(props) {

    return (<div className="grow w-screen lg:w-full overflow-x-auto bg-gray-800 border border-gray-300">
        <table className="w-full text-sm text-left rtl:text-right text-gray-400">
            <thead className="text-xs uppercase bg-gray-700 text-gray-400">
                <tr>
                    {props.headersArray.map((hc, index) => (
                        <th key={index} className="px-6 py-4">{hc}</th>
                    ))}
                </tr>
            </thead>
            <tbody>
                {props.datasArray.map((da, index) => (
                    <tr key={index} className="border-b bg-gray-800 border-gray-700">
                        {da.map((d, index) => (
                            <td key={index} className={`px-6 py-4 ${index == 0 ? "text-white font-medium whitespace-nowrap" : ""}`}>{d}</td>
                        ))}
                    </tr>
                ))}
            </tbody>
        </table >
    </div>)
}

export default DefaultTableTemplate;