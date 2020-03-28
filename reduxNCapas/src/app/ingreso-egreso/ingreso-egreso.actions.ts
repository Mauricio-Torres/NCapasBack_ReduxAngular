import { Action } from '@ngrx/store';
import { Paciente } from '../models/paciente.model';



export const SET_ITEMS = '[Paciente ] Set Items';
export const UNSET_ITEMS = '[Paciente Delete] UnSet Items';
export const UPDATE_ITEMS = '[Paciente Update] Update Items';
export const GET_ITEMS = '[Paciente Only uPDATE] Only Item';


export class SetItemsAction implements Action {
  readonly type = SET_ITEMS;
  constructor(public items: Paciente[]) {}
}
export class GetItemsAction implements Action {
  readonly type = GET_ITEMS;
  constructor(public item: Paciente) {}
}

export class UnSetItemsAction implements Action {
  readonly type = UNSET_ITEMS;
  constructor() {}
}

export class UpdateItemsAction implements Action {
  readonly type = UPDATE_ITEMS;
  constructor() {}
}

export type actions = SetItemsAction | UnSetItemsAction | GetItemsAction | UpdateItemsAction;
