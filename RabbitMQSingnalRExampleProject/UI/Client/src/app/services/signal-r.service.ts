import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { MessageModel } from '../models/message.model'

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  public data: MessageModel[] = [];

  private hubConnection: signalR.HubConnection;

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl('https://localhost:5001/messages')
                            .build();

    this.hubConnection
      .start()
      .then(() => console.log("Connection started"))
      .catch(err => console.log('Error while starting connection ' + err))
  }

  public addMessagesDataListener = () => {
    this.hubConnection.on('messages', (data) => {
      this.data.push(JSON.parse(data));
      console.log(this.data);
    })
  }
}
