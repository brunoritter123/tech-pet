import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PoButtonGroupItem, PoComboComponent, PoComboOption, PoInfoOrientation, PoModalAction, PoModalComponent, PoSelectOption, PoStepperComponent, PoTableColumn, PoTableRowTemplateArrowDirection } from '@po-ui/ng-components';

@Component({
  selector: 'app-step-orcamento',
  templateUrl: './step-orcamento.component.html'
})
export class StepOrcamentoComponent implements OnInit {
  // @ViewChild('modalProduto', { static: true }) poModalProduto!: PoModalComponent;
  // @ViewChild('modalServico', { static: true }) poModalServico!: PoModalComponent;
  @ViewChild('stepEntraVeiculoform', { static: true }) stepEntraVeiculoform!: NgForm;
  @Input() stepper!: PoStepperComponent;
  itemOs: string = '';
  valorItem: number | undefined;
  responsavelItem: string = '';
  custoProduto: number | undefined;

  orientacaoInfo = PoInfoOrientation.Horizontal;
  arrowDirection = PoTableRowTemplateArrowDirection.Right

  opcoesServicosOriginal: Array<PoComboOption> = [{
    label: "Mão de Obra",
    value: "Mão de Obra"
  }];

  opcoesServicos: Array<PoComboOption> = [...this.opcoesServicosOriginal];
  tipoItem = 1;

  columns: Array<PoTableColumn> = [{
    label: 'Descrição',
    property: 'descricao',
    type: 'string'
  }, {
    label: 'Qtd',
    property: 'qtd',
    type: 'number'
  }, {
    label: 'Total',
    property: 'valor',
    type: 'currency'
  }, {
    label: 'Ações',
    property: 'columnIcon',
    type: 'icon',
    action: () => console.log('teste'),
    // action: this.favorite.bind(this),
    icons: [{
      value: 'delete',
      icon: 'po-icon-delete',
      color: 'color-12',
      action: () => console.log('teste'),
      // action: this.remove.bind(this)
    }]
  }]

  itemsOs = [{
    descricao: 'Mão de Obra',
    qtd: 1,
    valor: 1200,
    columnIcon: ['po-icon-delete']
  }, {
    descricao: 'Oleo',
    qtd: 3,
    valor: 500,
    columnIcon: ['po-icon-delete']
  }]

  constructor() { }

  ngOnInit(): void {
  }

  alteracaoServico(event: any) {
    this.opcoesServicos = [...this.opcoesServicosOriginal, { value: event.target.value, label: event.target.value }]
  }

  openModalAddItem(modal: PoModalComponent, comboAutoFoco: PoComboComponent) {
    modal.open();
    new Promise(r => setTimeout(r, 100)).then(() => comboAutoFoco.focus());
  }

  addItem(comboAutoFoco: PoComboComponent) {
    comboAutoFoco.focus();
  }

  fecharModal(modal: PoModalComponent) {
    modal.close()
  }

  showEditRow(row: any, index: number){
    return true;
  }
}
