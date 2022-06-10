/// <reference types="cypress" />
export {ELEMENTOS, DADOS}

require('../admin/admin');

const ELEMENTOS = {
}

const DADOS = {
}

Cypress.Commands.add("visitMenuEmpresa", () => {
  cy.visitItemMenu('Empresas')
  cy.location('pathname').should('eq', '/admin/empresas')
});
