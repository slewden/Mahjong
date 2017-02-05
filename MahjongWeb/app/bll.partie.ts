
import { Joueur } from './bll.joueur';
import { Tour } from './bll.tour';

// Service partie
export class Partie {
  id: number;
  finie: boolean;
  date: Date;
  commentaire: string;
  withHonnors: boolean;
  joueurs: Array<Joueur>;
  tours: Array<Tour>;

  numeroManche: number;

  joueurSelectionne: Joueur;

  constructor() {
  }

};