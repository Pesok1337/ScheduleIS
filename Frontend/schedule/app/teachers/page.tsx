"use client";

  import  Button  from "antd/es/button/button"
  import { Teachers } from "../components/Teachers";
  import { useEffect, useState } from "react";
  import { TeacherRequest, createTeacher, deleteTeacher, getAllTeachers, updateTeacher } from "../services/teachers";
  import Title from "antd/es/skeleton/Title";
  import { CreateUpdateTeacher, Mode } from "../components/CreateUpdateTeacher";

export default function TeachersPage() {
      const defaultValues = {
          name: "",
          phone:"",
          email:"", 
      } as Teacher;
  
      const [values, setValues] = useState<Teacher>(defaultValues);
  
  
      const [teachers, setTeachers] = useState<Teacher[]>([]);
      const [loading, setLoading] = useState(true);
      const [isModalOpen, setIsModalOpen] = useState(false);
      const [mode, setMode] = useState(Mode.Create);
  
      useEffect(() => {
          const getTeachers = async () => {
              const teachers = await getAllTeachers();
              setLoading(false);
              setTeachers(teachers);
          }
          getTeachers();
      }, [])
  
      const handleCreateTeacher = async (request: TeacherRequest) => {
          await createTeacher(request);
          closeModal();
  
          const teachers = await getAllTeachers();
          setTeachers(teachers);
      }
  
      const handleUpdateTeacher = async (id: string, request: TeacherRequest) => {
          await updateTeacher(id, request)
          closeModal();
  
          const teachers = await getAllTeachers();
          setTeachers(teachers);
      }
  
      const openModal = () => {
          setMode(Mode.Create);
          setIsModalOpen(true);
      }
  
      const closeModal = () => {
          setValues(defaultValues);
          setIsModalOpen(false);
      }
  
      const openEditModal = (teacher: Teacher) => {
          setMode(Mode.Edit);
          setValues(teacher);
          setIsModalOpen(true);
      };
  
      const handleDeleteTeacher = async (id: string) => {
          await deleteTeacher(id);
          closeModal();
  
          const teachers = await getAllTeachers();
          setTeachers(teachers);
      }
  
      return (
          <div>
              <Button
                  type="primary"
                  style={{ marginTop: "30px"}}
                  size="large"
                  onClick={openModal}
              >Добавить преподавателя</Button>
  
              <CreateUpdateTeacher
                  mode={mode} values={values} 
                  isModalOpen={isModalOpen} 
                  handleCreate={handleCreateTeacher} 
                  handleUpdate={handleUpdateTeacher} 
                  handleCancel={closeModal}
              />  
              {loading ? <div>Loading....</div> : <Teachers 
                teachers = {teachers} 
                handleOpen={openEditModal} 
                handleDelete={handleDeleteTeacher}
                />}
          </div>
      )
  }