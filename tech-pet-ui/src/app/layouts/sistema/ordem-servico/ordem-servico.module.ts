import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { PoModule } from '@po-ui/ng-components';
import { PoTemplatesModule } from '@po-ui/ng-templates';
import { OrdemServicoDetalhesComponent } from './ordem-servico-detalhes/ordem-servico-detalhes.component';
import { StepConclusaoComponent } from './ordem-servico-detalhes/step-conclusao/step-conclusao.component';
import { StepEntradaVeiculoComponent } from './ordem-servico-detalhes/step-entrada-veiculo/step-entrada-veiculo.component';
import { StepOrcamentoComponent } from './ordem-servico-detalhes/step-orcamento/step-orcamento.component';
import { OrdemServicoListaComponent } from './ordem-servico-lista/ordem-servico-lista.component';
import { OrdemServicoRoutingModule } from './ordem-servico.rote';


@NgModule({
  declarations: [
    OrdemServicoDetalhesComponent,
    OrdemServicoListaComponent,
    StepConclusaoComponent,
    StepEntradaVeiculoComponent,
    StepOrcamentoComponent
    ],
  imports: [
    OrdemServicoRoutingModule,
    PoModule,
    PoTemplatesModule,
    FormsModule,
    CommonModule,
  ],
  exports: []
})
export class OrdemServicoModule { }
