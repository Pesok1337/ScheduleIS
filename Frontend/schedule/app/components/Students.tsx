import Card from "antd/es/card/Card"
import { CardName } from "./Cardname"
import  Button  from "antd/es/button/button"

interface Props {
    students: Student[];
    handleDelete: (id:string) => void;
    handleOpen: (student: Student) => void;
}

export const Students = ({students, handleDelete, handleOpen}: Props) => {
    return (
        <div className="cards">
            {students.map((student : Student) => (
                <Card 
                    key={student.id} 
                    name={<CardName name={student.name} 
                    group={student.phone}/>} 
                    bordered={false}
                >
                    <p>{student.email}</p>
                    <div className="card_buttons">
                        <Button 
                            onClick={() => handleOpen(student)} 
                            style={{Flex: 1 }}
                        >
                            Редактировать
                        </Button>
                        <Button
                            onClick={() => handleDelete(student.id)}
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