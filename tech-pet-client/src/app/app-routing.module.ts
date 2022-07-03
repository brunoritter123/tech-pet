import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeLayoutComponent } from './layouts/home-layout/home-layout.component';
import { HomeComponent } from './layouts/home-layout/home/home.component';
import { LoginLayoutComponent } from './layouts/login-layout/login-layout.component';
import { EmpresaAdminComponent } from './layouts/admin-layout/empresa-admin/empresa-admin.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { AuthGuardService } from './auth/auth-guard.service';
import { AuthAdminGuardService } from './auth/auth-admin-guard.service';
import { OrderServicoComponent } from './layouts/home-layout/order-servico/order-servico.component';
import { OrderServicoIncluirComponent } from './layouts/home-layout/order-servico/order-servico-incluir/order-servico-incluir.component';
import { OrderServicoDetalhesComponent } from './layouts/home-layout/order-servico/order-servico-detalhes/order-servico-detalhes.component';

const routes: Routes = [
  {
    path: '',
    component: HomeLayoutComponent,
    canActivate: [AuthGuardService],
    children: [
      {
        path: '',
        component: HomeComponent,
      },
      {
        path: 'home',
        component: HomeComponent,
      },
      {
        path: 'order-servico',
        component: OrderServicoComponent,
      },
      {
        path: 'order-servico-incluir',
        component: OrderServicoIncluirComponent,
      },
      {
        path: 'order-servico-detalhes/:osId',
        component: OrderServicoDetalhesComponent,
      }
    ]
  },
  {
    path: 'login',
    component: LoginLayoutComponent
  },
  {
    path: 'admin',
    component: AdminLayoutComponent,
    canActivate: [AuthAdminGuardService],
    children: [
      {
        path: 'empresas',
        component: EmpresaAdminComponent
      }
    ]
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
