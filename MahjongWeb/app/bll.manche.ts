
import { MainJoueur } from './bll.mainJoueur';
import { TuileHelper } from './bll.tuileHelper';


export class Manche {
  ventTour: number;
  ventDominant: number;
  mains: Array<MainJoueur>;
  numeroTour: number;
  numeroManche: number;
  tuiles: TuileHelper;
  mahjongAvecTuileDuMur: boolean;
  mahjongAvecDernierTuileDuMur: boolean;
  mahjongEnVolantKongExpose: boolean;
};