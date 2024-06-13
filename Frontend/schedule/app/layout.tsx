import { Flex, Layout, Menu } from "antd";
import "./globals.css";
import Link from "next/link";
import { Content, Footer, Header } from "antd/es/layout/layout";

const items = [
  {key: "home", label : <Link href={"/"}>Главная</Link> },
  {key: "schedule", label : <Link href={"/schedules"}>Расписание</Link> },
  {key: "scheduleadd", label : <Link href={"/scheduleadd"}>Добавить расписание</Link> },  
  {key: "groups", label : <Link href={"/groups"}>Группы</Link> },
  {key: "courses", label : <Link href={"/courses"}>Курсы</Link> },
  {key: "teachers", label : <Link href={"/teachers"}>Учителя</Link> },
  {key: "timepair", label : <Link href={"/timepairs"}>Расписание пар</Link> },
];

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <Layout style={{minHeight: "100vh"}}>
          <Header>
            <Menu 
              theme="dark" 
              mode="horizontal" 
              items={items} 
              style={{ flex: 1, minWidth:0}}
            />
          </Header>
          <Content style={{ padding: "0 48px"}}>{children}</Content>
          <Footer style={{ textAlign: "center"}}>
            Schedule 2024 created by Peshanov Ilya
          </Footer>
        </Layout>
        </body>
    </html>
  );
}
