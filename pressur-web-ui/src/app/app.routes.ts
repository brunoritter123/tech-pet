import { Routes } from '@angular/router';
import { AuthGuardService } from './auth/auth-guard.service';
import { AuthAdminGuardService } from './auth/auth-admin-guard.service';
import { LoginComponent } from './layouts/login/login.component';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./layouts/sistema/sistema.module').then(m => m.SistemaModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'admin',
    loadChildren: () => import('./layouts/admin/admin.module').then(m => m.AdminModule),
    canActivate: [AuthAdminGuardService]
  },
  { path: '**', redirectTo: '' }
];
