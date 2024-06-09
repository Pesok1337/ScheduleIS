import { Input, Modal } from "antd";
import { TeacherRequest } from "../services/teachers";
import TextArea from "antd/es/input/TextArea";
import { useEffect, useState } from "react";

interface Props {
    mode: Mode;
    values: Teacher;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: TeacherRequest) => void;
    handleUpdate: (id: string, request: TeacherRequest) => void;
}

export enum Mode {
    Create,
    Edit,
}

export const CreateUpdateTeacher = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}: Props) => {
    const [name, setName] = useState<string>("");
    const [phone, setPhone] = useState<string>("");
    const [email, setEmail] = useState<string>("");

    useEffect(() => {
        setName(values.name);
        setPhone(values.phone);
        setEmail(values.email);

    }, [values]);

    const handleOnOk = async () => {
        const teacherRequest = { name, phone, email};
        
        mode == Mode.Create 
        ? handleCreate(teacherRequest) 
        : handleUpdate(values.id, teacherRequest)
    };
    return(
        <Modal title={mode === Mode.Create ? "Добавить преподавателя" : "Редактировать преподавателя"} 
        open={isModalOpen} 
        cancelText={"Отмена"}
        onOk={handleOnOk}
        onCancel={handleCancel}
    >
        <div className="teacher_modal">
            <Input
                value={name}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setName(e.target.value)}
                placeholder="ФИО"
            />
            <Input
                value={phone}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setPhone(e.target.value)}
                autoSize={{ minRows: 3, maxRows: 3}}
                placeholder="Телефон"
            />
            <Input
                value={email}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setEmail(e.target.value)}
                placeholder="email"
            />
        </div>
    </Modal>
        
    )
};