import { Component, OnInit } from '@angular/core';
import { PoPageAction } from '@po-ui/ng-components';

@Component({
  selector: 'app-order-servico',
  templateUrl: './order-servico.component.html'
})
export class OrderServicoComponent implements OnInit {


  readonly acoes: Array<PoPageAction> = [{
    label: 'Nova Ordem em Avaliação',
    icon: 'po-icon-plus',
    type: 'default',
    url: 'order-servico-incluir'
  }];

  constructor() {
  }

  ngOnInit(): void {
  }

  private acaoIncluir() {

  }

}
