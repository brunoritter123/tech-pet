import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmpresaAdminListaComponent } from './empresa-admin-lista/empresa-admin-lista.component';
import { EmpresaAdminDetalhesComponent } from './empresa-admin-detalhes/empresa-admin-detalhes.component';

const routes: Routes = [
  {
    path: '',
    component: EmpresaAdminListaComponent
  },
  {
    path: 'incluir',
    component: EmpresaAdminDetalhesComponent
  },
  {
    path: 'editar/:id',
    component: EmpresaAdminDetalhesComponent
  },
  {
    path: 'detalhes/:id',
    component: EmpresaAdminDetalhesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmpresaAdminRoutingModule { }
