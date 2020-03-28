export class Paciente {
   id: any;
   nombre : any;
   cedula : any;
   profesion : any;
   trabajo : any;

  constructor(obj: ObjInput) {
    this.id = obj && obj.id || 0;
    this.nombre = obj && obj.nombre || null;
    this.cedula = obj && obj.cedula || 0;
    this.profesion = obj && obj.profesion || null;
    this.trabajo = obj && obj.trabajo || null;
  }
}

interface ObjInput {
  id: any;
  nombre : any;
  cedula : any;
  profesion : any;
  trabajo : any;
}
