import { Component, OnInit } from '@angular/core';
import { SignalRService } from './services/signal-r.service'
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  constructor(public signalRService: SignalRService,
    private http: HttpClient) { }

  ngOnInit() {
    console.log('AppComponent ngOnInit')
    this.signalRService.startConnection();
    this.signalRService.addMessagesDataListener();
    this.startHttpRequest();
  }

  private startHttpRequest = () => {

    console.log('startHttpRequest')

    this.http.get('https://localhost:5001/api/Messages')
        .subscribe(res => {
          console.log(res);
        })
  }

}
