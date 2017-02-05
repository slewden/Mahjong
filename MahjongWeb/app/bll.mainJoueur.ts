
import { Joueur } from './bll.joueur';
import { Groupe } from './bll.groupe';

export class MainJoueur {
  joueur: Joueur;
  numeroTour: number;
  numeroManche: number;
  groupes: Array<Groupe>
}