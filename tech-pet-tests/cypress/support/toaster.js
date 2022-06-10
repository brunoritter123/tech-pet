/// <reference types="cypress" />

const ELEMENTOS = {
  toasterError: '.po-toaster.po-toaster-error'
}

const DADOS = {
}

Cypress.Commands.add("getToasterError", () => {
    return cy.get(ELEMENTOS.toasterError)
});