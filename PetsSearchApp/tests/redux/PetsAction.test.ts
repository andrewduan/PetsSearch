import configureStore from 'redux-mock-store';
import * as PetsAction from '../../src/actions/pets';
import { PetsActionEnum } from '../../src/constants';

describe('add user redux', () => {
  const mockStore = configureStore();
  const reduxStore = mockStore();

  beforeEach(() => {
	reduxStore.clearActions();
  });

  describe('Search Pets action', () => {
	it('should dispatch the request action', () => {
		const expectedActions = [
			{
				type: PetsActionEnum.GETALL_REQUEST
			},
		];
		reduxStore.dispatch(PetsAction.getAllRequest());
		expect(reduxStore.getActions()).toEqual(expectedActions);
	});
  });
});