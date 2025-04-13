import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../models/employee';

@Component({
  selector: 'app-employee-update',
  templateUrl: './employee-update.component.html',
  styleUrls: ['./employee-update.component.css']
})

export class EmployeeUpdateComponent implements OnInit {
  employee: Employee = {
      EmployeeId: '', FirstName: '', LastName: '', Position: '', Department: '',
      //EmployeeId: '', FirstName: '', LastName: '', Position: '', PositionId: '', Department: '', DepartmentId: '',
      DateHired: '',
      Email: '',
      CreatedAt: '',
      PositionId: '',
      DepartmentId: ''
  };  // Modèle vide

  constructor(
    private route: ActivatedRoute,  // Pour récupérer l'ID de l'employé
    private employeeService: EmployeeService,  // Pour récupérer et mettre à jour l'employé
    private router: Router  // Pour rediriger après la mise à jour
  ) { }

  ngOnInit(): void {
    const employeeId = this.route.snapshot.paramMap.get('id')!;
    if (employeeId) {
      this.employeeService.getEmployeeById(employeeId).subscribe(
        (data: Employee) => {
          this.employee = data;
        },
        (error: any) => {
          console.error('Erreur lors du chargement de l\'employé:', error);
        }
      );
    }
  }

  updateEmployee(): void {
    if (this.employee.EmployeeId) {  // Vérifier si l'ID est présent
      this.employeeService.updateEmployee(this.employee.EmployeeId, this.employee).subscribe(
        (updatedEmployee: Employee) => {
          console.log('Mise à jour réussie:', updatedEmployee);
          this.router.navigate(['/employee-list']);
        },
        (error: any) => {
          console.error('Erreur lors de la mise à jour de l\'employé:', error);
        }
      );
    } else {
      console.error('L\'employé n\'a pas d\'ID valide');
    }
  }

}
