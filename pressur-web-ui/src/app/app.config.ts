import { provideRouter } from '@angular/router';
import ptBr from '@angular/common/locales/pt';

import { routes } from './app.routes';

import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';

import { PoHttpRequestModule } from '@po-ui/ng-components';

import { AuthService } from './auth/auth.service';
import { AuthGuardService } from './auth/auth-guard.service';
import { AuthAdminGuardService } from './auth/auth-admin-guard.service';
import { AdminModule } from './layouts/admin/admin.module';
import { SistemaModule } from './layouts/sistema/sistema.module';
import { LoginComponent } from './layouts/login/login.component';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    importProvidersFrom([PoHttpRequestModule]),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideHttpClient(withInterceptorsFromDi()),
    AuthService,
    AuthGuardService,
    AuthAdminGuardService,
  ],
};