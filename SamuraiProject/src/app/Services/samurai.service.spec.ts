import { TestBed } from '@angular/core/testing';

import { SamuraiService } from './samurai.service';

describe('SamuraiService', () => {
  let service: SamuraiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SamuraiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
