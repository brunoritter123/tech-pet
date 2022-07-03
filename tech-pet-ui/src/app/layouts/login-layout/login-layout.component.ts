import { Component, OnInit } from '@angular/core';
import { PoLanguage } from '@po-ui/ng-components';
import { PoPageLogin, PoPageLoginAuthenticationType } from '@po-ui/ng-templates';

@Component({
  selector: 'app-login-layout',
  templateUrl: 'login-layout.component.html',
  styles: [
  ]
})
export class LoginLayoutComponent implements OnInit {

  readonly languages: Array<PoLanguage> = [{language: 'pt', description: 'Português'}];
  loading = false;
  readonly authenticationType: PoPageLoginAuthenticationType = PoPageLoginAuthenticationType.Bearer;
  readonly authenticationUrl: string = "https://localhost:5001/api/v1/Identity/Login"

  constructor() { }

  ngOnInit(): void {
  }

  loginSubmit(page: PoPageLogin) {
    this.loading = true;
  }

}
