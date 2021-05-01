import React, { Component } from 'react';
import GetObjectPropValues from '../../components/GetObjectPropValues/GetObjectPropValues';
import Accordion from '../../components/Accordion/Accordion';

export class StudentsPage extends Component {
    static displayName = StudentsPage.name;

    constructor(props) {
        super(props);
        this.state = { students: [], loading: true };
    }

    componentDidMount() {
        this.populateStudentsData();
    }

    static renderStudentsTable(students) {
        return (
            <div>
                {students.map(student =>
                    <Accordion title={student.name} content={GetObjectPropValues(student)} />
                )}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : StudentsPage.renderStudentsTable(this.state.students);

        return (
            <div>
                <h1 id="tabelLabel" >Student forecast :)</h1>
                <p>Pé.</p>
                {contents}
            </div>
        );
    }

    async populateStudentsData() {
        const response = await fetch('api/Student/Janik');
        const data = await response.json();
        this.setState({ students: data, loading: false });
        //fetch('api/Student')
        //    .then(response => response.json())
        //    .then(users => console.warn(users))

        //this.setState({ students: users, loading: false });
    }
}
