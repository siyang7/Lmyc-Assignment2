import { TestBed, inject } from '@angular/core/testing';

import { ReservationsService } from './reservation.service';

describe('ReservationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ReservationsService]
    });
  });

  it('should be created', inject([ReservationsService], (service: ReservationsService) => {
    expect(service).toBeTruthy();
  }));
});
