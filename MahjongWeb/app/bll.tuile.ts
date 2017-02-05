
////////////////////////////////////////////////////
export enum EFamille {
  caractere = 1,
  bambou,
  cercle,
  vent,
  dragon,
  fleur,
  saison
}

////////////////////////////////////////////////////
declare function unescape(s: string): string;


////////////////////////////////////////////////////
/// Tuile
export class Tuile {
  nom: string;
  private _code: string;
  rang: number;
  famille: EFamille;
  exposee: boolean;

  get code(): string {
    return unescape(this._code);
  }
}

////////////////////////////////////////////////////