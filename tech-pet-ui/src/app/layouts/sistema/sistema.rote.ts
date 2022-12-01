import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SistemaComponent } from './sistema.component';

const routes: Routes = [
  {
    path: '',
    component: SistemaComponent,
    children: [
      {
        path: '',
        component: DashboardComponent
      },
      {
        path: 'dashboard',
        component: DashboardComponent
      },
      {
        path: 'ordem-servico',
        loadChildren: () => import('./ordem-servico/ordem-servico.module').then(m => m.OrdemServicoModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SistemaRoutingModule { }
