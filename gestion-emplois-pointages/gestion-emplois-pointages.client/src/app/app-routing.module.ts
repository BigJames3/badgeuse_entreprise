import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { EmployeeUpdateComponent } from './employee-update/employee-update.component';  // Importation de EmployeeUpdateComponent

import { AddEntrepriseComponent } from './entreprise/add-entreprise/add-entreprise.component';
import { EditEntrepriseComponent } from './entreprise/edit-entreprise/edit-entreprise.component';
import { ListEntrepriseComponent } from './entreprise/list-entreprise/list-entreprise.component';
import { DeleteEntrepriseComponent } from './entreprise/delete-entreprise/delete-entreprise.component';

const routes: Routes = [
  { path: 'employee-list', component: EmployeeListComponent },
  { path: 'add-employee', component: AddEmployeeComponent },
  { path: 'employee-update/:id', component: EmployeeUpdateComponent },  // Nouvelle route pour la mise à jour
  { path: '', redirectTo: '/employee-list', pathMatch: 'full' },

  // Nouvelle route pour la mise à jour
  { path: 'entreprises', component: ListEntrepriseComponent },
  { path: 'entreprises/add', component: AddEntrepriseComponent },
  { path: 'entreprises/edit/:id', component: EditEntrepriseComponent },
  { path: 'entreprises/delete/:id', component: DeleteEntrepriseComponent },
];

//const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

