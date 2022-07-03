import { Injectable } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { JwtModel } from './jwt-model'

@Injectable()
export class AuthService {
  private readonly jwtDescode = jwtDecode;

  constructor() {}

  private getToken():  JwtModel | undefined {
    const userLogin = sessionStorage.getItem('PO_USER_LOGIN');
    const userLoginJson = !!userLogin ? JSON.parse(userLogin) : {};
    const token = userLoginJson?.token ? userLoginJson.token : "";

    return !!token ? this.jwtDescode<JwtModel>(token) : undefined;
  }

  public isAuthenticated(): boolean {
    const token = this.getToken();
    if (!token) return false;

    return !!token.exp && new Date(token.exp * 1000) > new Date();
  }

  public containsRole(role: string): boolean {
    const token = this.getToken();
    if (!token) return false;

    if (typeof token.role === 'string') {
      return token.role === role;

    } else if (Array.isArray(token.role)) {
      return token.role.indexOf(role) > -1;
    }

    return false
  }

}