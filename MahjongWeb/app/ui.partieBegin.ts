import { Component } from '@angular/core';

import { Partie } from './bll.partie';

@Component({
  moduleId: module.id,
  selector: 'partie-begin',
  templateUrl: '/Partials/ui.partieBegin.html'
})
export class UiPartieBegin {
  partie: Partie;
  est: string;
  sud: string;
  ouest: string;
  nord: string;

  get diag(): string {
    return JSON.stringify(this);
  }
};