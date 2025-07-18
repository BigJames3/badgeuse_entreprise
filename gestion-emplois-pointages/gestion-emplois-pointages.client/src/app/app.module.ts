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
import { EmployeeService } from './services/employee.service';
//import { AddEntrepriseComponent } from './add-entreprise/add-entreprise.component';
import { AddEntrepriseComponent } from './entreprise/add-entreprise/add-entreprise.component';
import { EditEntrepriseComponent } from './entreprise/edit-entreprise/edit-entreprise.component';
import { ListEntrepriseComponent } from './entreprise/list-entreprise/list-entreprise.component';
import { DeleteEntrepriseComponent } from './entreprise/delete-entreprise/delete-entreprise.component';
import { DeleteDepartementComponent } from './departement/delete-departement/delete-departement.component';
import { AddDepartementComponent } from './departement/add-departement/add-departement.component';
import { ListDepartementComponent } from './departement/list-departement/list-departement.component';
import { EditDepartementComponent } from './departement/edit-departement/edit-departement.component';
import { ListPositionComponent } from './position/list-position/list-position.component';
import { EditPositionComponent } from './position/edit-position/edit-position.component';
import { DeletePositionComponent } from './position/delete-position/delete-position.component';
import { AddPositionComponent } from './position/add-position/add-position.component';
import { AddScanpointsComponent } from './scanpoints/add-scanpoints/add-scanpoints.component';
import { ListScanpointsComponent } from './scanpoints/list-scanpoints/list-scanpoints.component';
import { EditScanpointsComponent } from './scanpoints/edit-scanpoints/edit-scanpoints.component';
import { DeleteScanpointsComponent } from './scanpoints/delete-scanpoints/delete-scanpoints.component';
import { AddUserComponent } from './user/add-user/add-user.component';
import { ListUserComponent } from './user/list-user/list-user.component';
import { EditUserComponent } from './user/edit-user/edit-user.component';
import { DeleteUserComponent } from './user/delete-user/delete-user.component';
//import { AddEntreprComponent } from './entreprise/add-entrepr/add-entrepr.component';  // Importer votre service
//import { AddEntrepriseComponent } from './entreprise/add-entreprise/add-entreprise.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    AddEmployeeComponent,
    AttendanceHistoryComponent,
    EmployeeUpdateComponent,
    EmployeeDeleteComponent,
    AddEntrepriseComponent,
    EditEntrepriseComponent,
    ListEntrepriseComponent,
    DeleteEntrepriseComponent,
    DeleteDepartementComponent,
    AddDepartementComponent,
    ListDepartementComponent,
    EditDepartementComponent,
    ListPositionComponent,
    EditPositionComponent,
    DeletePositionComponent,
    AddPositionComponent,
    AddScanpointsComponent,
    ListScanpointsComponent,
    EditScanpointsComponent,
    DeleteScanpointsComponent,
    AddUserComponent,
    ListUserComponent,
    EditUserComponent,
    DeleteUserComponent
    //AddEntreprComponent
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
