import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Store } from '@ngrx/store';
import { AppState } from '../../app.reducer';
import { Subscription } from 'rxjs';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: []
})
export class RegisterComponent implements OnInit {

  cargando: boolean;
  suscription: Subscription = new Subscription();


  constructor(private authService: AuthService, private store: Store<AppState>) { }

  ngOnInit() {

    this.store.select('ui').subscribe( ui => { this.cargando = ui.isLoading; })
  }

  onSubmit(formulario: any) {

    this.authService.crearUsuario(formulario.name, formulario.email, formulario.password);

  }

  ngOnDestroy(): void {
    this.suscription.unsubscribe();
  }

}
