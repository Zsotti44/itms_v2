

export const newTruck = async (newtruck) =>{
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newtruck)
    };
    return await fetch(import.meta.env.VITE_SERVER_URL+"/api/Truck/addtruck", requestOptions)
        .then(response => response.json())
};
export const editTruck = async(updatedTruck) =>{
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatedTruck)
    };
    return await fetch(import.meta.env.VITE_SERVER_URL+"/api/Truck/edittruck", requestOptions)
    .then(response => response.json())
};
export const getTrucks = async () => {
return await fetch(import.meta.env.VITE_SERVER_URL+"/api/Truck/getalltruck")
.then((response) => response.json())
};
