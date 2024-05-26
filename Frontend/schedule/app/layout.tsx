import { Flex, Layout, Menu } from "antd";
import "./globals.css";
import Link from "next/link";
import { Content, Footer, Header } from "antd/es/layout/layout";

const items = [
  {key: "home", label : <Link href={"/"}>Home</Link> },
  {key: "schedule", label : <Link href={"/schedules"}>Schedule</Link> }, 
  {key: "groups", label : <Link href={"/groups"}>Groups</Link> },
  {key: "courses", label : <Link href={"/courses"}>Courses</Link> },
  {key: "teachers", label : <Link href={"/teachers"}>Teachers</Link> },
  {key: "students", label : <Link href={"/students"}>Students</Link> },
];

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <Layout style={{minHight: "100vh"}}>
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
