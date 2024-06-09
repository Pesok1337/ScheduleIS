// src/services/scheduleService.ts

export interface ScheduleRequest {
  date: string;
  teacherId: string;
  courseId: string;
  groupId: string;
  timepairId: number;
}
export interface ScheduleData {
  id: string;
  date: string;
  teacherName: string;
  courseName: string;
  groupName: string;
  timepairId: number;
}

export interface Timepair {
  id: number;
  startPair: string;
  endPair: string;
}

export interface NamedEntity {
  id: string;
  name: string;
}

export const getAllSchedules = async (): Promise<ScheduleRequest[]> => {
  const response = await fetch("http://localhost:5090/Schedule/WithIds");
  return response.json();
};

export const createSchedule = async (scheduleRequest: ScheduleRequest) => {
  await fetch("http://localhost:5090/Schedule", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(scheduleRequest),
  });
};

export const updateSchedule = async (id: string, scheduleRequest: ScheduleRequest) => {
  await fetch(`http://localhost:5090/Schedule/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(scheduleRequest),
  });
};

export const deleteSchedule = async (id: string) => {
  await fetch(`http://localhost:5090/Schedule/${id}`, {
    method: "DELETE",
  });
};

export const fetchScheduleData = async (): Promise<ScheduleData[]> => {
  const response = await fetch('http://localhost:5090/Schedule/WithNames');
  return response.json();
};

export const getAllGroups = async (): Promise<NamedEntity[]> => {
  const response = await fetch("http://localhost:5090/Group");
  if (!response.ok) {
    throw new Error(`Failed to fetch: ${response.statusText}`);
  }
  return response.json();
};

export const getAllCourses = async (): Promise<NamedEntity[]> => {
  const response = await fetch("http://localhost:5090/Course");
  return response.json();
};

export const getAllTeachers = async (): Promise<NamedEntity[]> => {
  const response = await fetch("http://localhost:5090/Teacher");
  return response.json();
};

export const fetchTimepairs = async (): Promise<Timepair[]> => {
  const response = await fetch('http://localhost:5090/api/Timepair');
  const timepairData = await response.json();
  return timepairData.sort((a: Timepair, b: Timepair) => a.id - b.id);
};