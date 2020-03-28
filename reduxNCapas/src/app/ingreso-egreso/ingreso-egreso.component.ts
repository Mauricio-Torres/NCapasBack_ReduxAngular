import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { IngresoEgreso } from '../models/ingreso-egreso.model';
import { IngresoEgresoService } from './ingreso-egreso.service';
import Swal from 'sweetalert2';
import { AppState } from '../app.reducer';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { ActivarLoadingAction, DesactivarLoadingAction } from '../shared/ui.actions';
import { Paciente } from '../models/paciente.model';

@Component({
  selector: 'app-ingreso-egreso',
  templateUrl: './ingreso-egreso.component.html',
  styles: []
})
export class IngresoEgresoComponent implements OnInit, OnDestroy {


  formGroup: FormGroup;
  cargando = true;
  loadingSuscription: Subscription = new Subscription();


  constructor(private formBuilder: FormBuilder,
              private ingresoEgresoService: IngresoEgresoService,
              private store: Store<AppState>) { }

  ngOnInit() {

    this.loadingSuscription = this.store.select('ui').subscribe( ui => this.cargando = ui.isLoading );

    this.formGroup = this.formBuilder.group({
      cedula: [0, Validators.min(1)],
      nombre: ['', Validators.required],
      profesion: ['', Validators.required],
      trabajo: ['', Validators.required],
    });
  }


  crearRegistro() {

    if (this.formGroup.valid) {

      this.store.dispatch( new ActivarLoadingAction() );

      const paciente = new Paciente ({...this.formGroup.value});
      this.ingresoEgresoService.crearPaciente(paciente)
      .subscribe( () => {

        this.formGroup.reset({ monto: 0 });
        this.store.dispatch( new DesactivarLoadingAction());

        Swal.fire({
          title: 'Registro exitoso!',
          text: 'El registro fue exitoso',
          icon: 'success',
          confirmButtonText: 'Ok!'
        });

      },
      (err: any) =>{
        Swal.fire({
          title: 'Error!',
          text: err.message,
          icon: 'error',
          confirmButtonText: 'Ok!'
        });
      }
      );

    }
  }

  ngOnDestroy(): void {
    this.loadingSuscription.unsubscribe();
  }
}
