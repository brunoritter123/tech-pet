/// <reference types="cypress" />

const EMPRESA = require('../support/pages/admin/empresa');
const dados = EMPRESA.DADOS;

describe('Teste rota empresas-admin', () => {
  before(() => {
    cy.loginAdmin();
  })

  beforeEach(() => {
    cy.visitMenuEmpresa();
  })

  it('Verifica a rota de empresa para o admin', () => {
  })

  it('Verifica a rota de empresa para o admin', () => {
  })
})