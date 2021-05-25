import React from 'react';
import { render } from 'react-dom';
import {Provider} from "react-redux";
import App from './containers/components/App/App.jsx';
import store from "./store";
import { BrowserRouter as Router } from 'react-router-dom';
import SiteService from "./containers/service";
import {ServiceProvider} from "./containers/components/service-context";
import "core-js/stable";
import "regenerator-runtime/runtime";
import {updateCurrentUser} from "./containers/actions/"

const siteService = new SiteService();
siteService.GetJWT().then(result=>store.dispatch(updateCurrentUser(result)));

render(<Provider store={store}>
            <ServiceProvider value={siteService}>
                    <Router>
                        <App />
                    </Router>
            </ServiceProvider>
        </Provider>,

    document.getElementById('content')
);