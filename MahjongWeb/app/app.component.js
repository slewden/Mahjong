"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var utilisateur_1 = require('./utilisateur');
var AppComponent = (function () {
    function AppComponent() {
        this.name = 'Mahjong';
        ////this.joueurs = [
        ////  new Utilisateur('Jean', '84fa3256-ce51-409f-89cb-0f3d7aaa8aa9'),
        ////  new Utilisateur('Paul', '684464aa-02c7-4dde-8e94-b7652f12f8b9'),
        ////  new Utilisateur('Belle', 'ea3af75a-ad4d-4a8a-8415-24fb9d79b7e6'),
        ////  new Utilisateur('Mandy', 'ac4790cc-6ed8-4432-ad06-12fcde5984b9'),
        ////];
        this.apiKey = localStorage.getItem('apiKey');
        if (!this.apiKey && this.joueurs && this.joueurs.length > 0) {
            this.apiKey = this.generateGUID();
            this.apiKey = this.joueurs[0].apiKey; // for debug
            localStorage.setItem('apiKey', this.apiKey);
        }
    }
    // s�lection de l'utilisateur en cours
    AppComponent.prototype.selectionneJoueur = function (util) {
        this.joueurSelectionne = util;
    };
    ;
    // ajouter un joueur
    AppComponent.prototype.addJoueur = function (nom) {
        var u = new utilisateur_1.Utilisateur(nom, '');
        this.joueurs.push(u);
        this.selectionneJoueur(u);
    };
    ;
    // g�n�re un GUID
    AppComponent.prototype.generateGUID = function () {
        var d = new Date().getTime();
        if (window.performance && typeof window.performance.now === "function") {
            d += performance.now(); //use high-precision timer if available
        }
        var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
        return uuid;
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'mahjong-app',
            //template: ``,
            // pro viders:[],
            templateUrl: '/Partials/partiePage.html'
        }), 
        __metadata('design:paramtypes', [])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//var Vent = {};
//Vent[Symbol.iterator] = function* () {
//  yield 'Est';
//  yield 'Sud';
//  yield 'Ouest';
//  yield 'Nord';
//};
//# sourceMappingURL=app.component.js.map