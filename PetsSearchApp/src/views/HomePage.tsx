import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators, Dispatch } from 'redux'

import * as PetsAction from '../actions/pets';
import  PetsGroup  from '../components/PetsGroup'
import { PetsState } from '../actions/models';

const getAllPetsGroupsRelay = () => async (dispatch: Dispatch<any>) => {
    setTimeout(() => dispatch(PetsAction.getAllPetsGroups()), 1000);
};

const mapDispatchToProps = (dispatch: Dispatch) =>
  bindActionCreators(
    {
        getAllPetsGroups: getAllPetsGroupsRelay
    },
    dispatch
  );

type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps> ;

class HomePage extends React.Component<Props> {
    async componentDidMount() {
        this.props.getAllPetsGroups();        
    }

    render() {
        const { isFetching, error, petsGroups } = this.props;
        return (
            <div className="w-100">
                <p>Here are the cats</p>
                {isFetching && <em>Loading Pets...</em>}
                {error && <span className="text-danger">ERROR: error happened when retrieving pets</span>}
                <PetsGroup petsGroups = {petsGroups}></PetsGroup>
            </div>
        );
    }
}

function mapStateToProps(state: PetsState) {
    const { isFetching, error, petsGroups } = state.pets;
    return { isFetching, error, petsGroups };    
}

const connectedHomePage = connect(mapStateToProps, mapDispatchToProps)(HomePage);
export { connectedHomePage as HomePage };