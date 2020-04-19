import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { PetListComponent } from './pet-list.component';
import { petsGroups } from '../../constants/petsGroups';
import { PetService } from 'src/services/pet.service';
import { of } from 'rxjs';

let comp : PetListComponent, petService: PetService;
let fixture, element;

class MockPetService {
  getPetGroups = null
}

describe('PetListComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [
        PetListComponent
      ],
      providers: [ PetListComponent, { provide: PetService, useClass: MockPetService } ],
    });
    petService = TestBed.inject(PetService);
    fixture = TestBed.createComponent(PetListComponent);
    comp = fixture.componentInstance;
    element = fixture.nativeElement;
  }));

  it('should not have petsgroups after construction', () => {
    expect(comp.petsGroups).toBeUndefined();
  })

  it('should create the petList', async() => {
    const fixture = TestBed.createComponent(PetListComponent);    
    const petList = fixture.componentInstance;
    expect(petList).toBeTruthy();
  });
  
  it("should call getUsers and return list of users", async(() => {
    spyOn(petService, 'getPetGroups').and.returnValue(of(petsGroups))  
    petService.getPetGroups();  
    fixture.detectChanges();  
    expect(comp.petsGroups).toEqual(petsGroups);
  }));

  it('should render pets list for given data', () => {
    spyOn(petService, 'getPetGroups').and.returnValue(of(petsGroups))
    fixture.detectChanges();
    let genderEl = element.querySelector('.gender');
    expect(genderEl.innerText).toContain('Male');
  });
});
