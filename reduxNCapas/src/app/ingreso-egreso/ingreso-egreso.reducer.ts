import { AppState } from '../app.reducer';

import * as fromIngresoEgreso from './ingreso-egreso.actions';
import { Paciente } from '../models/paciente.model';


export interface PacientesState {
  items: Paciente[];
}

export interface   AppStateExtends extends AppState {
   pacientes: PacientesState;
}

const estadoInicial: PacientesState = {
  items: null,
};


export function ingresoEgresoReducer(state = estadoInicial, actions: fromIngresoEgreso.actions): PacientesState {


  switch (actions.type) {

    case fromIngresoEgreso.SET_ITEMS:
      return {
        items: [ ...actions.items.map( item =>  {
                     return { ...item };
            }) ]
      };

    case fromIngresoEgreso.UNSET_ITEMS:
      return {
        items: []
      };

    case fromIngresoEgreso.UPDATE_ITEMS:
    return {
      items: [ ]
    };

    case fromIngresoEgreso.GET_ITEMS:
      return {
        items: [ ]
      };
    default:
      return state;
  }
}
