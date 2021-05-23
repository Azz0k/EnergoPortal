import horisontalMenu from "./menu.js";
import FloorsImages from "./floors.js";
import axios from 'axios';
const initialState = {
    MainMenu: {
        horisontalMenu,
        isLoaded: false,
    },
    FloorsImages,
    Devices:[],
    backendAPI:{
        url:"http://localhost:41409/api/",
        devices:"device",
        app: axios.create({
            withCredentials: false,
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
        }),
    }
};
const reducer = (state = initialState, action) => {
    switch (action.type) {
        default:
            return {
                ...state,
            };
    }
};
export default reducer;
