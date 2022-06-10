/// <reference types="cypress" />
const LOGIN = require('../support/pages/login');
const dados = LOGIN.DADOS;

describe('Teste rota login', () => {
  before(() => {
    cy.resetBancoDeDados();
  })

  beforeEach(() => {
    cy.goToLogin();
  })

  it('Verifica se o login redireciona para o home do admin', () => {
    cy.setLogin(dados.loginAdmin.login);
    cy.setSenha(dados.loginAdmin.password);

    cy.interceptPostLogin('login')

    cy.clickEntrar();

    cy.wait('@login').its('response.statusCode').should('eq', 200)

    cy.location('pathname')
      .should('eq', '/admin');
  })

  it('Verifica se o login redireciona para o home de um usuário comum', () => {
    cy.setLogin(dados.loginComum.login);
    cy.setSenha(dados.loginComum.password);

    cy.interceptPostLogin('login')

    cy.clickEntrar();

    cy.wait('@login').its('response.statusCode').should('eq', 200)

    cy.location('pathname')
      .should('eq', '/');
  })

  it('Verifica se valida um usuário e senha errada', () => {
    cy.setLogin(dados.loginComum.login);
    cy.setSenha("senhaErrada");

    cy.interceptPostLogin('login')

    cy.clickEntrar();

    cy.wait('@login').its('response.statusCode').should('eq', 401);

    cy.getToasterError()
      .should('be.visible');
  })
})