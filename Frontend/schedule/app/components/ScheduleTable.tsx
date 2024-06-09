// src/components/ScheduleTable.tsx

import React from 'react';
import { Table, Tooltip } from 'antd';
import { ScheduleData, Timepair } from '../services/scheduleService';

interface ScheduleTableProps {
  scheduleData: ScheduleData[];
  timepairs: Timepair[];
}

const ScheduleTable: React.FC<ScheduleTableProps> = ({ scheduleData, timepairs }) => {
  const startOfWeek = new Date();
  startOfWeek.setDate(startOfWeek.getDate() - startOfWeek.getDay() + 1);
  const dates = Array.from({ length: 7 }, (_, i) => {
    const date = new Date(startOfWeek);
    date.setDate(startOfWeek.getDate() + i);
    return date;
  });

  const columns = [
    {
      title: 'Время',
      dataIndex: 'time',
      key: 'time',
    },
    ...dates.map(date => ({
      title: date.toLocaleDateString('ru-RU', { day: '2-digit', month: '2-digit' }),
      dataIndex: date.toISOString(),
      key: date.toISOString(),
      render: (text: string, record: any) => {
        const session = scheduleData.find(s => {
          const sessionDate = new Date(s.date).toLocaleDateString('ru-RU', { day: '2-digit', month: '2-digit' });
          return sessionDate === date.toLocaleDateString('ru-RU', { day: '2-digit', month: '2-digit' }) && s.timepairId === record.timepairId;
        });

        return session ? (
          <Tooltip title={`${session.courseName} by ${session.teacherName}`}>
            <div>
              <strong>{session.groupName}</strong> <br />
              {session.courseName} <br />
              {session.teacherName}
            </div>
          </Tooltip>
        ) : null;
      },
    })),
  ];

  const data = timepairs.map(tp => ({
    key: tp.id,
    time: `${tp.startPair} - ${tp.endPair}`,
    timepairId: tp.id,
  }));

  return <Table columns={columns} dataSource={data} pagination={false} />;
};

export default ScheduleTable;
