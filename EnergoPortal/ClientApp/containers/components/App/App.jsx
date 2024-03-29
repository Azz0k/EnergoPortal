﻿import React from 'react';
import ErrorBoundary from "../error-boundary";
import NavBar from "../nav-bar/nav-bar.jsx";
import { Switch, Route } from 'react-router-dom';
import FloorsPlan from "../../pages/FloorsPlan.jsx";
import Itilium from '../../pages/Itilium.jsx';


const App = () => {
    return (
        <ErrorBoundary>
            <React.Fragment>
                <NavBar />
                <Switch>
                    <Route path='/' component={FloorsPlan} exact />
                    <Route path='/test' component={Itilium} exact />
                </Switch>
            </React.Fragment>
        </ErrorBoundary>
        );
};

export default App;