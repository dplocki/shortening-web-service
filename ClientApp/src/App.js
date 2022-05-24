import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { ShowAllLinks } from './components/FetchData';

import './custom.css'
import { CreateShortLink } from './components/CreateShortLink';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/short-link' component={CreateShortLink} />
        <Route path='/show-all-links' component={ShowAllLinks} />
      </Layout>
    );
  }
}
