"use strict";
var bll_pointsBase_1 = require('./bll.pointsBase');
////////////////////////////////////////////////////
/// un groupe de tuiles
var Groupe = (function () {
    function Groupe() {
    }
    Object.defineProperty(Groupe.prototype, "expose", {
        get: function () {
            return this._expose;
        },
        set: function (expo) {
            this._expose = expo;
            for (var _i = 0, _a = this.tuiles; _i < _a.length; _i++) {
                var t = _a[_i];
                t.exposee = expo;
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Groupe.prototype, "nombreTuilePriseEnCompte", {
        get: function () {
            if (this.combinaison) {
                return Math.min(this.combinaison.nombreTuilesComptees, 3);
            }
            else {
                return this.tuiles.length;
            }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Groupe.prototype, "complet", {
        get: function () {
            return this.tuiles.length >= 3;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Groupe.prototype, "totalPoint", {
        get: function () {
            return this.combinaison ? this.combinaison.nombrePoint(this.expose) : 0;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Groupe.prototype, "typeDeCombinaison", {
        get: function () {
            return this.combinaison ? this.combinaison.TypeDeCombinaison : new bll_pointsBase_1.PointsBase();
        },
        enumerable: true,
        configurable: true
    });
    return Groupe;
}());
exports.Groupe = Groupe;
//# sourceMappingURL=bll.groupe.js.map