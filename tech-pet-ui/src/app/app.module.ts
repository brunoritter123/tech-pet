import { NgModule, LOCALE_ID, DEFAULT_CURRENCY_CODE } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import ptBr from '@angular/common/locales/pt';
import {CommonModule, registerLocaleData} from '@angular/common';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PoModule } from '@po-ui/ng-components';
import { PoPageLoginModule, PoTemplatesModule } from '@po-ui/ng-templates';
import { AuthService } from './auth/auth.service';
import { AuthGuardService } from './auth/auth-guard.service';
import { AuthAdminGuardService } from './auth/auth-admin-guard.service';
import { AdminModule } from './layouts/admin/admin.module';
import { SistemaModule } from './layouts/sistema/sistema.module';
import { LoginComponent } from './layouts/login/login.component';
registerLocaleData(ptBr);

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
    ],
  imports: [
    AppRoutingModule,
    AdminModule,
    SistemaModule,
    BrowserModule,
    CommonModule,
    PoModule,
    PoTemplatesModule,
    PoPageLoginModule,
    FormsModule,
    BrowserAnimationsModule
  ],
  providers: [
    AuthService,
    AuthGuardService,
    AuthAdminGuardService,
    {
      provide: LOCALE_ID,
      useValue: 'pt'
    },
    {
      provide:  DEFAULT_CURRENCY_CODE,
      useValue: 'BRL'
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
