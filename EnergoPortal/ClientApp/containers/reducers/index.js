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
        user: "identity/token",
        app: axios.create({
            withCredentials: false,
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
        }),
    },
    backend1cAPI: {
        url:"http://1csrv5.energo.local/energo-itilium/ws/IT_Mobile.1cws",
        app: axios.create({
            withCredentials: true,
            headers: {
                'Content-Type': 'Content-Type: application/soap+xml;charset=UTF-8;',
                'Authorization': 'Basic ZQBuAGUAcgBnAG8AXABtAGkAbABvAGsAdQBtAC4AcABhAHYAZQBsADoAQwBrAGIAZABqADMANQAwAF8AXwA='
            },
        }),
    },
    CurrentUser:{
        accessToken:"",
        userName:"",
        role:0,
        tokenUpdated:false,
        tokenNeedToBeUpdated:true,
    },
};
const reducer = (state = initialState, action) => {
    switch (action.type) {
        case "updateCurrentUser": {
            const {accessToken,userName,role} = action.payload;
            return {
                ...state,
                CurrentUser:{accessToken,userName, role, tokenUpdated:true, tokenNeedToBeUpdated:false },
            };
        }

        default:
            return {
                ...state,
            };
    }
};
export default reducer;
