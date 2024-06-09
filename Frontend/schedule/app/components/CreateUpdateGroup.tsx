import { Input, Modal } from "antd";
import { GroupRequest } from "../services/groups";
import { useEffect, useState } from "react";

interface Props {
    mode: Mode;
    values: Group;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: GroupRequest) => void;
    handleUpdate: (id: string, request: GroupRequest) => void;
}

export enum Mode {
    Create,
    Edit,
}

export const CreateUpdateGroup = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}: Props) => {
    const [name, setName] = useState<string>("");
    //const [date_start, setDate_start] = useState<string>("");

    useEffect(() => {
        setName(values.name);
        //setDate_start(values.date_start);

    }, [values]);

    const handleOnOk = async () => {
        const groupRequest = { name};
        
        mode == Mode.Create 
        ? handleCreate(groupRequest) 
        : handleUpdate(values.id, groupRequest)
    };
    return(
        <Modal title={mode === Mode.Create ? "Добавить расписание" : "Редактировать расписание"} 
        open={isModalOpen} 
        cancelText={"Отмена"}
        onOk={handleOnOk}
        onCancel={handleCancel}
    >
        <div className="group_modal">
            <Input
                value={name}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setName(e.target.value)}
                placeholder="Название"
            />
        </div>
    </Modal>
        
    )
};