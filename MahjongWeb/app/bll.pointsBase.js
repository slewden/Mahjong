"use strict";
////////////////////////////////////////////////////
/// classe de base pour compter les combinaisons
var PointsBase = (function () {
    function PointsBase() {
    }
    Object.defineProperty(PointsBase.prototype, "mahjong", {
        get: function () {
            return this.nombreCombinaison == 4 && this.nombrePaire == 1;
        },
        enumerable: true,
        configurable: true
    });
    return PointsBase;
}());
exports.PointsBase = PointsBase;
//# sourceMappingURL=bll.pointsBase.js.map