import { AngularFirestore } from '@angular/fire/firestore';
import { Injectable } from '@angular/core';
import { IngresoEgreso } from '../models/ingreso-egreso.model';
import { AuthService } from '../auth/auth.service';
import { AppState } from '../app.reducer';
import { Store } from '@ngrx/store';
import { filter, map } from 'rxjs/operators';
import { SetItemsAction, UnSetItemsAction } from './ingreso-egreso.actions';
import { SetUserAction } from '../auth/auth.actions';
import { Subscription } from 'rxjs';
import { URL_SERVICE } from '../Config/config';
import { HttpClient } from '@angular/common/http';
import { Paciente } from '../models/paciente.model';


@Injectable({
  providedIn: 'root'
})

// {...pacientes} operador spread

export class IngresoEgresoService {

  ingresoSuscriptionsInit: Subscription = new Subscription();
  ingresoSuscriptionsData: Subscription = new Subscription();

  constructor(public http: HttpClient, private afDB: AngularFirestore, private authServis: AuthService, private store: Store<AppState> ) { }

   initialIngresoEgreso() {
    this.ingresoSuscriptionsInit = this.store.select('auth')
                  .pipe( filter( auth => auth.user !== null ) )
                  .subscribe( auth => {  this.ingresoItems(); });
  }

  private ingresoItems() {
    this.ingresoSuscriptionsData = this.cargarPacientes().subscribe( (datos: any) =>

    { this.store.dispatch( new SetItemsAction(datos) ); });
  }

  cancelarSuscriptions() {
    this.ingresoSuscriptionsInit.unsubscribe();
    this.ingresoSuscriptionsData.unsubscribe();
    this.store.dispatch(new UnSetItemsAction());
  }


  cargarPacientes() {
    const url = URL_SERVICE + '/pacientes';
    return this.http.get(url).pipe(map( (resp: any) => {
      return resp;
    }));
  }

  cargarPaciente(idPaciente: any) {
    const url = URL_SERVICE + '/paciente?idPaciente=' + idPaciente;
    return this.http.get(url).pipe(map( (resp: any) => {
      console.log(resp);
      return resp;
    }));
  }

  crearPaciente( paciente: Paciente ) {
    const url = URL_SERVICE + '/ingresarPaciente';
    console.log('desde el servicio', paciente);
    return this.http.post(url, paciente).pipe(map( (resp: any) => {
      this.ingresoItems();
      return resp;
    }));
  }

   buscarPacientes( paciente: any ) {
    const url = URL_SERVICE + '/buscarPaciente';
    return this.http.post(url, paciente).pipe(map( (resp: any) => {
      return resp;
    })).subscribe(
      (datos: any) =>

      { this.store.dispatch( new SetItemsAction(datos) ); });

  }

  borrarPacientes( idPaciente: any ) {
    const url = URL_SERVICE + '/borrarPaciente?idPaciente=' + idPaciente;
    return this.http.delete(url).pipe(map( (resp: any) => {
      this.ingresoItems();
      return resp;
    }));
  }
}
