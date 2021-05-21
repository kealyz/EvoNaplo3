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



function EditContent(row,url) {
    alert("Edit data with id [" + row + "] (" + url + ")");
}

export default function RenderTable(props) {
    const columns = props.data[0] && Object.keys(props.data[0]);
    const [height, width] = useWindowSize();
    const users = props.data;

    function RemoveContent(row, url) {
        //alert("Remove data with id [" + row + "] (" + url + ")");
        url = url + "/DELETE/?ID=" + row;
        fetch(url, { method: 'DELETE' });
        window.location.reload(false);
    }

    if (width > 600) {
        return (
            <div>
                <table class="DataListTable">
                    <thead>
                        <tr>
                            {props.data[0] && columns.map((heading) => <th>{heading}</th>)}
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {users.map((row) =>
                            <tr>
                                {columns.map((column) =>
                                    <td>{row[column]}</td>
                                )}
                                <td>
                                    <BsPencil class="ActionIcon EditIcon" onClick={() => EditContent(row.id, props.url)} />
                                    <BsTrashFill class="ActionIcon RemoveIcon" onClick={() => RemoveContent(row.id, props.url)} />
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
                {props.data.map(student =>
                    <Accordion title={student.name} content={GetObjectPropValues(student)} />
                )}
            </div>
        );
    }

}