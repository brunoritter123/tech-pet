import { Component, OnInit } from '@angular/core';

import { PoMenuPanelItem } from '@po-ui/ng-components';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html'
})
export class AdminLayoutComponent implements OnInit {

  readonly menus: PoMenuPanelItem[] = [
    { label: 'Empresas', link: 'empresas', icon: 'po-icon-company' }
  ];

  constructor() { }

  ngOnInit(): void {
  }


}
