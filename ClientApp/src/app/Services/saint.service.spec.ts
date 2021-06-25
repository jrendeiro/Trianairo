/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SaintService } from './saint.service';

describe('Service: Saint', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SaintService]
    });
  });

  it('should ...', inject([SaintService], (service: SaintService) => {
    expect(service).toBeTruthy();
  }));
});
