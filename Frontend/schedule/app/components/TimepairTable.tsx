import React, { useEffect, useState } from 'react';
import { Timepair } from '../Models/Timepair';
import * as TimepairService from '../services/Timepair';
import './TimepairTable.css'; // для стилизации

const TimepairTable: React.FC = () => {
    const [timepairs, setTimepairs] = useState<Timepair[]>([]);
    const [editingId, setEditingId] = useState<string | null>(null);
    const [newId, setNewId] = useState<string>('');
    const [newStartPair, setNewStartPair] = useState('');
    const [newEndPair, setNewEndPair] = useState('');

    useEffect(() => {
        fetchTimepairs();
    }, []);

    const fetchTimepairs = async () => {
        const data = await TimepairService.getAllTimepairs();
        // Сортировка по возрастанию по id
        setTimepairs(data);
    };

    const handleEdit = (timepair: Timepair) => {
        setEditingId(timepair.id);
        setNewId(timepair.id);
        setNewStartPair(timepair.startPair);
        setNewEndPair(timepair.endPair);
    };

    const handleSave = async (id: string) => {
        await TimepairService.updateTimepair(id, { id: newId, startPair: newStartPair, endPair: newEndPair });
        setEditingId(null);
        fetchTimepairs();
    };

    const handleDelete = async (id: string) => {
        await TimepairService.deleteTimepair(id);
        fetchTimepairs();
    };

    const handleAdd = async () => {
        await TimepairService.createTimepair({ id: newId, startPair: newStartPair, endPair: newEndPair });
        setNewId('');
        setNewStartPair('');
        setNewEndPair('');
        fetchTimepairs();
    };

    return (
        <div className="container">
            <h2>Расписание пар</h2>
            <table>
                <thead>
                    <tr>
                        <th>Номер пары</th>
                        <th>Начало</th>
                        <th>Конец</th>
                        <th>Действия</th>
                    </tr>
                </thead>
                <tbody>
                    {timepairs.map((timepair, index) => (
                        <tr key={timepair.id}>
                            <td>{index + 1}</td>
                            <td>
                                {editingId === timepair.id ? (
                                    <input
                                        type="text"
                                        value={newStartPair}
                                        onChange={(e) => setNewStartPair(e.target.value)}
                                    />
                                ) : (
                                    timepair.startPair
                                )}
                            </td>
                            <td>
                                {editingId === timepair.id ? (
                                    <input
                                        type="text"
                                        value={newEndPair}
                                        onChange={(e) => setNewEndPair(e.target.value)}
                                    />
                                ) : (
                                    timepair.endPair
                                )}
                            </td>
                            <td>
                                {editingId === timepair.id ? (
                                    <button onClick={() => handleSave(timepair.id)}>Сохранить</button>
                                ) : (
                                    <button onClick={() => handleEdit(timepair)}>Редактировать</button>
                                )}
                                <button onClick={() => handleDelete(timepair.id)}>Удалить</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <h3>Добавить новую пару</h3>
            <div className="input-group">
                <input
                    type="text"
                    placeholder="ID"
                    value={newId}
                    onChange={(e) => setNewId(e.target.value)}
                />
                <input
                    type="text"
                    placeholder="Начало пары"
                    value={newStartPair}
                    onChange={(e) => setNewStartPair(e.target.value)}
                />
                <input
                    type="text"
                    placeholder="Конец пары"
                    value={newEndPair}
                    onChange={(e) => setNewEndPair(e.target.value)}
                />
                <button onClick={handleAdd}>Добавить</button>
            </div>
        </div>
    );
};

export default TimepairTable;

