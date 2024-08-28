
import React, { createContext, useContext } from 'react'
import { toast } from 'react-toastify';

const FetchContext = createContext();

export const FetchProvider = ({ children }) => {

    const fetchData = async (endpoint, method, dto) => {
        try {
            let response;
            const authorization = `Bearer ${JSON.parse(localStorage.getItem("token"))}`
            if (method === "GET") {
                response = await fetch("http://localhost:5109" + endpoint, {
                    method: method,
                    headers: {
                        Authorization: authorization,
                    }
                });
            } else {
                response = await fetch("http://localhost:5109" + endpoint, {
                    method: method,
                    headers: {
                        "Content-Type": "application/json",
                        Authorization: authorization,
                    },
                    body: JSON.stringify(dto),
                });
            }

            const data = await response.json();
            
            if (!response.ok) {
                toast.error(data.message || "An error occured.");
                console.log(data);
                return;
            }

            if(data.message) toast.success(data.message);
            console.log(data);
            return data;
        } catch (error) {
            console.log(error || "Something bad happened.");
        }
    };

    return (<FetchContext.Provider value={{ fetchData }}>
        {children}
    </FetchContext.Provider>);
};

export const useFetch = () => useContext(FetchContext);
