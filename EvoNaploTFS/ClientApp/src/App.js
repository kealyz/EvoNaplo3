import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { StudentsPage } from './AppPages/StudentListPage/StudentsPage'
import { ProjectsPage } from './AppPages/ProjectListPage/ProjectsPage'

import './custom.css'
import './components/Accordion.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/Students' component={StudentsPage} />
        <Route path='/Projects' component={ProjectsPage} />
      </Layout>
    );
  }
}
