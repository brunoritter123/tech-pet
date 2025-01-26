import { Component, OnInit } from '@angular/core';
import { PoPageAction } from '@po-ui/ng-components';

@Component({
  selector: 'app-ordem-servico-lista',
  templateUrl: './ordem-servico-lista.component.html'
})
export class OrdemServicoListaComponent implements OnInit {

  readonly acoes: Array<PoPageAction> = [{
    label: 'Nova Ordem em Avaliação',
    icon: 'po-icon-plus',
    type: 'default',
    url: 'ordem-servico/incluir'
  }];

  constructor() {
  }

  ngOnInit(): void {
  }

  private acaoIncluir() {

  }
}
