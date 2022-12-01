import { NgModule } from '@angular/core';
import { PoModule } from '@po-ui/ng-components';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminComponent } from './admin.component';
import { AdminRoutingModule } from './admin.rote';
import { EmpresaAdminModule } from './empresa-admin/empresa-admin.module';


@NgModule({
  declarations: [
    AdminComponent,
    AdminDashboardComponent
  ],
  imports: [
    AdminRoutingModule,
    EmpresaAdminModule,
    PoModule
  ],
  exports: []
})
export class AdminModule { }
