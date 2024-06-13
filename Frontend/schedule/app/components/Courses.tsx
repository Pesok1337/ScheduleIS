import Card from "antd/es/card/Card"
import { CardName } from "./Cardname"
import  Button  from "antd/es/button/button"

interface Props {
    courses: Course[];
    handleDelete: (id:string) => void;
    handleOpen: (course: Course) => void;
}

export const Courses = ({courses, handleDelete, handleOpen}: Props) => {
    return (
        <div className="cards">
            {courses.map((course : Course) => (
                <Card 
                    key={course.id} 
                    title={<CardName name={course.name} group={course.description} />}
                    bordered={false}
                >
                    <p>{course.name}</p>
                    <div className="card_buttons">
                        <Button 
                            onClick={() => handleOpen(course)} 
                            style={{flex: 1 }}
                        >
                            Редактировать
                        </Button>
                        <Button
                            onClick={() => handleDelete(course.id)}
                            danger 
                            style={{flex: 1 }}
                        >
                            Удалить
                        </Button>
                    </div>
                </Card>
            ))}
        </div>
    )
}