
  export type PetsModel = {
    gender: string,
    petNames: string[]
  };

  export type PetsState = {
    pets: PetsViewModel
  }

  export type PetsViewModel = {
    isFetching: boolean;
    error: String;
    petsGroups: PetsModel[];
  };