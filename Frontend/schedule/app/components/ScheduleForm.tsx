import React, { useState, useEffect } from 'react';
import { Form, Button, DatePicker, Select } from 'antd';
import { getAllCourses, getAllGroups, getAllTeachers, fetchTimepairs, ScheduleRequest, NamedEntity, Timepair } from '../services/scheduleService';
import moment from 'moment';

interface ScheduleFormProps {
    initialData?: ScheduleRequest | null;
    onSubmit: (values: ScheduleRequest) => Promise<void>;
  }
  
  const ScheduleForm: React.FC<ScheduleFormProps> = ({ initialData, onSubmit }) => {
    const [form] = Form.useForm();
    const [courses, setCourses] = useState<NamedEntity[]>([]);
    const [groups, setGroups] = useState<NamedEntity[]>([]);
    const [teachers, setTeachers] = useState<NamedEntity[]>([]);
    const [timepairs, setTimepairs] = useState<Timepair[]>([]);
  
    useEffect(() => {
      const fetchData = async () => {
        const courseData = await getAllCourses();
        setCourses(courseData);
        const groupData = await getAllGroups();
        setGroups(groupData);
        const teacherData = await getAllTeachers();
        setTeachers(teacherData);
        const timepairData = await fetchTimepairs();
        setTimepairs(timepairData);
      };
      fetchData();
    }, []);
  
    useEffect(() => {
      if (initialData) {
        form.setFieldsValue({
          ...initialData,
          date: moment(initialData.date),
        });
      }
    }, [initialData, form]);
  
    const onFinish = async (values: any) => {
        const formattedDate = moment(values.date.toDate()).utc().format('YYYY-MM-DDTHH:mm:ss[Z]');
        console.log(formattedDate);
        console.log(values.date);
        const scheduleRequest: ScheduleRequest = {
          date: formattedDate,
          teacherId: values.teacherId,
          courseId: values.courseId,
          groupId: values.groupId,
          timepairId: values.timepairId,
        };
      
        await onSubmit(scheduleRequest);
        form.resetFields();
      };
  
    return (
      <Form
        form={form}
        name="scheduleForm"
        layout="vertical"
        onFinish={onFinish}
      >
        <Form.Item
          label="Дата и время"
          name="date"
          rules={[{ required: true, message: 'Выберите дату' }]}
        >
          <DatePicker showTime format="DD-MM-YYYY" value={moment.utc(initialData?.date)} />
        </Form.Item>
  
        <Form.Item
          label="Имя учителя"
          name="teacherId"
          rules={[{ required: true, message: 'Выберите имя учителя' }]}
        >
          <Select>
            {teachers.map(teacher => (
              <option key={teacher.id} value={teacher.id}>{teacher.name}</option>
            ))}
          </Select>
        </Form.Item>
  
        <Form.Item
          label="Название курса"
          name="courseId"
          rules={[{ required: true, message: 'Выберите название курса' }]}
        >
          <Select>
            {courses.map(course => (
              <option key={course.id} value={course.id}>{course.name}</option>
            ))}
          </Select>
        </Form.Item>
  
        <Form.Item
          label="Название группы"
          name="groupId"
          rules={[{ required: true, message: 'Выберите название группы' }]}
        >
          <Select>
            {groups.map(group => (
              <option key={group.id} value={group.id}>{group.name}</option>
            ))}
          </Select>
        </Form.Item>
  
        <Form.Item
          label="ID временной пары"
          name="timepairId"
          rules={[{ required: true, message: 'Выберите ID временной пары' }]}
        >
          <Select>
            {timepairs.map(timepair => (
              <option key={timepair.id} value={timepair.id}>
                {timepair.startPair} - {timepair.endPair}
              </option>
            ))}
          </Select>
        </Form.Item>
  
        <Form.Item>
          <Button type="primary" htmlType="submit">
            {initialData ? 'Обновить' : 'Создать'} расписание
          </Button>
        </Form.Item>
      </Form>
    );
  };
  
  export default ScheduleForm;
