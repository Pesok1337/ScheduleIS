"use client";

  import  Button  from "antd/es/button/button"
  import { Students } from "../components/Students";
  import { useEffect, useState } from "react";
  import { StudentRequest, createStudent, deleteStudent, getAllStudents, updateStudent } from "../services/students";
  import Title from "antd/es/skeleton/Title";
  import { CreateUpdateStudent, Mode } from "../components/CreateUpdateStudent";

export default function StudentsPage() {
      const defaultValues = {
          name: "",
          phone:"",
          email:"", 
      } as Student;
  
      const [values, setValues] = useState<Student>(defaultValues);
  
  
      const [students, setStudents] = useState<Student[]>([]);
      const [loading, setLoading] = useState(true);
      const [isModalOpen, setIsModalOpen] = useState(false);
      const [mode, setMode] = useState(Mode.Create);
  
      useEffect(() => {
          const getStudents = async () => {
              const students = await getAllStudents();
              setLoading(false);
              setStudents(students);
          }
          getStudents();
      }, [])
  
      const handleCreateStudent = async (request: StudentRequest) => {
          await createStudent(request);
          closeModal();
  
          const student = await getAllStudents();
          setStudents(students);
      }
  
      const handleUpdateStudent = async (id: string, request: StudentRequest) => {
          await updateStudent(id, request)
          closeModal();
  
          const students = await getAllStudents();
          setStudents(students);
      }
  
      const openModal = () => {
          setMode(Mode.Create);
          setIsModalOpen(true);
      }
  
      const closeModal = () => {
          setValues(defaultValues);
          setIsModalOpen(false);
      }
  
      const openEditModal = (student: Student) => {
          setMode(Mode.Edit);
          setValues(student);
          setIsModalOpen(true);
      };
  
      const handleDeleteStudent = async (id: string) => {
          await deleteStudent(id);
          closeModal();
  
          const students = await getAllStudents();
          setStudents(students);
      }
  
  
      
      return (
          <div>
              <Button
                  type="primary"
                  style={{ marginTop: "30px"}}
                  size="large"
                  onClick={openModal}
              >Добавить студента</Button>
  
              <CreateUpdateStudent
                  mode={mode} values={values} 
                  isModalOpen={isModalOpen} 
                  handleCreate={handleCreateStudent} 
                  handleUpdate={handleUpdateStudent} 
                  handleCancel={closeModal}
              />  
              
  
              {loading ? <Title>Loading....</Title> : <Students 
                  students = {students} 
                  handleOpen={openEditModal} 
                  handleDelete={handleDeleteStudent}
              />}
          </div>
      )
  }