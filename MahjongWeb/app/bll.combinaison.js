"use strict";
(function (ETypeCombinaison) {
    /// <summary>
    /// show, pung, kong
    /// </summary>
    ETypeCombinaison[ETypeCombinaison["Combinaison"] = 1] = "Combinaison";
    /// <summary>
    /// la paire finale
    /// </summary>
    ETypeCombinaison[ETypeCombinaison["Paire"] = 2] = "Paire";
    /// <summary>
    /// un ou plusieurs honneur
    /// </summary>
    ETypeCombinaison[ETypeCombinaison["Honneur"] = 3] = "Honneur";
})(exports.ETypeCombinaison || (exports.ETypeCombinaison = {}));
var ETypeCombinaison = exports.ETypeCombinaison;
var bll_pointsBase_1 = require('./bll.pointsBase');
////////////////////////////////////////////////////
/// une combinaison valide et son poid
var Combinaison = (function () {
    function Combinaison() {
    }
    Object.defineProperty(Combinaison.prototype, "TypeDeCombinaison", {
        get: function () {
            var pb = new bll_pointsBase_1.PointsBase();
            pb.nombreCombinaison = this.nombreTuiles >= 3 ? 1 : 0;
            pb.nombrePaire = this.nombreTuiles == 2 ? 1 : 0;
            return pb;
        },
        enumerable: true,
        configurable: true
    });
    ;
    Combinaison.prototype.nombrePoint = function (expose) {
        return expose ? this.nombrePointsSiVisible : this.nombrePointsSiMasque;
    };
    return Combinaison;
}());
exports.Combinaison = Combinaison;
//# sourceMappingURL=bll.combinaison.js.map