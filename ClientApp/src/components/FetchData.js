import React, { Component } from 'react';

export class ShowAllLinks extends Component {
  static displayName = ShowAllLinks.name;

  constructor(props) {
    super(props);
    this.state = { linkMaps: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderLinksTable(linkMaps) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Shorted</th>
            <th>Full link</th>
          </tr>
        </thead>
        <tbody>
          {linkMaps.map(linkMap =>
            <tr key={linkMap.date}>
              <td>{linkMap.date}</td>
              <td>{linkMap.temperatureC}</td>
              <td>{linkMap.temperatureF}</td>
              <td>{linkMap.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : ShowAllLinks.renderLinksTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('linkmap');
    const data = await response.json();
      console.log(data);
    this.setState({ linkMaps: data, loading: false });
  }
}
