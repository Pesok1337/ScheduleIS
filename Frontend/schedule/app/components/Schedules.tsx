import Card from "antd/es/card/Card"
import { CardName } from "./Cardname"
import  Button  from "antd/es/button/button"

interface Props {
    schedules: Schedule[];
    handleDelete: (id:string) => void;
    handleOpen: (schedule: Schedule) => void;
}

export const Schedules = ({schedules, handleDelete, handleOpen}: Props) => {
    return (
        <div className="cards">
            {schedules.map((schedule : Schedule) => (
                <Card 
                    key={schedule.id} 
                    name={<CardName name={schedule.name} 
                    group={schedule.group}/>} 
                    bordered={false}
                >
                    <p>{schedule.description}</p>
                    <div className="card_buttons">
                        <Button 
                            onClick={() => handleOpen(schedule)} 
                            style={{Flex: 1 }}
                        >
                            Редактировать
                        </Button>
                        <Button
                            onClick={() => handleDelete(schedule.id)}
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