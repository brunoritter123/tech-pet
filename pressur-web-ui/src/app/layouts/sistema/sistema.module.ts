import { NgModule } from '@angular/core';
import { PoModule } from '@po-ui/ng-components';
import { DashboardComponent } from './dashboard/dashboard.component';
import { OrdemServicoModule } from './ordem-servico/ordem-servico.module';
import { SistemaComponent } from './sistema.component';
import { SistemaRoutingModule } from './sistema.rote';


@NgModule({
  declarations: [
    SistemaComponent,
    DashboardComponent
  ],
  imports: [
    SistemaRoutingModule,
    OrdemServicoModule,
    PoModule
  ],
  exports: []
})
export class SistemaModule { }
