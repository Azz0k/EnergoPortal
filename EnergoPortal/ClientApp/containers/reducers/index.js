const initialState = {
    horizontalMenu: {
        NavBar: {},
        isLoaded: false,
    },
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
