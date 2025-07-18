export interface Entreprise {
  entrepriseId?: string; // GUID, facultatif pour la création
  nomEntreprise: string;
  adresse?: string;
  email: string;
  createdAt: Date;
  heureArriveePrevue?: string; // Format ISO string: "HH:mm:ss"
  heureDepartPrevue?: string;  // Format ISO string: "HH:mm:ss"
}
