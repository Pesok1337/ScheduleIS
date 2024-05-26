import { Input, Modal } from "antd";
import { StudentRequest } from "../services/students";
import TextArea from "antd/es/input/TextArea";
import { useEffect, useState } from "react";

interface Props {
    mode: Mode;
    values: Student;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: StudentRequest) => void;
    handleUpdate: (id: string, request: StudentRequest) => void;
}

export enum Mode {
    Create,
    Edit,
}

export const CreateUpdateStudent = ({
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
        const studentRequest = { name, phone, email};
        
        mode == Mode.Create 
        ? handleCreate(studentRequest) 
        : handleUpdate(values.id, studentRequest)
    };
    return(
        <Modal title={mode === Mode.Create ? "Добавить студента" : "Редактировать студента"} 
        open={isModalOpen} 
        cancelText={"Отмена"}
        onOk={handleOnOk}
        onCancel={handleCancel}
    >
        <div className="student_modal">
            <Input
                value={name}
                onChange={(e) => setName(e.target.value)}
                placeholder="ФИО"
            />
            <Input
                value={phone}
                onChange={(e) => setPhone(e.target.value)}
                autoSize={{ minRows: 3, maxRows: 3}}
                placeholder="Телефон"
            />
            <Input
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                placeholder="email"
            />
        </div>
    </Modal>
        
    )
};