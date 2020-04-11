import { apiUrls, petsActionType } from '../constants'
import { PetsModel } from "../actions/models"
export const petsService = {
    getAllPetsGroups
};


function getAllPetsGroups() {
    const requestOptions = {
        method: 'GET'
    };
    return fetch(apiUrls.GET_ALL_PETS, requestOptions)
    .then(handleResponse)
    .then((pets: PetsModel[]) => pets);    
}

function handleResponse(response: any) : PetsModel[] {
    return response.text().then((text: any) => {
        const data = text && JSON.parse(text);
        if (!response.ok) {
            const error = (data && data.message) || response.statusText;
            return Promise.reject(error);
        }

        return data;
    });
}