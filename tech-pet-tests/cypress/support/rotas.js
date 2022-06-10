/// <reference types="cypress" />

const login = require('../support/pages/login');

const DADOS = {
  "base": "http://localhost:4200/",
  "baseApi": "https://localhost:5001",
  "adminUrl": "admin",
  "loginUrl": "login"
}

Cypress.Commands.add("visitAdmin", () => {
    cy.visit(DADOS.base + DADOS.adminUrl);
});

Cypress.Commands.add("goToLogin", () => {
    cy.visit(DADOS.base + DADOS.loginUrl);
});

Cypress.Commands.add("loginAdmin", () => {
  cy.goToLogin();
  cy.setLogin(login.DADOS.loginAdmin.login);
  cy.setSenha(login.DADOS.loginAdmin.password);

  cy.interceptPostLogin('login')

  cy.clickEntrar();

  cy.wait('@login').its('response.statusCode').should('eq', 200)
});

Cypress.Commands.add("resetBancoDeDados", () => {
  cy.request('POST', `${DADOS.baseApi}/api/v1/Tests/ResetDb`)
});