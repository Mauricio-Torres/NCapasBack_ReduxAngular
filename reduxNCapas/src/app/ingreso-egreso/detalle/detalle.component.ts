import { Component, OnInit, OnDestroy } from '@angular/core';
import { IngresoEgreso } from '../../models/ingreso-egreso.model';
import { AppState } from '../../app.reducer';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { IngresoEgresoService } from '../ingreso-egreso.service';
import Swal from 'sweetalert2';
import { AppStateExtends } from '../ingreso-egreso.reducer';
import { Paciente } from '../../models/paciente.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-detalle',
  templateUrl: './detalle.component.html',
  styles: []
})
export class DetalleComponent implements OnInit, OnDestroy {

  subscription: Subscription = new Subscription()
  items: Paciente[];
  formGroup: FormGroup;


  constructor(private build: FormBuilder,
    private store: Store<AppStateExtends>, private ingresoEgresoService: IngresoEgresoService ) { }

  ngOnInit() {
    // this.ingresoEgresoService.cargarPacientes().subscribe( (dat: any) =>{ console.log(dat)});

    this.subscription = this.store.select('pacientes')
              .subscribe( (pacientes: any) => {
                console.log('leyendo dat desde detalles ', pacientes)
                this.items = pacientes.items;
              });

    this.formGroup = this.build.group({
      buscar: [''],
      cedula: [0]
    });

  }

  borrarItem(item: any) {

    const id = item.id;
    this.ingresoEgresoService.borrarPacientes(id).subscribe( (data: any) => {

      Swal.fire({
        title: 'Registro Eliminado exitosamente!',
        text: 'El registro ' + item.nombre + ' con cedula ' + item.cedula  + ' fue eliminado exitosamente ',
        icon: 'success',
        confirmButtonText: 'Ok!'
      });

    },
    err => {

      Swal.fire({
        title: 'Error!',
        text: err.message,
        icon: 'error',
        confirmButtonText: 'Ok!'
      });
    }
    );
  }

  buscarItem(){

    var obj: Paciente = {
      id: 0,
      nombre: this.formGroup.controls['buscar'].value,
      profesion: this.formGroup.controls['buscar'].value,
      trabajo: this.formGroup.controls['buscar'].value,
      cedula: this.formGroup.controls['cedula'].value,
    };

    const paciente = new Paciente ({...obj});
    this.ingresoEgresoService.buscarPacientes(paciente);

  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

}
