interface Props{
    name: string;
    group: string;
}

export const CardName = ({name, group}: Props) => {
    return (
        <div style={{
            display: "flex",
            flexDirection: "row",
            alignItems: "center",
            justifyContent: "space-between",
        }}>
            <p className="card_name">{name}</p>
            <p className="card_name">{group}</p>
        </div>     
    )
}