import { Component, OnInit } from '@angular/core';
import { PoLanguage } from '@po-ui/ng-components';
import { PoPageLoginAuthenticationType } from '@po-ui/ng-templates';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: 'login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {

  readonly languages: Array<PoLanguage> = [{language: 'pt', description: 'Português'}];
  readonly authenticationType: PoPageLoginAuthenticationType = PoPageLoginAuthenticationType.Bearer;
  readonly authenticationUrl: string = environment.baseUrl + "/v1/Identity/Login"
  loading = false;

  constructor() { }

  ngOnInit(): void {
  }

  loginSubmit(page: any) {
    this.loading = true;
  }

}
