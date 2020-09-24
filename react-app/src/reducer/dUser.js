import { ACTION_TYPES } from "../actions/dUser";
const initialState = {
    list: []
}


export const dUser = (state=initialState, action) => {
        switch (action.type) {
            case ACTION_TYPES.FETCH_ALL:
                return {
                    ...state, 
                    list:[...action.payload]
                }
                
            default:
                return state;
        }
}   