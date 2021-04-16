import React, { Component } from 'react';
import GetObjectPropValues from './GetObjectPropValues/GetObjectPropValues';
import Accordion from './accordion/Accordion';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecasts) {
      return (
          <div>
              {forecasts.map(forecast =>
                  <Accordion title={forecast.date} content={GetObjectPropValues(forecast)}/>                
              )}
          </div>
      //<table className='table table-striped' aria-labelledby="tabelLabel">
      //  <thead>
      //    <tr>
      //      <th>Adatok</th>
      //    </tr>
      //  </thead>
      //  <tbody>
      //    {forecasts.map(forecast =>
      //        <tr key={forecast.date}>
      //            <td className="accordionHolder">
      //                <label htmlFor={forecast.date} className="accordionTitle">{forecast.date}</label>
      //                <input type="checkbox" id={forecast.date} name="accordion_input" className="accordionInput" />
      //                <div className="accordionContent">
      //                    <p>{forecast.temperatureC}</p>
      //                    <p>{forecast.temperatureF}</p>
      //                    <p>{forecast.summary}</p>
      //                </div>
      //            </td>
      //        </tr>
      //    )}
      //  </tbody>
      //</table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('weatherforecast');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
