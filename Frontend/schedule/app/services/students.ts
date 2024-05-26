export interface StudentRequest {
    name: string 
    phone:string; 
    email: string;
}

export const getAllStudents = async () => {
    const response = await fetch("http://localhost:5090/Student")

    return response.json();
};

export const createStudent = async (studentRequest: StudentRequest) =>{
        await fetch("http://localhost:5090/Student", {
            method: "POST",
            headers: {
                "content-type": "application/json",
            },
            body: JSON.stringify(studentRequest),
        });
}

export const updateStudent = async (id: string, studentRequest: StudentRequest) => {
    await fetch(`http://localhost:5090/Student/${id}`, {
        method: "PUT",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(studentRequest),
    });
    
}

export const deleteStudent = async (id: string) => {
    await fetch(`http://localhost:5090/Student/${id}`, {
        method: "DELETE",
    });
}