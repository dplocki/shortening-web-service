import React, { Component } from 'react';

const VALID_URL_REGEX = /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_+.~#?&//=]*)/;

export class CreateShortLink extends Component {
  constructor(props) {
    super(props);
    this.state = { value: '' };
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

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <div class="form-group">
          <label for="exampleFormControlTextarea1">Past link to short:</label>
          <textarea class="form-control" rows="3" onChange={this.handleChange}></textarea>
        </div>

        <button type="submit" class="btn btn-primary">Submit</button>
      </form>
    );
  }
}
