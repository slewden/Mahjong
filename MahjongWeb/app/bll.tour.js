"use strict";
var Tour = (function () {
    function Tour(numero, withHonnors, est, sud, ouest, nord) {
        this.numeroTour = numero;
        this.withHonnors = withHonnors;
        this.joueurs = [];
        this.joueurs.push(est);
        this.joueurs.push(sud);
        this.joueurs.push(ouest);
        this.joueurs.push(nord);
        this.manches = [];
    }
    return Tour;
}());
exports.Tour = Tour;
;
//# sourceMappingURL=bll.tour.js.map