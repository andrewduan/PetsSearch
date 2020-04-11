import React, {Component} from 'react'
import PetsGroup from '../components/PetsGroup'
import { PetsModel } from '../actions/models';

export interface Props {
  petsGroups: PetsModel[];
}

class FilteredPetsGroup extends Component<Props> {  
  render(){
    const {petsGroups} = this.props; 
    return (<PetsGroup petsGroups={petsGroups} />)
  }
}

export default FilteredPetsGroup