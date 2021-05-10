import React, { Component } from 'react';
import GetObjectPropValues from '../../components/GetObjectPropValues/GetObjectPropValues';
import Accordion from '../../components/Accordion/Accordion';

export class AdminsPage extends Component {
    static displayName = AdminsPage.name;

    constructor(props) {
        super(props);
        this.state = { admins: [], loading: true };
    }

    componentDidMount() {
        this.populateAdminsData();
    }

    static renderAdminsTable(admins) {
        return (
            <div>
                {admins.map(admin =>
                    <Accordion title={admin.name} content={GetObjectPropValues(admin)} />
                )}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AdminsPage.renderAdminsTable(this.state.admins);

        return (
            <div>
                <h1 id="tabelLabel" >Admin forecast :)</h1>
                <p>Pé.</p>
                {contents}
            </div>
        );
    }

    async populateAdminsData() {
        const response = await fetch('api/Admin');
        const data = await response.json();
        this.setState({ admins: data, loading: false });
        //fetch('api/Student')
        //    .then(response => response.json())
        //    .then(users => console.warn(users))

        //this.setState({ students: users, loading: false });
    }
}
