import { Component, OnInit } from '@angular/core';

import { PoMenuItem } from '@po-ui/ng-components';

@Component({
  selector: 'app-sistema',
  templateUrl: './sistema.component.html',
  styles: [
  ]
})
export class SistemaComponent implements OnInit {

  readonly menus: Array<PoMenuItem> = [
    { label: 'Home', link: 'dashboard', icon: 'po-icon-home' },
    { label: 'Order de Serviço', link: 'ordem-servico', icon: 'po-icon-document-filled'}
  ];

  constructor() { }

  ngOnInit(): void {
  }

  private onClick() {
    alert('Clicked in menu item')
  }
}
