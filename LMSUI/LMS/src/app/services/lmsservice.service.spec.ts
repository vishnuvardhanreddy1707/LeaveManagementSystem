import { TestBed } from '@angular/core/testing';

import { LMSServiceService } from './lmsservice.service';

describe('LMSServiceService', () => {
  let service: LMSServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LMSServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
