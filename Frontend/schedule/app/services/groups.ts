export interface GroupRequest {
    name: string 
    description:string; 
    //group: string;
}

export const getAllGroups = async () => {
    const response = await fetch("http://localhost:5090/Group")

    return response.json();
};

export const createGroup = async (groupRequest: GroupRequest) =>{
        await fetch("http://localhost:5090/Group", {
            method: "POST",
            headers: {
                "content-type": "application/json",
            },
            body: JSON.stringify(groupRequest),
        });
}

export const updateGroup = async (id: string, groupRequest: GroupRequest) => {
    await fetch(`http://localhost:5090/Group/${id}`, {
        method: "PUT",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(groupRequest),
    });
    
}

export const deleteGroup = async (id: string) => {
    await fetch(`http://localhost:5090/Group/${id}`, {
        method: "DELETE",
    });
}