import React, {Component} from 'react'
import { PetsModel } from '../actions/models';
import "../index.css"

export interface Props {
  petsGroups: PetsModel[];
}

class PetsGroup extends Component<Props> {
  render(){ 
    const groups = this.props.petsGroups.map((petsGroup, idx) => {
      const {gender, petNames} = petsGroup;
      const listItems = petNames.map((name, index) => {
        return (<li key={`${idx}${index}`}>{name}</li>);
      });
      return (
        <div key={`gender${idx}`}>
          <div>{gender}</div>
          <ul key={idx}>{listItems}</ul>
        </div>
      );
    }); 
    return(
      <div>
          {groups}
      </div>
    );
  }
}

export default PetsGroup