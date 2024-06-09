"use client"
import React, { useState, useEffect } from 'react';
import { Table, Button, DatePicker, Space } from 'antd';
import { ScheduleRequest, fetchScheduleData, createSchedule, updateSchedule, deleteSchedule, ScheduleData } from '../services/scheduleService';
import ScheduleForm from '../components/ScheduleForm';
import moment from 'moment';

const SchedulePage: React.FC = () => {
  const [schedules, setSchedules] = useState<ScheduleData[]>([]);
  const [selectedDate, setSelectedDate] = useState<moment.Moment | null>(null);
  const [editingSchedule, setEditingSchedule] = useState<ScheduleRequest | null>(null);
  const [isModalVisible, setIsModalVisible] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      const scheduleData = await fetchScheduleData();
      setSchedules(scheduleData);
    };
    fetchData();
  }, []);

  const handleDateChange = (date: moment.Moment | null) => {
    setSelectedDate(date);
  };

  const handleCreate = async (schedule: ScheduleRequest) => {
    await createSchedule(schedule);
    const scheduleData = await fetchScheduleData();
    setSchedules(scheduleData);
    setIsModalVisible(false);
  };

  const handleEdit = async (id: string, schedule: ScheduleRequest) => {
    await updateSchedule(id, schedule);
    const scheduleData = await fetchScheduleData();
    setSchedules(scheduleData);
    setIsModalVisible(false);
  };

  const handleDelete = async (id: string) => {
    await deleteSchedule(id);
    const scheduleData = await fetchScheduleData();
    setSchedules(scheduleData);
  };

  /*const handleModal = (schedule?: ScheduleRequest) => {
    setEditingSchedule(schedule);
    setIsModalVisible(true);
  };*/

  const filteredSchedules = selectedDate
    ? schedules.filter(schedule => moment(schedule.date).isSame(selectedDate, 'day'))
    : schedules;

  const columns = [
    {
      title: 'Дата',
      dataIndex: 'date',
      key: 'date',
      render: (text: string) => moment(text).format('DD-MM-YYYY'),
    },
    {
      title: 'Учитель',
      dataIndex: 'teacherName',
      key: 'teacherName',
    },
    {
      title: 'Курс',
      dataIndex: 'courseName',
      key: 'courseName',
    },
    {
      title: 'Группа',
      dataIndex: 'groupName',
      key: 'groupName',
    },
    {
      title: 'Временная пара',
      dataIndex: 'timepairId',
      key: 'timepairId',
    },
    {
      title: 'Действия',
      key: 'actions',
      render: (_: any, record: ScheduleData) => (
        <Space>
          <Button onClick={() => setEditingSchedule({ 
            date: record.date, 
            teacherId: record.teacherName, 
            courseId: record.courseName, 
            groupId: record.groupName, 
            timepairId: record.timepairId 
          })}>
            Редактировать
          </Button>
          <Button onClick={() => handleDelete(record.id)} danger>
            Удалить
          </Button>
        </Space>
      ),
    },
  ];

  return (
    <div>
      <h1>Расписание</h1>
      <Space direction="vertical">
        <ScheduleForm initialData={editingSchedule} onSubmit={handleCreate} />
        <DatePicker onChange={handleDateChange} />
      </Space>
      <Table dataSource={filteredSchedules} columns={columns} rowKey="id" />
    </div>/*
    <div>
      <h1>Расписание</h1>
      <Space direction="vertical">
        <Button onClick={() => handleModal()}>Создать расписание</Button>
        <DatePicker onChange={handleDateChange} />
      </Space>
      <Table dataSource={filteredSchedules} columns={columns} rowKey="id" />

      <Modal
        title={editingSchedule ? 'Редактировать расписание' : 'Создать расписание'}
        visible={isModalVisible}
        onCancel={() => setIsModalVisible(false)}
        footer={null}
      >
        <ScheduleForm initialData={editingSchedule} onSubmit={handleCreate} onEdit={handleEdit} />
      </Modal>
    </div>*/
  );
};

export default SchedulePage;


