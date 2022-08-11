import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class TipocambioService {
  _url = 'http://localhost:32771/api/TipoCambio/ObtenerListaTipoCambio'
  //_urlToken = 'http://localhost:32771/token'
  constructor(
    private http:HttpClient
  ) { 
    console.log('Servicio Tipo Cambio');
  }

  getTiposCambio(){
    let header = new HttpHeaders()
      .set('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoicHJ1ZWJhIiwiRGF0ZUNyZWF0ZWQiOiIwOC8xMS8yMDIyIDAxOjU3OjA1IiwibmJmIjoxNjYwMTgzMDI1LCJleHAiOjE2NjAxODM5MjUsImlzcyI6IlNpbXBsZVNlcnZlciJ9.CHLu-37RwgvDWvBwwmjJd6Z8l-YD4ZSsQNP-kfP2bnw')

      return this.http.get(this._url, {
        headers: header
      });
  }
}
