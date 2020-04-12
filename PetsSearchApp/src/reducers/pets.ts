import * as PetsActions from '../actions/pets';
import { ActionType } from 'typesafe-actions';
import { PetsModel } from '../actions/models'
import { PetsActionEnum } from '../constants';

export type PetsActionType = ActionType<typeof PetsActions>;

const initialState = {
  petsGroups: Array<PetsModel>(),
  error: false,
  isFetching: false
};

export type PetsState = Readonly<typeof initialState>;

export function petsReducer (state = initialState, action: PetsActionType) :PetsState {  
  switch (action.type) {
    case PetsActionEnum.GETALL_REQUEST:
     return {...state, isFetching: true};
    case PetsActionEnum.GETALL_SUCCESS:
      return {...state, petsGroups: action.payload, isFetching: false, error:false}
    case PetsActionEnum.GETALL_FAILURE:
      return {...state, isFetching: false, error:true };
    default:
      return state
  }
}