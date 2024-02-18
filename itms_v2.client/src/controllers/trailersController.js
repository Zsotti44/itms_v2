export const newTrailer = async (newTrailer) =>{
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newTrailer)
    };
    return await fetch(import.meta.env.VITE_SERVER_URL+"/api/Trailer/addtrailer", requestOptions)
        .then(response => response.json())
};
export const editTrailer = async(updatedTrailer) =>{
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updatedTrailer)
    };
    return await fetch(import.meta.env.VITE_SERVER_URL+"/api/Trailer/edittrailer", requestOptions)
    .then(response => response.json())
};
export const getTrailers = async () =>{
return await fetch(import.meta.env.VITE_SERVER_URL+"/api/Trailer/getalltrailer")
.then((response) => response.json())
};

