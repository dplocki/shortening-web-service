import React, { Component } from 'react';

export class ShowAllLinks extends Component {
  static displayName = ShowAllLinks.name;

  constructor(props) {
    super(props);
    this.state = { linkMaps: [], loading: true };
  }

  async componentDidMount() {
    await this.populateData();
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : (<table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Shorted</th>
              <th>Full link</th>
            </tr>
          </thead>
          <tbody>
            {this.state.linkMaps.map(linkMap =>
              <tr key={linkMap.date}>
                <td>{linkMap.shorted}</td>
                <td>{linkMap.originalLink}</td>
              </tr>
            )}
          </tbody>
        </table>);

    return (
      <div>
        <h1 id="tabelLabel">All shorted links:</h1>
        {contents}
      </div>
    );
  }

  async populateData() {
    const response = await fetch('linkmap/all');
    const data = await response.json();
    this.setState({ linkMaps: data, loading: false });
  }
}
