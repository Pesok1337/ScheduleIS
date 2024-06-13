  "use client";

  import  Button  from "antd/es/button/button"
  import { Courses } from "../components/Courses";
  import { useEffect, useState } from "react";
  import { CourseRequest, createCourse, deleteCourse, getAllCourses, updateCourse } from "../services/courses";
  import Title from "antd/es/skeleton/Title";
  import { CreateUpdateCourse, Mode } from "../components/CreateUpdateCourse";

export default function CoursesPage() {
      const defaultValues = {
          name: "",
          description: "",
          duration:0,
          status: false,
      } as Course;
  
      const [values, setValues] = useState<Course>(defaultValues);
      const [сourses, setCourses] = useState<Course[]>([]);
      const [loading, setLoading] = useState(true);
      const [isModalOpen, setIsModalOpen] = useState(false);
      const [mode, setMode] = useState(Mode.Create);
  
      useEffect(() => {
          const getCourses = async () => {
              const сourses = await getAllCourses();
              setLoading(false);
              setCourses(сourses);
          }
          getCourses();
      }, [])
  
      const handleCreateCourse = async (request: CourseRequest) => {
          await createCourse(request);
          closeModal();
  
          const сourses = await getAllCourses();
          setCourses(сourses);
      }
  
      const handleUpdateCourse = async (id: string, request: CourseRequest) => {
          await updateCourse(id, request)
          closeModal();
  
          const сourses = await getAllCourses();
          setCourses(сourses);
      }
  
      const openModal = () => {
          setMode(Mode.Create);
          setIsModalOpen(true);
      }
  
      const closeModal = () => {
          setValues(defaultValues);
          setIsModalOpen(false);
      }
  
      const openEditModal = (сourse: Course) => {
          setMode(Mode.Edit);
          setValues(сourse);
          setIsModalOpen(true);
      };
  
      const handleDeleteCourse = async (id: string) => {
          await deleteCourse(id);
          closeModal();
  
          const сourses = await getAllCourses();
          setCourses(сourses);
      }
  
  
      
      return (
          <div>
              <Button
                  type="primary"
                  style={{ marginTop: "30px"}}
                  size="large"
                  onClick={openModal}
              >Добавить курс</Button>
  
              <CreateUpdateCourse
                  mode={mode} values={values} 
                  isModalOpen={isModalOpen} 
                  handleCreate={handleCreateCourse} 
                  handleUpdate={handleUpdateCourse} 
                  handleCancel={closeModal}
              />  
              {loading ? <div>Loading....</div> : <Courses 
                courses = {сourses} 
                handleOpen={openEditModal} 
                handleDelete={handleDeleteCourse}
                />}
          </div>
      )
  }