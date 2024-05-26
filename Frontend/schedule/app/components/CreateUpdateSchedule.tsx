import { Input, Modal } from "antd";
import { ScheduleRequest } from "../services/schedules";
import TextArea from "antd/es/input/TextArea";
import { useEffect, useState } from "react";

interface Props {
    mode: Mode;
    values: Schedule;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: ScheduleRequest) => void;
    handleUpdate: (id: string, request: ScheduleRequest) => void;
}

export enum Mode {
    Create,
    Edit,
}

export const CreateUpdateSchedule = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}: Props) => {
    const [name, setName] = useState<string>("");
    const [group, setGroup] = useState<string>("");
    const [description, setDescription] = useState<string>("");

    useEffect(() => {
        setName(values.name);
        setGroup(values.group);
        setDescription(values.description);

    }, [values]);

    const handleOnOk = async () => {
        const scheduleRequest = { name, group, description};
        
        mode == Mode.Create 
        ? handleCreate(scheduleRequest) 
        : handleUpdate(values.id, scheduleRequest)
    };
    return(
        <Modal title={mode === Mode.Create ? "Добавить расписание" : "Редактировать расписание"} 
        open={isModalOpen} 
        cancelText={"Отмена"}
        onOk={handleOnOk}
        onCancel={handleCancel}
    >
        <div className="schedule_modal">
            <Input
                value={name}
                onChange={(e) => setName(e.target.value)}
                placeholder="Название"
            />
            <TextArea
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                autoSize={{ minRows: 3, maxRows: 3}}
                placeholder="Описание"
            />
            <Input
                value={group}
                onChange={(e) => setGroup(e.target.value)}
                placeholder="Группа"
            />
        </div>
    </Modal>
        
    )
};