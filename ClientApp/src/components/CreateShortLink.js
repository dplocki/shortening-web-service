import React, { Component } from 'react';

const VALID_URL_REGEX = /^(https?):\/\/.+$/;

export class CreateShortLink extends Component {
  constructor(props) {
    super(props);
    this.state = { value: '', id: '', generatedLinks: [] };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleValidation() {
    return this.state.value.match(VALID_URL_REGEX);
  }

  handleChange(event) { this.setState({ value: event.target.value.trim() }); }
  async handleSubmit(event) {
    event.preventDefault();

    if (this.handleValidation()) {
      const createResult = await fetch('linkmap/add', {
        method: 'POST',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify({
          id: this.state.id,
          url: this.state.value
        })
      });

      if (createResult.status !== 200) {
        alert('Sorry, connection error during create')
        return;
      }

      const result = await fetch('linkmap?' + new URLSearchParams({
        id: this.state.id
      }));

      if (result.status !== 200) {
        alert('Sorry, connection error');
        return;
      }

      const respond = await result.json();
      this.setState({
        ...this.state,
        value: '',
        generatedLinks: [
          ...this.state.generatedLinks,
          respond.shorted,
        ]
      })

      await this.populateId();
    } else {
      alert("Provided URL is invalid.");
    }
  }

  async populateId() {
    const content = await fetch('linkmap/newid');
    const guid = await content.text();
    this.setState({ ...this.state, id: guid });
  }

  componentDidMount() {
    this.populateId();
  }

  render() {
    const links = this.state.generatedLinks.map((shorted, i) => <li key={i}><a href={'go/' + shorted}>{shorted}</a></li>);

    return (
      <div>
        <form onSubmit={this.handleSubmit}>
          <input type="hidden" name="id" value={this.state.id}></input>
          <div className="form-group">
            <label>Past link to short:</label>
            <textarea className="form-control" rows="3" onChange={this.handleChange} value={this.state.value}></textarea>
          </div>

          <button type="submit" className="btn btn-primary">Submit</button>
        </form>

        <p>Generated links:</p>

        <ul>
          {links}
        </ul>
      </div>
    );
  }
}
