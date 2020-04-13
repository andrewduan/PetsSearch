import React from 'react';
import configureStore from 'redux-mock-store';
import PetsGroup, { Props } from '../../src/components/PetsGroup';
import { mount } from '../setup/test-setup';
import { PetsModel } from '../../src/actions/models';

describe('<PetsGroup />', () => {
  let wrapper: any;
  const petsGroups : Array<PetsModel> = [{gender: "Female", petNames:["Abby", "Tom"]}]
  const props: Props = {
    petsGroups: petsGroups
  };

  it('defines the component', () => {
    wrapper = mount(
        <PetsGroup {...props} />
    );
    expect(wrapper).toBeDefined();
  });

  it('renders PetsGroup component', () => {
    const divText = wrapper.find('div.gender').text();
    expect(divText).toBe("Female");
  });
});