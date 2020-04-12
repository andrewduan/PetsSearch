import { ApiUrls } from '../constants'
export const PetsService = {
    getAllPetsGroups
};


async function getAllPetsGroups() {
    const requestOptions = {
        method: 'GET'
    };
    const res = await fetch(ApiUrls.GET_ALL_PETS, requestOptions);
    return await res.json();
}