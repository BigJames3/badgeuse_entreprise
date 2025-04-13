// add-employee.component.ts
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../services/employee.service';  // Importez le service
import { Employee } from '../models/employee';  // Importez l'interface Employee

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {
  employeeForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private employeeService: EmployeeService) {
    this.employeeForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      position: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      department: [''],  // Optionnel
      dateHired: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.employeeForm.invalid) {
      console.log('Formulaire invalide :', this.employeeForm.errors);
      return;
    }

    // Préparer les données à envoyer (formatage de la date)
    const employeeData: Employee = {
      ...this.employeeForm.value,
      dateHired: new Date(this.employeeForm.value.dateHired).toISOString(),  // Formatage de la date
    };

    console.log('Données envoyées à l\'API :', employeeData);

    // Appeler le service pour envoyer les données à l'API
    this.employeeService.addEmployee(employeeData).subscribe(
      (response) => {
        console.log('Employé ajouté avec succès:', response);
        // Réinitialiser le formulaire après la soumission réussie
        this.employeeForm.reset();
      },
      (error) => {
        console.error('Erreur lors de l\'ajout de l\'employé:', error);
      }
    );
  }
}
