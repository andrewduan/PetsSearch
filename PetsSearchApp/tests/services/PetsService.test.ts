import { PetsService } from '../../src/services/pets'
import fetchMock from 'fetch-mock';
 
describe('Testing pet service', () => {
  beforeEach(() => {
    fetchMock.get('https://localhost:5001/pets', { data: '12345' });
  })

  afterEach(() => {
      fetchMock.reset();
  })
 
  it('Calls getting json data', () => {
    //assert on the response
    PetsService.getAllPetsGroups().then(res => {
      expect(res.data).toEqual('12345')
    })
  })
})