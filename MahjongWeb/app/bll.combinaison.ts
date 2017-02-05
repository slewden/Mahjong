
export enum ETypeCombinaison {
  /// <summary>
  /// show, pung, kong
  /// </summary>
  Combinaison = 1,

  /// <summary>
  /// la paire finale
  /// </summary>
  Paire,

  /// <summary>
  /// un ou plusieurs honneur
  /// </summary>
  Honneur
}

import { EFamille } from './bll.tuile';
import { PointsBase } from './bll.pointsBase';

////////////////////////////////////////////////////
/// une combinaison valide et son poid
export class Combinaison {
  typeCombinaison: ETypeCombinaison;
  nom: string;
  nombrePointsSiVisible: number;
  nombrePointsSiMasque: number;
  nombreTuiles: number;
  nombreTuilesComptees: number;
  famille: EFamille;

  get TypeDeCombinaison(): PointsBase {
    let pb = new PointsBase();
    pb.nombreCombinaison = this.nombreTuiles >= 3 ? 1 : 0;
    pb.nombrePaire = this.nombreTuiles == 2 ? 1 : 0;
    return pb;
  };

  nombrePoint(expose: boolean): number {
    return expose ? this.nombrePointsSiVisible : this.nombrePointsSiMasque;
  }
}