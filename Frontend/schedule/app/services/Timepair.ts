export interface TimepairRequest {
    id: string;
    startPair: string;
    endPair: string; 
}

export const getAllTimepairs = async () => {
    const response = await fetch("http://localhost:5090/api/Timepair")

    return response.json();
};

export const createTimepair= async (timepairRequest: TimepairRequest) =>{
        await fetch("http://localhost:5090/api/Timepair", {
            method: "POST",
            headers: {
                "content-type": "application/json",
            },
            body: JSON.stringify(timepairRequest),
        });
}

export const updateTimepair = async (id: string, timepairRequest: TimepairRequest) => {
    await fetch(`http://localhost:5090/api/Timepair/${id}`, {
        method: "PUT",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(timepairRequest),
    });
}

export const deleteTimepair = async (id: string) => {
    await fetch(`http://localhost:5090/api/Timepair/${id}`, {
        method: "DELETE",
    });
}