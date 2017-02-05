
////////////////////////////////////////////////////
/// classe de base pour compter les combinaisons
export class PointsBase {
  nombreCombinaison: number;
  nombrePaire: number;

  nombreTuileComptees: number;
  get mahjong(): boolean {
    return this.nombreCombinaison == 4 && this.nombrePaire == 1;
  }
}