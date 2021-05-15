import React, { useEffect, useState } from 'react';
import GetObjectPropValues from '../components/GetObjectPropValues/GetObjectPropValues';
import Accordion from '../components/Accordion/Accordion';
import { BsTrashFill } from 'react-icons/bs';
import { BsPencil } from 'react-icons/bs';
import './ListTable.css'

function useWindowSize() {
    const [size, setSize] = useState([window.innerHeight, window.innerWidth]);

    useEffect(() => {
        const handleResize = () => {
            setSize([window.innerHeight, window.innerWidth]);
        };
        window.addEventListener("resize", handleResize);
    }, []);

    return size;
}

function RemoveContent(row) {
    alert("Remove data with id [" + row + "]");
}

function EditContent(row) {
    alert("Edit data with id [" + row + "]");
}

export default function RenderTable({ data }) {
    const columns = data[0] && Object.keys(data[0]);
    const [height, width] = useWindowSize();

    if (width > 600) {
        return (
            <div>
                <table class="DataListTable">
                    <thead>
                        <tr>
                            {data[0] && columns.map((heading) => <th>{heading}</th>)}
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.map((row) =>
                            <tr>
                                {columns.map((column) =>
                                    <td>{row[column]}</td>
                                )}
                                <td>
                                    <BsPencil class="ActionIcon" onClick={() => EditContent(row.id)} />
                                    <BsTrashFill class="ActionIcon" onClick={() => RemoveContent(row.id)} />
                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }
    else {
        return (
            <div>
                {data.map(student =>
                    <Accordion title={student.name} content={GetObjectPropValues(student)} />
                )}
            </div>
        );
    }

}