import React, { Component } from 'react';
import GetObjectPropValues from '../../components/GetObjectPropValues/GetObjectPropValues';
import Accordion from '../../components/Accordion/Accordion';

export class MentorsPage extends Component {
    static displayName = MentorsPage.name;

    constructor(props) {
        super(props);
        this.state = { mentors: [], loading: true };
    }

    componentDidMount() {
        this.populateMentorsData();
    }

    static renderMentorsTable(mentors) {
        return (
            <div>
                {mentors.map(mentor =>
                    <Accordion title={mentor.name} content={GetObjectPropValues(mentor)} />
                )}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : MentorsPage.renderMentorsTable(this.state.mentors);

        return (
            <div>
                <h1 id="tabelLabel" >Mentor forecast :)</h1>
                <p>Pé.</p>
                {contents}
            </div>
        );
    }

    async populateMentorsData() {
        const response = await fetch('api/Mentor');
        const data = await response.json();
        this.setState({ mentors: data, loading: false });
    }
}
