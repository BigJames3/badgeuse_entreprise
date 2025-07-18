//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-delete-entreprise',
//  templateUrl: './delete-entreprise.component.html',
//  styleUrl: './delete-entreprise.component.css'
//})
//export class DeleteEntrepriseComponent {

//}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EntrepriseService } from '../../services/entreprise.service';

@Component({
  selector: 'app-delete-entreprise',
  templateUrl: './delete-entreprise.component.html'
})
export class DeleteEntrepriseComponent implements OnInit {
  entrepriseId!: string;
  entreprise: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private entrepriseService: EntrepriseService
  ) { }

  ngOnInit(): void {
    // Récupère l'ID à partir de l’URL
    this.entrepriseId = this.route.snapshot.params['id'];

    // Récupère les données de l'entreprise pour affichage de confirmation
    this.entrepriseService.getEntrepriseById(this.entrepriseId).subscribe(data => {
      this.entreprise = data;
    });
  }

  // Suppression de l'entreprise
  onDelete(): void {
    this.entrepriseService.deleteEntreprise(this.entrepriseId).subscribe(() => {
      // Redirection vers la liste après suppression
      this.router.navigate(['/entreprises']);
    });
  }
}
