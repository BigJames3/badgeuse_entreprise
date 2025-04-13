import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { AttendanceHistoryComponent } from './attendance-history/attendance-history.component';
import { FormsModule} from '@angular/forms';  // Importez FormsModule
import { ReactiveFormsModule } from '@angular/forms';
import { EmployeeUpdateComponent } from './employee-update/employee-update.component';
import { EmployeeDeleteComponent } from './employee-delete/employee-delete.component';  // Importez FormsModule
import { EmployeeService } from './services/employee.service';  // Importer votre service

@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    AddEmployeeComponent,
    AttendanceHistoryComponent,
    EmployeeUpdateComponent,
    EmployeeDeleteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,  // Ajoutez FormsModule ici
    ReactiveFormsModule,  // Nécessaire pour les formulaires réactifs
    HttpClientModule     // Nécessaire pour effectuer des requêtes HTTP
  ],
  providers: [EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
