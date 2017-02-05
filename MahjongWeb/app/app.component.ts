import { Component } from '@angular/core';

import { Utilisateur } from './utilisateur';


@Component({
  selector: 'mahjong-app',
  //template: ``,
  // pro viders:[],
  templateUrl:'/Partials/partiePage.html'
})
export class AppComponent {
  name: string;
  apiKey: string;
  joueurs: Array<Utilisateur>;
  joueurSelectionne: Utilisateur;

  constructor() {
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

  // sélection de l'utilisateur en cours
  selectionneJoueur(util: Utilisateur) {
    this.joueurSelectionne = util;
  };

  // ajouter un joueur
  addJoueur(nom: string) {
    let u = new Utilisateur(nom, '');
    this.joueurs.push(u);
    this.selectionneJoueur(u);
  };

  // génère un GUID
  generateGUID() {
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
  }
}



//var Vent = {};
//Vent[Symbol.iterator] = function* () {
//  yield 'Est';
//  yield 'Sud';
//  yield 'Ouest';
//  yield 'Nord';
//};
