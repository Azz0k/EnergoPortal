import horisontalMenu from "./menu.js";
import FloorsImages from "./floors.js";
const initialState = {
    MainMenu: {
        horisontalMenu,
        isLoaded: false,
    },
    FloorsImages,
    Devices:[],
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
