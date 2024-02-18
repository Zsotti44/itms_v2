
export const newShift = async (newShift) => {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newShift)
    };
    return await fetch(import.meta.env.VITE_SERVER_URL + "/api/Shift/addShift", requestOptions)
        .then(response => response.json())
};

//Need backend....
export const editShift = async (updatedShift) => {
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatedShift)
    };
    return await fetch(import.meta.env.VITE_SERVER_URL + "/api/Shift/editShift", requestOptions)
        .then(response => response.json())
};

export const getShifts = async () => {
    return await fetch(import.meta.env.VITE_SERVER_URL + "/api/Shift/getallShift")
        .then((response) => response.json())
};
export const getShift = async (id) => {
    return await fetch(import.meta.env.VITE_SERVER_URL + "/api/Shift/" + id)
        .then((response) => response.json())
};

/* Get select options */
export const getTruckSelectOptions = async () => {
    return await fetch(import.meta.env.VITE_SERVER_URL + "/api/Truck/getTruckSelectOptions/")
        .then((response) => response.json())
};
export const getTrailerSelectOptions = async () => {
    return await fetch(import.meta.env.VITE_SERVER_URL + "/api/Trailer/getTrailerSelectOptions/")
        .then((response) => response.json())
};
export const getDriverSelectOptions = async () => {
    return await fetch(import.meta.env.VITE_SERVER_URL + "/api/TruckDriver/getTruckDriverSelectOptions/")
        .then((response) => response.json())
};
export const getDispatcherSelectOptions = async () => {
    return await fetch(import.meta.env.VITE_SERVER_URL + "/api/Shift/getDispatcherSelectOptions/")
        .then((response) => response.json())
};


/*Edit worktrucks */
export const editWorkTruck = async (updatedWorkTruck) => {
    console.log(updatedWorkTruck);
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatedWorkTruck)
    };
    return await fetch(import.meta.env.VITE_SERVER_URL + "/api/Shift/updateWorkTruck", requestOptions)
        .then(response => response.json())
};

export const addWorkTruck = async (addWorkTruck) => {
    console.log(addWorkTruck);
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(addWorkTruck)
    };
    return await fetch(import.meta.env.VITE_SERVER_URL + "/api/Shift/addWorkTruck", requestOptions)
        .then(response => response.json())
};