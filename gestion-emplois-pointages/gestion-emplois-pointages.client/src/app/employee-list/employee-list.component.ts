import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../models/employee';
import $ from 'jquery'; 
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  employees: any[] = [];  // Déclaration de la variable pour stocker les employés

  constructor(
    private employeeService: EmployeeService,
    private router: Router  // Injection du service Router
  ) { }

  ngOnInit(): void {
    this.getEmployees();  // Récupérer les employés dès que le composant est initialisé
  }

  // Méthode pour récupérer les employés
  getEmployees(): void {
    this.employeeService.getEmployees().subscribe(
      (data) => {
        this.employees = data;
      },
      (error) => {
        console.error('Erreur lors de la récupération des employés:', error);
      }
    );
  }

  // Méthode pour gérer la mise à jour d'un employé
  updateEmployee(employee: Employee): void {
    // Rediriger vers le formulaire de mise à jour avec l'ID de l'employé
    this.router.navigate(['/employee-update', employee.EmployeeId]);
  }

  deleteEmployee(employeeId: string): void {
    if (confirm('Êtes-vous sûr de vouloir supprimer cet employé ?')) {
      this.employeeService.deleteEmployee(employeeId).subscribe({
        next: () => {
          // Actualiser la liste après suppression
          this.getEmployees(); // méthode qui recharge la liste
        },
        error: (err) => {
          console.error('Erreur lors de la suppression de l\'employé', err);
        }
      });
    }
  }

}
