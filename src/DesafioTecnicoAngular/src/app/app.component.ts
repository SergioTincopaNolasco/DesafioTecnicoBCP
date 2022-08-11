import { Component } from '@angular/core';
import { TipocambioService } from './services/tipocambio.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'DesafioTecnicoBCP';
  public tiposcambio: Array<any> = []

  constructor(
    private tipocambioService:TipocambioService
  ) {
    this.tipocambioService.getTiposCambio().subscribe((resp: any) => {
      console.log(resp);
      this.tiposcambio = resp
    })
  }
}
