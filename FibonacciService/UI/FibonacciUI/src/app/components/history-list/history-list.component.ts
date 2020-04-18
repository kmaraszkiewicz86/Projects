import { Component, OnInit } from '@angular/core';
import { FibResultService } from 'src/app/services/fib-result.service';
import { FibResult } from 'src/app/models/fib-result.model';

@Component({
  selector: 'app-history-list',
  templateUrl: './history-list.component.html',
  styleUrls: ['./history-list.component.css']
})
export class HistoryListComponent implements OnInit {

  public fibResults: FibResult[] = [];

  constructor(private service: FibResultService) { }

  ngOnInit(): void {
    this.getAll();
  }

  private getAll() {
    this.service.getAll().subscribe(res => {
      this.fibResults = res
    }, err => {

    })
  }

}
