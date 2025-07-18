import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Entreprise } from '../models/entreprise';

@Injectable({
  providedIn: 'root'
})
export class EntrepriseService {
  [x: string]: any;
  getEntrepriseById(entrepriseId: string) {
      throw new Error('Method not implemented.');
  }
  deleteEntreprise(entrepriseId: string) {
      throw new Error('Method not implemented.');
  }

  private apiUrl = 'https://localhost:port/api/Entreprises'; // remplace "port" par le vrai

  constructor(private http: HttpClient) { }

  getAll(): Observable<Entreprise[]> {
    return this.http.get<Entreprise[]>(this.apiUrl);
  }

  getById(id: string): Observable<Entreprise> {
    return this.http.get<Entreprise>(`${this.apiUrl}/${id}`);
  }

  create(entreprise: Entreprise): Observable<Entreprise> {
    return this.http.post<Entreprise>(this.apiUrl, entreprise);
  }

  update(id: string, entreprise: Entreprise): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, entreprise);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
