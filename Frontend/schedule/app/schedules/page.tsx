/*"use client";

import  Button  from "antd/es/button/button"
import { Schedules } from "../components/Schedules";
import { useEffect, useState } from "react";
import { ScheduleRequest, createSchedule, deleteSchedule, getAllSchedules, updateSchedule } from "../services/schedules";
import Title from "antd/es/skeleton/Title";
import { CreateUpdateSchedule, Mode } from "../components/CreateUpdateSchedule";

export default function SchedulePage() {
    const defaultValues = {
        name: "",
        group:"",
        description:"", 
    } as Schedule;

    const [values, setValues] = useState<Schedule>(defaultValues);


    const [schedules, setSchedules] = useState<Schedule[]>([]);
    const [loading, setLoading] = useState(true);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [mode, setMode] = useState(Mode.Create);

    useEffect(() => {
        const getSchedules = async () => {
            const schedules = await getAllSchedules();
            setLoading(false);
            setSchedules(schedules);
        }
        getSchedules();
    }, [])

    const handleCreateSchedule = async (request: ScheduleRequest) => {
        await createSchedule(request);
        closeModal();

        const schedules = await getAllSchedules();
        setSchedules(schedules);
    }

    const handleUpdateSchedule = async (id: string, request: ScheduleRequest) => {
        await updateSchedule(id, request)
        closeModal();

        const schedules = await getAllSchedules();
        setSchedules(schedules);
    }

    const openModal = () => {
        setMode(Mode.Create);
        setIsModalOpen(true);
    }

    const closeModal = () => {
        setValues(defaultValues);
        setIsModalOpen(false);
    }

    const openEditModal = (schedule: Schedule) => {
        setMode(Mode.Edit);
        setValues(schedule);
        setIsModalOpen(true);
    };

    const handleDeleteSchedule = async (id: string) => {
        await deleteSchedule(id);
        closeModal();

        const schedules = await getAllSchedules();
        setSchedules(schedules);
    }


    
    return (
        <div>
            <Button
                type="primary"
                style={{ marginTop: "30px"}}
                size="large"
                onClick={openModal}
            >Добавить расписание</Button>

            <CreateUpdateSchedule 
                mode={mode} values={values} 
                isModalOpen={isModalOpen} 
                handleCreate={handleCreateSchedule} 
                handleUpdate={handleUpdateSchedule} 
                handleCancel={closeModal}
            />  
            

            {loading ? <Title>Loading....</Title> : <Schedules 
                schedules = {schedules} 
                handleOpen={openEditModal} 
                handleDelete={handleDeleteSchedule}
            />}
        </div>
    )
}
*/
"use client";
// src/pages/Schedules.tsx

import React from 'react';
import ScheduleContainer from '../components/ScheduleContainer';

const Schedules: React.FC = () => {
  return (
    <div>
      <h1>Расписание на неделю</h1>
      <ScheduleContainer />
    </div>
  );
};

export default Schedules;




