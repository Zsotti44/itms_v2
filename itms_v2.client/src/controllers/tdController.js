export const newTruckDriver = async (newtruckdriver) =>{
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newtruckdriver)
    };
    return await fetch(import.meta.env.VITE_SERVER_URL+"/api/TruckDriver/addtruckdriver", requestOptions)
        .then(response => response.json())
};
export const editTruckDriver = async(updatedTruckDriver) =>{
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatedTruckDriver)
    };
    return await fetch(import.meta.env.VITE_SERVER_URL+"/api/TruckDriver/edittruckdriver", requestOptions)
    .then(response => response.json())
};

export const getTruckDrivers = async () =>{
return await fetch(import.meta.env.VITE_SERVER_URL+"/api/TruckDriver/getalltruckdriver")
.then((response) => response.json())
}

