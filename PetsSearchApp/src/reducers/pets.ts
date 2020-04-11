import * as petsActions from '../actions/pets';
import { ActionType } from 'typesafe-actions';
import { PetsModel } from '../actions/models'
import { petsActionType } from '../constants';

export type PetsActions = ActionType<typeof petsActions>;

export type PetsState = Readonly<{
  petsGroups: PetsModel[]; 
  error:boolean; 
  isFetching: boolean;
}>;

const initialState: PetsState = {
  petsGroups: [],
  error: false,
  isFetching: false
};

export function petsReducer (state = initialState, action: PetsActions) :PetsState {  
  var newState;
  switch (action.type) {
    case petsActionType.GETALL_REQUEST:
     newState =  Object.assign({}, state, {isFetching: true});
     return newState;
    case petsActionType.GETALL_SUCCESS:
      var newStateAfterGetAllSuccess = Object.assign({}, state, { petsGroups: action.payload, isFetching: false, error:false});
      return newStateAfterGetAllSuccess;
    case petsActionType.GETALL_FAILURE:
      newState = Object.assign({}, state, { isFetching: false, error:true});
      return newState;
    default:
      return state
  }
}