import React from 'react';
import { render } from 'react-dom';
import {Provider} from "react-redux";
import App from './containers/components/App/App.jsx';
import store from "./store";
import { BrowserRouter as Router } from 'react-router-dom';

render(<Provider store={store}>
            <Router>
                <App />
            </Router>
        </Provider>,

    document.getElementById('content')
);