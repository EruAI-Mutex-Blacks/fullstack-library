import { useEffect, useState } from "react";
import { useFetch } from "../Context/FetchContext";
import { toast } from "react-toastify";

function Settings() {

    const { fetchData } = useFetch();
    const [settings, setSettings] = useState([]);

    const fetchSettings = async function () {
        const data = await fetchData("/api/User/GetSettings", "GET");
        setSettings(data?.map(s => ({
            id: s.id,
            name: s.name,
            oldValue: s.value,
            newValue: s.value,
        })));
    }

    const updateSetting = async function (setting) {
        console.log(setting.oldValue);
        console.log(setting.newValue);

        if (!setting.newValue) {
            toast.error("Cannot leave blank.");
            return;
        }
        if (setting.oldValue === setting.newValue) {
            toast.error("You did not change anything.");
            return;
        }

        const newSetting = {
            id: setting.id,
            name: setting.name,
            value: setting.newValue,
        };

        await fetchData("/api/User/UpdateSetting", "PUT", newSetting)
            .then(() => {
                console.log(newSetting);
                fetchSettings();
            });

    }

    useEffect(() => {
        fetchSettings();
    }, []);

    return (
        <div className="grow m-10 lg:px-40">
            <h2 className="text-3xl text-gray-300 font-medium mb-5">Current global settings</h2>
            {settings?.map((s, index) => (
                <div key={index} className="flex space-x-4 items-center">
                    <div className="mb-3 grow">
                        <label className="text-gray-200 block font-medium mb-1" htmlFor={s.name}>{s.name.replaceAll("-", " ").replace(s.name[0], s.name[0].toUpperCase())}</label>
                        <input id={s.name} className="px-4 py-2 w-full bg-gray-700 text-gray-200 rounded border border-gray-600 focus:ring-blue-500 focus:ring-2 focus:border-blue-400 focus:outline-none hover:ring-2" type="number" step={0.1} defaultValue={s.newValue} onChange={e => { s.newValue = e.target.value }} />
                    </div>
                    <button className="border border-transparent inline-block rounded px-4 py-2 mt-4 bg-green-700 hover:bg-green-800 hover:ring-green-500 hover:ring-2 transition-all duration-100 text-white active:bg-green-900" onClick={() => { updateSetting(s) }}>Update</button>
                </div>
            ))}
        </div>)
}

export default Settings;

//TODO backendte automapper dene uygula.
//TODO en basit mimariyi sor chatgptye ve backend mimarisini ona at. önerilerine göre değişiklik yap