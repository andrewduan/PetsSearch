import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrls } from '../constants/config';
import { PetsGroupType } from 'src/constants/petsGroupType';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PetService {

  constructor(private http:HttpClient) {}

  getPetGroups() : Observable<PetsGroupType[]> {
    return  this.http.get<PetsGroupType[]>(ApiUrls.GET_ALL_PETS);
  }
}