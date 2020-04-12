import React from 'react';
import { Router, Route } from 'react-router-dom';
import { connect } from 'react-redux';

import { history } from '../helpers/history';
import { HomePage } from '../views/HomePage';

class App extends React.Component {
    render() {
        return (
            <div className="jumbotron">
                <div className="container">
                    <div className="w-100">
                        <Router history={history}>
                            <div>
                                <Route exact path="/" component={HomePage} />
                            </div>
                        </Router>
                    </div>
                </div>
            </div>
        );
    }
}

const connectedApp = connect()(App);
export { connectedApp as App }; 