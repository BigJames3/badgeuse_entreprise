import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from './models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private apiUrl = 'https://localhost:7080/api/employees';  // URL de l'API

  constructor(private http: HttpClient) { }

  // Méthode pour récupérer les employés depuis l'API
  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }

  // Récupérer un employé par ID
  // Récupérer un employé par son ID
  getEmployeeById(employeeId: string): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/${employeeId}`);
  }

  // Mettre à jour un employé
  //updateEmployee(employeeId: Employee): Observable<void> {
  //  return this.http.put<void>(`${this.apiUrl}/${employeeId.EmployeeId}`, employeeId);
  //}

  updateEmployee(employee: Employee): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${employee.EmployeeId}`, employee);
  }

  deleteEmployee(employeeId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${employeeId}`);
  }
}
