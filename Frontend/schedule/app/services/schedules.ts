export interface ScheduleRequest {
  date: string;
  teacherId: string;
  courseId: string;
  groupId: string;
  timepairId: number;
}

export const getAllSchedules = async () => {
    const response = await fetch("http://localhost:5090/Schedule/WithIds")

    return response.json();
};

export const createSchedule = async (scheduleRequest: ScheduleRequest) =>{
        await fetch("http://localhost:5090/Schedule", {
            method: "POST",
            headers: {
                "content-type": "application/json",
            },
            body: JSON.stringify(scheduleRequest),
        });
}

export const updateSchedule = async (id: string, scheduleRequest: ScheduleRequest) => {
    await fetch(`http://localhost:5090/Schedule/${id}`, {
        method: "PUT",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(scheduleRequest),
    });
    
}

export const deleteSchedule = async (id: string) => {
    await fetch(`http://localhost:5090/Schedule/${id}`, {
        method: "DELETE",
    });
}