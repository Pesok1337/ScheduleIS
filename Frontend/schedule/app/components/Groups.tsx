import Card from "antd/es/card/Card"
import { CardName } from "./Cardname"
import  Button  from "antd/es/button/button"

interface Props {
    groups: Group[];
    handleDelete: (id:string) => void;
    handleOpen: (group: Group) => void;
}

export const Groups = ({groups, handleDelete, handleOpen}: Props) => {
    return (
        <div className="cards">
            {groups.map((group : Group) => (
                <Card 
                    key={group.id} 
                    name={<CardName name={group.name} 
                    group={group.name}/>} 
                    bordered={false}
                >
                    <p>{group.name}</p>
                    <div className="card_buttons">
                        <Button 
                            onClick={() => handleOpen(group)} 
                            style={{Flex: 1 }}
                        >
                            Редактировать
                        </Button>
                        <Button
                            onClick={() => handleDelete(group.id)}
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