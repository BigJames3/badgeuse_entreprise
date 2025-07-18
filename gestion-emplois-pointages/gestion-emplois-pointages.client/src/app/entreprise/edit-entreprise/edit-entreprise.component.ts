//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-edit-entreprise',
//  templateUrl: './edit-entreprise.component.html',
//  styleUrl: './edit-entreprise.component.css'
//})
//export class EditEntrepriseComponent {

//}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntrepriseService } from '../../services/entreprise.service';

@Component({
  selector: 'app-edit-entreprise',
  templateUrl: './edit-entreprise.component.html'
})
export class EditEntrepriseComponent implements OnInit {
  entrepriseId!: string;     // Stocke l'ID à modifier
  entreprise: any = {};      // Stocke les données du formulaire

  constructor(
    private route: ActivatedRoute,         // Pour accéder à l’ID dans l’URL
    private router: Router,                // Pour rediriger après mise à jour
    private entrepriseService: EntrepriseService
  ) { }

  ngOnInit(): void {
    // Récupère l’ID dans les paramètres de l’URL
    this.entrepriseId = this.route.snapshot.params['id'];

    // Charge les données de l'entreprise existante
    this.entrepriseService.getEntrepriseById(this.entrepriseId).subscribe(data => {
      this.entreprise = data;
    });
  }

  // Mise à jour de l'entreprise
  onUpdate(): void {
    this.entrepriseService.updateEntreprise(this.entrepriseId, this.entreprise).subscribe(() => {
      this.router.navigate(['/entreprises']); // Redirection après édition
    });
  }
}
