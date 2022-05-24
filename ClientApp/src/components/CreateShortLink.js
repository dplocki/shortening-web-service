import React, { Component } from 'react';
import { isConditionalTypeNode } from 'typescript';

const VALID_URL_REGEX = /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_+.~#?&//=]*)/;

export class CreateShortLink extends Component {
  constructor(props) {
    super(props);
    this.state = { value: '', id: '' };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleValidation() {
    return this.state.value.match(VALID_URL_REGEX);
  }

  handleChange(event) { this.setState({ value: event.target.value.trim() }); }
  handleSubmit(event) {
    if (this.handleValidation()) {
      alert("Form submitted");
      alert('Value: ' + this.state.value);
    } else {
      alert("Form has errors.");
      event.preventDefault();
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
    return (
      <form onSubmit={this.handleSubmit}>
        <input type="hidden" name="id" value={this.state.id}></input>
        <div className="form-group">
          <label>Past link to short:</label>
          <textarea className="form-control" rows="3" onChange={this.handleChange}></textarea>
        </div>

        <button type="submit" className="btn btn-primary">Submit</button>
      </form>
    );
  }
}
