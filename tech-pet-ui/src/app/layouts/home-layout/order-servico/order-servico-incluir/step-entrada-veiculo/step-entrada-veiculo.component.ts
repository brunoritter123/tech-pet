import { Component, HostListener, Input, OnInit, ViewChild } from '@angular/core';
import { PoStepperComponent, PoInputComponent, PoStepComponent, PoPageAction } from '@po-ui/ng-components';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-step-entrada-veiculo',
  templateUrl: './step-entrada-veiculo.component.html'
})
export class StepEntradaVeiculoComponent implements OnInit {
  @ViewChild('stepEntraVeiculoform', { static: true }) stepEntraVeiculoform!: NgForm;
  @Input() stepper!: PoStepperComponent;

  placa: string = '';
  veiculo: string = '';
  cor: string = '';
  kmAtual: number = 0;
  descricaoDoProblema: string = '';
  observacoesInternas: string = '';
  acoes: Array<PoPageAction> = [{
    label: 'Avançar p/ orçamento',
    action: this.avancarStep
  }, {
    label: 'Salvar Entrada',
    action: this.avancarStep
  }];

  nome: string = '';
  telefone: string = '';
  email: string = '';
  observacoesCliente: string = '';

  responsavelAvaliacao: string = '';

  constructor() { }

  ngOnInit(): void {
  }

  avancarStep() {
    this.stepper.next()
  }

}
