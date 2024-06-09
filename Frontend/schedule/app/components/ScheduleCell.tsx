// src/components/ScheduleCell.tsx

import React from 'react';
import { Tooltip } from 'antd';
import { ScheduleData, Timepair } from '../services/scheduleService';

interface ScheduleCellProps {
  time: string;
  sessions: ScheduleData[];
  timeMap: { [key: string]: string };
}

const ScheduleCell: React.FC<ScheduleCellProps> = ({ time, sessions, timeMap }) => {
  const session = sessions.find(s => timeMap[s.timepairId] === time);

  return (
    <Tooltip title={session ? `${session.courseName} by ${session.teacherName}` : ''}>
      <div>
        {session ? (
          <div>
            <strong>{session.groupName}</strong> <br />
            {session.courseName} <br />
            {session.teacherName}
          </div>
        ) : null}
      </div>
    </Tooltip>
  );
};

export default ScheduleCell;
