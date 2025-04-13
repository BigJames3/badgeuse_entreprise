import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { EmployeeUpdateComponent } from './employee-update/employee-update.component';  // Importation de EmployeeUpdateComponent

const routes: Routes = [
  { path: 'employee-list', component: EmployeeListComponent },
  { path: 'add-employee', component: AddEmployeeComponent },
  { path: 'employee-update/:id', component: EmployeeUpdateComponent },  // Nouvelle route pour la mise à jour
  { path: '', redirectTo: '/employee-list', pathMatch: 'full' }
];

//const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
