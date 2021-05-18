import { createStore } from 'redux';
import reducer from "./containers/reducers";
const store = createStore(reducer);
export default store;