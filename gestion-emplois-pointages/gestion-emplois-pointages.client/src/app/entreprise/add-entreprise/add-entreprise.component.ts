//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-add-entreprise',
//  templateUrl: './add-entreprise.component.html',
//  styleUrl: './add-entreprise.component.css'
//})
//export class AddEntrepriseComponent {

//}

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { EntrepriseService } from '../../services/entreprise.service';

@Component({
  selector: 'app-add-entreprise',
  templateUrl: './add-entreprise.component.html'
})
export class AddEntrepriseComponent {
  // Objet entreprise initialisé avec des champs vides
  entreprise: any = {
    nomEntreprise: '',
    adresse: '',
    email: '',
    createdAt: new Date(),  // Date actuelle par défaut
    heureArriveePrevue: '',
    heureDepartPrevue: ''
  };

  constructor(
    private entrepriseService: EntrepriseService,
    private router: Router
  ) { }

  // Fonction appelée lors de la soumission du formulaire
  onSubmit(): void {
    this.entrepriseService.addEntreprise(this.entreprise).subscribe(() => {
      // Redirige vers la liste après l'ajout
      this.router.navigate(['/entreprises']);
    });
  }
}
