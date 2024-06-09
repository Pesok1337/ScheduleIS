import Card from "antd/es/card/Card"
import { CardName } from "./Cardname"
import  Button  from "antd/es/button/button"

interface Props {
    teachers: Teacher[];
    handleDelete: (id:string) => void;
    handleOpen: (teacher: Teacher) => void;
}

export const Teachers = ({teachers, handleDelete, handleOpen}: Props) => {
    return (
        <div className="cards">
            {teachers.map((teacher : Teacher) => (
                <Card 
                    key={teacher.id} 
                    name={<CardName name={teacher.phone} 
                    group={teacher.email}/>} 
                    bordered={false}
                >
                    <p>{teacher.name}</p>
                    <div className="card_buttons">
                        <Button 
                            onClick={() => handleOpen(teacher)} 
                            style={{Flex: 1 }}
                        >
                            Редактировать
                        </Button>
                        <Button
                            onClick={() => handleDelete(teacher.id)}
                            danger 
                            style={{Flex: 1 }}
                        >
                            Удалить
                        </Button>
                    </div>
                </Card>
            ))}
        </div>
    )
}