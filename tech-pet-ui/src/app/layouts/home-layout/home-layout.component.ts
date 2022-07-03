import { Component, OnInit } from '@angular/core';

import { PoMenuItem } from '@po-ui/ng-components';

@Component({
  selector: 'app-home-layout',
  templateUrl: './home-layout.component.html',
  styles: [
  ]
})
export class HomeLayoutComponent implements OnInit {

  readonly menus: Array<PoMenuItem> = [
    { label: 'Home', link: 'home', icon: 'po-icon-home' },
    { label: 'Order de Serviço', link: 'order-servico', icon: 'po-icon-document-filled'}
  ];

  constructor() { }

  ngOnInit(): void {
  }

  private onClick() {
    alert('Clicked in menu item')
  }
}
