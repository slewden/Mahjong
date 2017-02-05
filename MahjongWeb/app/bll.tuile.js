"use strict";
////////////////////////////////////////////////////
(function (EFamille) {
    EFamille[EFamille["caractere"] = 1] = "caractere";
    EFamille[EFamille["bambou"] = 2] = "bambou";
    EFamille[EFamille["cercle"] = 3] = "cercle";
    EFamille[EFamille["vent"] = 4] = "vent";
    EFamille[EFamille["dragon"] = 5] = "dragon";
    EFamille[EFamille["fleur"] = 6] = "fleur";
    EFamille[EFamille["saison"] = 7] = "saison";
})(exports.EFamille || (exports.EFamille = {}));
var EFamille = exports.EFamille;
////////////////////////////////////////////////////
/// Tuile
var Tuile = (function () {
    function Tuile() {
    }
    Object.defineProperty(Tuile.prototype, "code", {
        get: function () {
            return unescape(this._code);
        },
        enumerable: true,
        configurable: true
    });
    return Tuile;
}());
exports.Tuile = Tuile;
//////////////////////////////////////////////////// 
//# sourceMappingURL=bll.tuile.js.map