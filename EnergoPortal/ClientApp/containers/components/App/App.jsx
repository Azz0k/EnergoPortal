import React from 'react';

import NavBar from "../NavBar/NavBar.jsx";
import { Switch, Route } from 'react-router-dom';
import FloorsPlan from "../../pages/FloorsPlan.jsx";


const App = () => {
    return (
        <React.Fragment>
            <NavBar />
            <Switch>
                <Route path='/' component={FloorsPlan} exact />
            </Switch>
        </React.Fragment>
        );
};

export default App;