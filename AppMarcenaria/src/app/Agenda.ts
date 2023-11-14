export class Agenda {
  id: number = 0;
  descricao?: string;
  dataString: string = '';
  tipo?: string;
  funcionarioId: number = 0;



  // setDataFromString(dataString: string): void {
  //   const dateArray = dataString.split('-').map(Number);
  //   this.data = new Date(dateArray[0], dateArray[1] - 1, dateArray[2]);
  // }

  // toJSON(): any {
  //   // Converte a data para o formato desejado.
  //   const formattedDate = this.data.toISOString().split('T')[0];

  //   return {
  //     id: this.id,
  //     descricao: this.descricao,
  //     data: formattedDate,
  //     tipo: this.tipo,
  //     funcionarioId: this.funcionarioId,
  //   };
  // }



}
