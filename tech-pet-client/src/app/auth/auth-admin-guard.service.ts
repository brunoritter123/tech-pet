import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable()
export class AuthAdminGuardService implements CanActivate {
  constructor(public auth: AuthService, public router: Router) {}
  canActivate(): boolean {

    if (!this.auth.isAuthenticated()) {
      this.router.navigate(['login']);
      return false;
    }

    if (!this.auth.containsRole("Admin")){
      this.router.navigate(['']);
      return false;
    }

    return true;
  }
}