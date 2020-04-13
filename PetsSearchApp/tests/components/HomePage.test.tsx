import React, { Dispatch } from 'react';
import configureStore from 'redux-mock-store';
import { HomePage } from '../../src/views/HomePage';
import { mount, shallow } from '../setup/test-setup';
import { PetsModel } from '../../src/actions/models';
import * as PetsAction from '../../src/actions/pets';
import { Provider } from 'react-redux';
import { PetsActionEnum } from '../../src/constants';
import { action } from 'typesafe-actions';
const mockStore = configureStore();

describe('<HomePage />', () => {
  
  const petsGroups : Array<PetsModel> = [{gender: "Female", petNames:["Abby", "Tom"]}]
  
  const initialState = 
  {
    pets:
    {
      isFetching: false,
      error: "",
      petsGroups: petsGroups
    }      
  };

  let wrapper: any;
  let store  = mockStore(initialState);

  const mockServiceCreator = (body: any, succeeds = true) => () =>
    new Promise((resolve, reject) => {
      setTimeout(() => (succeeds ? resolve(body) : reject(body)), 10);
    });


  beforeEach(() => {
		wrapper = mount(
			<Provider store={store}>
				<HomePage />
			</Provider>
		);
	});
  
  it('should show previously rolled value', () => {
    expect(wrapper).toBeDefined();
  });

  it('renders PetsGroup component inside homepage', () => {
    const divText = wrapper.find('div.gender').text();
    expect(divText).toBe("Female");
  });

  it('Request pets action', () => {
    store.dispatch(action(PetsActionEnum.GETALL_REQUEST));
    expect(store.getActions()).toContainEqual({ type: PetsActionEnum.GETALL_REQUEST });
  });
});