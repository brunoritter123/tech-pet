import { NgModule } from '@angular/core';
import { PoModule } from '@po-ui/ng-components';
import { PoTemplatesModule } from '@po-ui/ng-templates';
import { EmpresaAdminListaComponent } from './empresa-admin-lista/empresa-admin-lista.component';
import { EmpresaAdminDetalhesComponent } from './empresa-admin-detalhes/empresa-admin-detalhes.component';
import { EmpresaAdminRoutingModule } from './empresa-admin.rote';


@NgModule({
  declarations: [
    EmpresaAdminDetalhesComponent,
    EmpresaAdminListaComponent
    ],
  imports: [
    EmpresaAdminRoutingModule,
    PoModule,
    PoTemplatesModule,
  ],
  exports: []
})
export class EmpresaAdminModule { }
