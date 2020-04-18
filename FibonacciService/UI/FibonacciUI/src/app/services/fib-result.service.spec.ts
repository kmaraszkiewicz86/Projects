import { TestBed } from '@angular/core/testing';

import { FibResultService } from './fib-result.service';

describe('FibResultService', () => {
  let service: FibResultService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FibResultService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
