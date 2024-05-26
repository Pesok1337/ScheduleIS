export interface TeacherRequest {
    name: string 
    phone:string; 
    email: string;
}

export const getAllTeachers = async () => {
    const response = await fetch("http://localhost:5090/Teacher")

    return response.json();
};

export const createTeacher = async (teacherRequest: TeacherRequest) =>{
        await fetch("http://localhost:5090/Teacher", {
            method: "POST",
            headers: {
                "content-type": "application/json",
            },
            body: JSON.stringify(teacherRequest),
        });
}

export const updateTeacher = async (id: string, teacherRequest: TeacherRequest) => {
    await fetch(`http://localhost:5090/Teacher/${id}`, {
        method: "PUT",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(teacherRequest),
    });
    
}

export const deleteTeacher = async (id: string) => {
    await fetch(`http://localhost:5090/Teacher/${id}`, {
        method: "DELETE",
    });
}