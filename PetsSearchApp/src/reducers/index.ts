import { combineReducers } from 'redux'
import { petsReducer } from './pets'

export const rootReducer = combineReducers({
  pets: petsReducer
})

export type RootState = ReturnType<typeof rootReducer>