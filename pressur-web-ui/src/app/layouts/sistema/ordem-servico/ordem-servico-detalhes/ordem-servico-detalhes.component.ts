import { Component, ViewChild } from '@angular/core';
import { PoBreadcrumb, PoPageAction, PoStepperComponent } from '@po-ui/ng-components';

@Component({
  selector: 'app-ordem-servico-detalhes',
  templateUrl: './ordem-servico-detalhes.component.html'
})
export class OrdemServicoDetalhesComponent {
  @ViewChild('stepper') stepper!: PoStepperComponent;

  acoesEntrada: Array<PoPageAction> = [{
    label: 'Avançar p/ orçamento',
    action: this.nextStep.bind(this),
    icon: 'po-icon-last-page'
  }, {
    label: 'Salvar',
    action: this.onConcluirCadastro,
    icon: 'po-icon-ok'
  }];

  acoes: Array<PoPageAction> = this.acoesEntrada;

  breadcrumb: PoBreadcrumb = {
    items: [{
      label: "IGH-9850 - Celta 2009 - Preto",
      action: this.onConcluirCadastro.bind(this)
    }, {
      label: "Bruno - (11)-98087-5041",
      action: this.onConcluirCadastro.bind(this)
    }, {
      label: "Carlinhos",
      action: this.onConcluirCadastro.bind(this)
    }, {
      label: "R$ 1.700,00",
      action: this.onConcluirCadastro.bind(this)
    }]
  }

  constructor() { }

  onChangeStep(){
    var step = this.stepper?.stepList?.find(step => step.status == 'active');

    switch (step?.label) {
      case 'Entrada':
        this.onActiveStepEntrada();
        break;
      case 'Orçamento':
        this.onActiveStepOrcamento();
        break;
      case 'Conclusão':
        this.onActiveStepConclusao();
        break;
      default:
        this.onActiveStepEntrada();
        break;
    }
  }

  private nextStep() {
    this.stepper.next();
  }

  private onActiveStepEntrada(){
    this.acoes = this.acoesEntrada;
  }

  private onActiveStepOrcamento(){
    this.acoes = [{
      label: 'Avançar p/ Negociação',
      action: this.nextStep.bind(this),
      icon: 'po-icon-last-page'
    }, {
      label: 'Salvar',
      action: this.onConcluirCadastro,
      icon: 'po-icon-ok'
    }];
  }

  private onActiveStepConclusao(){
    this.acoes = [{
      label: 'Concluir OS',
      action: this.onConcluirCadastro,
      icon: 'po-icon-ok'
    }, {
      label: 'Salvar',
      action: this.onConcluirCadastro,
      icon: 'po-icon-ok'
    }];
  }

  onConcluirCadastro(){
    console.log("concluir")
  }


}
