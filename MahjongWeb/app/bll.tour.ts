
import { Joueur } from './bll.joueur';
import { Manche } from './bll.manche';

export class Tour {
  numeroTour: number;
  withHonnors: boolean;
  joueurs: Array<Joueur>;
  manches: Array<Manche>;

  constructor(numero: number, withHonnors: boolean, est: Joueur, sud: Joueur, ouest: Joueur, nord: Joueur) {
    this.numeroTour = numero;
    this.withHonnors = withHonnors;
    this.joueurs = [];
    this.joueurs.push(est);
    this.joueurs.push(sud);
    this.joueurs.push(ouest);
    this.joueurs.push(nord);

    this.manches = [];
  }
};