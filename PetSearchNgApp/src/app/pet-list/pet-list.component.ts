import { Component, OnInit } from '@angular/core';

import { PetsGroupType } from '../../constants/petsGroupType';
import { PetService } from '../../services/pet.service';
@Component({
  selector: 'app-pet-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.css']
})
export class PetListComponent implements OnInit{
  petsGroups: PetsGroupType[];
  ngOnInit(): void {
    this.petService.getPetGroups().subscribe((data: PetsGroupType[]) => this.petsGroups = data);
  }
  constructor( private petService: PetService ) { }
}