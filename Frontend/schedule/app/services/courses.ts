export interface CourseRequest {
    name: string; 
    description:string;
    duration: number; 
    status: boolean;
}

export const getAllCourses = async () => {
    const response = await fetch("http://localhost:5090/Course")

    return response.json();
};

export const createCourse = async (courseRequest: CourseRequest) =>{
        await fetch("http://localhost:5090/Course", {
            method: "POST",
            headers: {
                "content-type": "application/json",
            },
            body: JSON.stringify(courseRequest),
        });
}

export const updateCourse = async (id: string, courseRequest: CourseRequest) => {
    await fetch(`http://localhost:5090/Course/${id}`, {
        method: "PUT",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(courseRequest),
    });
    
}

export const deleteCourse = async (id: string) => {
    await fetch(`http://localhost:5090/Course/${id}`, {
        method: "DELETE",
    });
}