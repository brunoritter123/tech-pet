import { Component, OnInit } from '@angular/core';

import { PoMenuPanelItem } from '@po-ui/ng-components';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html'
})
export class AdminComponent implements OnInit {

  readonly menus: PoMenuPanelItem[] = [
    { label: 'Dashboard', link: 'dashboard', icon: 'po-icon-home'},
    { label: 'Empresas', link: 'empresa', icon: 'po-icon-company' }
  ];

  constructor() { }

  ngOnInit(): void {
  }


}
