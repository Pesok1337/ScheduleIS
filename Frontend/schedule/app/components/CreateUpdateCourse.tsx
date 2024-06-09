import { Input, Modal } from "antd";
import { CourseRequest } from "../services/courses";
import { useEffect, useState } from "react";

interface Props {
    mode: Mode;
    values: Course;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: CourseRequest) => void;
    handleUpdate: (id: string, request: CourseRequest) => void;
}

export enum Mode {
    Create,
    Edit,
}

export const CreateUpdateCourse = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}: Props) => {
    const [name, setName] = useState<string>("");
    const [description, setDescription] = useState<string>("");
    const [duration, setDuration] = useState<number>(0);
    const [status, setStatus] = useState<boolean>(true);

    useEffect(() => {
        setName(values.name);
        setDescription(values.description);
        setDuration(values.duration);
        setStatus(values.status);

    }, [values]);

    const handleOnOk = async () => {
        const courseRequest = { name, description,duration, status};
        
        mode == Mode.Create 
        ? handleCreate(courseRequest) 
        : handleUpdate(values.id, courseRequest)
    };
    return(
        <Modal title={mode === Mode.Create ? "Добавить курс" : "Редактировать курс"} 
        open={isModalOpen} 
        cancelText={"Отмена"}
        onOk={handleOnOk}
        onCancel={handleCancel}
    >
        <div className="course_modal">
            <Input
                value={name}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setName(e.target.value)}
                placeholder="Название"
            />
            <Input
                value={description}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setDescription(e.target.value)}
                placeholder="Описание"
            />
            <Input
                value={duration.toString()}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setDuration(parseInt(e.target.value))}
                placeholder="Длительность"
            />
            <Input
                value={status ? "true" : "false"} // Convert boolean to string
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setStatus(e.target.value === "true")} // Convert string to boolean
                placeholder="Статус"
            />
        </div>
    </Modal>
        
    )
};