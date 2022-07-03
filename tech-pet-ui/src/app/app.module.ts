import { NgModule, LOCALE_ID, DEFAULT_CURRENCY_CODE } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import ptBr from '@angular/common/locales/pt';
import {registerLocaleData} from '@angular/common';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PoModule } from '@po-ui/ng-components';
import { PoPageLoginModule, PoTemplatesModule } from '@po-ui/ng-templates';
import { RouterModule } from '@angular/router';
import { HomeLayoutComponent } from './layouts/home-layout/home-layout.component';
import { LoginLayoutComponent } from './layouts/login-layout/login-layout.component';
import { HomeComponent } from './layouts/home-layout/home/home.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { EmpresaAdminComponent } from './layouts/admin-layout/empresa-admin/empresa-admin.component';
import { AuthService } from './auth/auth.service';
import { AuthGuardService } from './auth/auth-guard.service';
import { AuthAdminGuardService } from './auth/auth-admin-guard.service';
import { OrderServicoComponent } from './layouts/home-layout/order-servico/order-servico.component';
import { OrderServicoIncluirComponent } from './layouts/home-layout/order-servico/order-servico-incluir/order-servico-incluir.component';
import { OrderServicoDetalhesComponent } from './layouts/home-layout/order-servico/order-servico-detalhes/order-servico-detalhes.component';
import { StepEntradaVeiculoComponent } from './layouts/home-layout/order-servico/order-servico-incluir/step-entrada-veiculo/step-entrada-veiculo.component';
import { StepConclusaoComponent } from './layouts/home-layout/order-servico/order-servico-incluir/step-conclusao/step-conclusao.component';
import { StepOrcamentoComponent } from './layouts/home-layout/order-servico/order-servico-incluir/step-orcamento/step-orcamento.component';

registerLocaleData(ptBr);

@NgModule({
  declarations: [
    AppComponent,
    HomeLayoutComponent,
    LoginLayoutComponent,
    HomeComponent,
    AdminLayoutComponent,
    EmpresaAdminComponent,
    OrderServicoComponent,
    OrderServicoIncluirComponent,
    OrderServicoDetalhesComponent,
    StepEntradaVeiculoComponent,
    StepConclusaoComponent,
    StepOrcamentoComponent
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PoModule,
    PoPageLoginModule,
    RouterModule.forRoot([]),
    PoTemplatesModule,
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
