import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule} from 'ngx-bootstrap/modal';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AgendasService } from './models/agenda/agendas.service';
import { AgendasComponent } from './components/agendas/agendas.component';
import { FuncionariosService } from './models/funcionario/funcionarios.service';
import { FuncionariosComponent } from './components/funcionarios/funcionarios.component';

//Angular Material Imports
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  declarations: [
    AppComponent,
    AgendasComponent,
    FuncionariosComponent,
    // MarcasComponent,
    // ModelosComponent,
    // ClientesComponent,
    // CarrosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    BrowserAnimationsModule,


    //angular material imports
    MatDatepickerModule,
    MatInputModule,
    MatNativeDateModule,

  ],
  providers: [
    HttpClientModule,
    AgendasService,
    FuncionariosService
  //   MarcasService,
  //   ModelosService,
  //   ClientesService,
  //   CarrosService
   ],
  bootstrap: [AppComponent]
})
export class AppModule { }
