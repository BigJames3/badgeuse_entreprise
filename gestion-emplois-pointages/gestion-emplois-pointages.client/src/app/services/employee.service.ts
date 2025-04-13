// services/employee.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';  // Importez l'interface Employee

@Injectable({
  providedIn: 'root', // Service globalement disponible dans l'application
})
export class EmployeeService {
  private apiUrl = 'https://localhost:7080/api/employees'; // URL de l'API

  constructor(private http: HttpClient) { }

  /**
   * Récupère un employé par son ID
   * @param employeeId ID de l'employé à récupérer
   * @returns Observable<Employee>
   */
  getEmployeeById(employeeId: string): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/${employeeId}`);
  }

  /**
   * Récupère la liste des employés
   */
  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }

  /**
   * Ajoute un nouvel employé
   * @param employee Données de l'employé à ajouter
   */
  addEmployee(employee: Employee): Observable<Employee> {
    console.log('Données envoyées : ', employee);
    return this.http.post<Employee>(this.apiUrl, employee);
  }

  /**
   * Met à jour un employé existant
   * @param employeeId ID de l'employé à mettre à jour
   * @param employee Nouvelles données de l'employé
   */
  updateEmployee(employeeId: string, employee: Employee): Observable<Employee> {
    return this.http.put<Employee>(`${this.apiUrl}/${employeeId}`, employee);
  }

  /**
   * Supprime un employé
   * @param employeeId ID de l'employé à supprimer
   */
  deleteEmployee(employeeId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${employeeId}`);
  }
}
