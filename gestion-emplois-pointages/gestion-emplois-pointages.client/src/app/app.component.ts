import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from './services/employee.service';
import { Employee } from './models/employee';  // Importer l'interface Employee

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  // Pour les prévisions météo
  public forecasts: WeatherForecast[] = [];

  // Pour l'ajout d'employé
  employeeForm: FormGroup;

  constructor(
    private http: HttpClient,
    private formBuilder: FormBuilder,
    private employeeService: EmployeeService
  ) {
    // Initialisation du formulaire pour l'employé
    this.employeeForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      position: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      department: [''], // Optionnel
      dateHired: ['', Validators.required],
    });
  }

  ngOnInit() {
    this.getForecasts();  // Récupérer les prévisions météo au démarrage
  }

  // Récupérer les prévisions météo depuis l'API
  getForecasts() {
    this.http.get<WeatherForecast[]>('https://api.example.com/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;  // Assigner les données récupérées à la variable forecasts
      },
      (error) => {
        console.error(error);
      }
    );
  }

  // Méthode pour soumettre le formulaire d'ajout d'employé
  onSubmit(): void {
    if (this.employeeForm.invalid) {
      console.log('Formulaire invalide :', this.employeeForm.errors);
      return;
    }

    const employeeData: Employee = {
      ...this.employeeForm.value,
      dateHired: new Date(this.employeeForm.value.dateHired).toISOString(),
    };

    console.log('Données envoyées à l\'API :', employeeData);

    // Appel au service pour envoyer les données à l'API
    this.employeeService.addEmployee(employeeData).subscribe(
      (response) => {
        console.log('Employé ajouté avec succès:', response);
      },
      (error) => {
        console.error('Erreur lors de l\'ajout de l\'employé:', error);
      }
    );
  }
}



//*******************
//import { HttpClient } from '@angular/common/http';
//import { Component, OnInit } from '@angular/core';

//interface WeatherForecast {
//  date: string;
//  temperatureC: number;
//  temperatureF: number;
//  summary: string;
//}

//@Component({
//  selector: 'app-root',
//  templateUrl: './app.component.html',
//  styleUrl: './app.component.css'
//})
//export class AppComponent implements OnInit {
//  public forecasts: WeatherForecast[] = [];

//  constructor(private http: HttpClient) { }

//  ngOnInit() {
//    this.getForecasts();
//  }

//  getForecasts() {
//    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
//      (result) => {
//        this.forecasts = result;
//      },
//      (error) => {
//        console.error(error);
//      }
//    );
//  }

//  title = 'gestion-emplois-pointages.client';
//}
