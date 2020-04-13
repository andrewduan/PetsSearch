import { petsReducer } from '../../src/reducers/pets';
import { PetsModel } from '../../src/actions/models';
import { PetsActionEnum } from '../../src/constants';
import { action } from 'typesafe-actions';


describe('Pets reducer', () => {
    const petsGroups : Array<PetsModel> = [{gender: "Female", petNames:["Abby", "Tom"]}]
    it('Pets  reducer expected state', () => {
        const requestSuccessfulAction = action(PetsActionEnum.GETALL_SUCCESS, petsGroups);

        const updatedState = petsReducer(undefined, requestSuccessfulAction);

        expect(updatedState.petsGroups).toHaveLength(1);
        expect(updatedState.petsGroups[0].gender).toBe("Female")
    });
});