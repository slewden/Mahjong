
import { Tuile } from './bll.tuile';
import { Combinaison } from './bll.combinaison';
import { PointsBase } from './bll.pointsBase';

////////////////////////////////////////////////////
/// un groupe de tuiles
export class Groupe {
  tuiles: Array<Tuile>;
  combinaison: Combinaison;

  private _expose: boolean;
  get expose(): boolean {
    return this._expose;
  }
  set expose(expo: boolean) {
    this._expose = expo;
    for (let t of this.tuiles) {
      t.exposee = expo;
    }
  }

  get nombreTuilePriseEnCompte(): number {
    if (this.combinaison) {
      return Math.min(this.combinaison.nombreTuilesComptees, 3);
    }
    else {
      return this.tuiles.length;
    }
  }

  get complet(): boolean {
    return this.tuiles.length >= 3;
  }

  get totalPoint(): number {
    return this.combinaison ? this.combinaison.nombrePoint(this.expose) : 0;
  }

  get typeDeCombinaison(): PointsBase {
    return this.combinaison ? this.combinaison.TypeDeCombinaison : new PointsBase();
  }
}