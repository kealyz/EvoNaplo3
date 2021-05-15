import React, { Component, useEffect, useState } from 'react';
import GetObjectPropValues from '../../components/GetObjectPropValues/GetObjectPropValues';
import GetObjectPropValuesMonitor from '../../components/GetObjectPropValues/GetObjectPropValuesMonitor';
import Accordion from '../../components/Accordion/Accordion';
import ListTable from '../ListTable';

export default function StudentsPage() {
    const [data, setData] = useState([]);
    const [q, setQ] = useState("");

    useEffect(() => {
        fetch('api/Student')
            .then(response => response.json())
            .then(json => setData(json))
    }, []);

    function search(rows) {
        return rows.filter(row=>row.name.toLowerCase().indexOf(q) > -1)
    }

    return (
        <div>
            Filter: <input type="text" value={q} onChange={(e) => setQ(e.target.value)} />
            <br/>
            <br/>
            <ListTable data={search(data)}/>
        </div>
    );
}
