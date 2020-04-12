import { action } from "typesafe-actions";
import { PetsModel } from "./models"
import { PetsActionEnum } from '../constants';
import { Dispatch } from 'redux';
import { PetsService } from '../services/pets';

export const getAllRequest = () =>  action(PetsActionEnum.GETALL_REQUEST);
export const getAllSuccess = (petsGroups: PetsModel[]) =>  action(PetsActionEnum.GETALL_SUCCESS, petsGroups);
export const getAllFailure = (error: string) =>  action(PetsActionEnum.GETALL_FAILURE, {error});


export const getAllPetsGroups = () => {
    
    return (dispatch: Dispatch) => {
        dispatch(getAllRequest());
        PetsService.getAllPetsGroups()
            .then(
                (pets: PetsModel[]) => dispatch(getAllSuccess(pets)),
                (error: string) => dispatch(getAllFailure(error))
            );
    };
}


export const PetsActions = {
    getAllPetsGroups
};