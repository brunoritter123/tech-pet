import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdemServicoDetalhesComponent } from './ordem-servico-detalhes/ordem-servico-detalhes.component';
import { OrdemServicoListaComponent } from './ordem-servico-lista/ordem-servico-lista.component';

const routes: Routes = [
  {
    path: '',
    component: OrdemServicoListaComponent
  },
  {
    path: 'incluir',
    component: OrdemServicoDetalhesComponent
  },
  {
    path: 'editar/:id',
    component: OrdemServicoDetalhesComponent
  },
  {
    path: 'detalhes/:id',
    component: OrdemServicoDetalhesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdemServicoRoutingModule { }
