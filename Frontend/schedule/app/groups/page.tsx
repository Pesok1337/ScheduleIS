  "use client";

  import  Button  from "antd/es/button/button"
  import { Groups } from "../components/Groups";
  import { useEffect, useState } from "react";
  import { GroupRequest, createGroup, deleteGroup, getAllGroups, updateGroup } from "../services/groups";
  import Title from "antd/es/skeleton/Title";
  import { CreateUpdateGroup, Mode } from "../components/CreateUpdateGroup";

export default function GroupsPage() {
      const defaultValues = {
          name: "",
      } as Group;
  
      const [values, setValues] = useState<Group>(defaultValues);
  
  
      const [groups, setGroups] = useState<Group[]>([]);
      const [loading, setLoading] = useState(true);
      const [isModalOpen, setIsModalOpen] = useState(false);
      const [mode, setMode] = useState(Mode.Create);
  
      useEffect(() => {
          const getGroups = async () => {
              const groups = await getAllGroups();
              setLoading(false);
              setGroups(groups);
          }
          getGroups();
      }, [])
  
      const handleCreateGroup = async (request: GroupRequest) => {
          await createGroup(request);
          closeModal();
  
          const groups = await getAllGroups();
          setGroups(groups);
      }
  
      const handleUpdateGroup = async (id: string, request: GroupRequest) => {
          await updateGroup(id, request)
          closeModal();
  
          const groups = await getAllGroups();
          setGroups(groups);
      }
  
      const openModal = () => {
          setMode(Mode.Create);
          setIsModalOpen(true);
      }
  
      const closeModal = () => {
          setValues(defaultValues);
          setIsModalOpen(false);
      }
  
      const openEditModal = (group: Group) => {
          setMode(Mode.Edit);
          setValues(group);
          setIsModalOpen(true);
      };
  
      const handleDeleteGroup = async (id: string) => {
          await deleteGroup(id);
          closeModal();
  
          const groups = await getAllGroups();
          setGroups(groups);
      }
  
  
      
      return (
          <div>
              <Button
                  type="primary"
                  style={{ marginTop: "30px"}}
                  size="large"
                  onClick={openModal}
              >Добавить группу</Button>
  
              <CreateUpdateGroup
                  mode={mode} values={values} 
                  isModalOpen={isModalOpen} 
                  handleCreate={handleCreateGroup} 
                  handleUpdate={handleUpdateGroup} 
                  handleCancel={closeModal}
              />  
              
  
              {loading ? <Title>Loading....</Title> : <Groups 
                  groups = {groups} 
                  handleOpen={openEditModal} 
                  handleDelete={handleDeleteGroup}
              />}
          </div>
      )
  }