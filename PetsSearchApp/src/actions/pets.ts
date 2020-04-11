import { action } from "typesafe-actions";
import { PetsModel } from "./models"
import { petsActionType } from '../constants';
import { Dispatch } from 'redux';
import { petsService } from '../services/pets';

export const getAllRequest = () =>  action(petsActionType.GETALL_REQUEST);
export const getAllSuccess = (petsGroups: PetsModel[]) =>  action(petsActionType.GETALL_SUCCESS, petsGroups);
export const getAllFailure = (error: string) =>  action(petsActionType.GETALL_FAILURE, {error});


export const getAllPetsGroups = () => {
    
    return (dispatch: Dispatch) => {
        dispatch(getAllRequest());
        petsService.getAllPetsGroups()
            .then(
                (pets: PetsModel[]) => dispatch(getAllSuccess(pets)),
                (error: string) => dispatch(getAllFailure(error))
            );
    };
}


export const petsActions = {
    getAllPetsGroups
};