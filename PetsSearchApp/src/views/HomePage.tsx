import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators, Dispatch, AnyAction } from 'redux'

import * as petsActions from '../actions/pets';
import  FilteredPetsGroup  from '../containers/FilteredPetsGroup'
import { PetsState, PetsModel } from '../actions/models';

const getAllPetsGroupsRelay = () => async (dispatch: Dispatch<any>) => {
    setTimeout(() => dispatch(petsActions.getAllPetsGroups()), 1000);
};

const mapDispatchToProps = (dispatch: Dispatch) =>
  bindActionCreators(
    {
        getAllPetsGroups: getAllPetsGroupsRelay
    },
    dispatch
  );

type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps> ;
const States = {value: ""};

class HomePage extends React.Component<Props, typeof States> {

    constructor(props: Props){
        super(props)
    }

    async componentDidMount() {
        this.props.getAllPetsGroups();        
    }

    render() {
        const { isFetching, error, petsGroups } = this.props;
        return (
            <div className="w-100">
                <p>Here are the pets result</p>
                {isFetching && <em>Loading Pets...</em>}
                {error && <span className="text-danger">ERROR: error happened when retrieving pets</span>}
                <FilteredPetsGroup petsGroups = {petsGroups}></FilteredPetsGroup>
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