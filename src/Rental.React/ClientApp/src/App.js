import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Boardgames } from './components/Boardgames/Boardgames'
import { Clients } from './components/Clients/Clients'
import { Rentals } from './components/Rentals/Rentals'

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/boardgames' component={Boardgames} />
        <Route path='/clients' component={Clients} />
        <Route path='/rentals' component={Rentals} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}
