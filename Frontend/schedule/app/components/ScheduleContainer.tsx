import React, { useEffect, useState } from 'react';
import ScheduleTable from './ScheduleTable';
import { fetchScheduleData, fetchTimepairs, ScheduleData, Timepair } from '../services/scheduleService';

const ScheduleContainer: React.FC = () => {
  const [scheduleData, setScheduleData] = useState<ScheduleData[]>([]);
  const [timepairs, setTimepairs] = useState<Timepair[]>([]);

  useEffect(() => {
    const loadData = async () => {
      const [scheduleData, timepairs] = await Promise.all([fetchScheduleData(), fetchTimepairs()]);
      setScheduleData(scheduleData);
      setTimepairs(timepairs);
    };

    loadData();
  }, []);

  return (
    <div>
      <h1>Расписание</h1>
      <ScheduleTable scheduleData={scheduleData} timepairs={timepairs} />
    </div>
  );
};

export default ScheduleContainer;
