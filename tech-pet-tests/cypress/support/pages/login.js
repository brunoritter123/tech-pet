export {ELEMENTOS, DADOS}

const ELEMENTOS = {
  inputLogin: 'input[name="login"]',
  inputPassword: 'input[name="password"]',
  buttonEntrar: 'po-button[ng-reflect-label="Entrar"]'
}

const DADOS = {
  loginAdmin: {
    login: 'brunosk8123@hotmail.com',
    password: 'teste'
  },
  loginComum: {
    login: 'comum@comum.com',
    password: 'teste'
  }
}

Cypress.Commands.add("setLogin", (texto) => {
  cy.get(ELEMENTOS.inputLogin)
    .should('be.visible')
    .type(texto);
});

Cypress.Commands.add("setSenha", (texto) => {
  cy.get(ELEMENTOS.inputPassword)
    .should('be.visible')
    .type(texto);
});

Cypress.Commands.add("clickEntrar", () => {
  cy.get(ELEMENTOS.buttonEntrar)
    .should('be.visible')
    .should('have.attr', 'ng-reflect-disabled', 'false')
    .click();
});

Cypress.Commands.add("interceptPostLogin", (alias) => {
  cy.intercept('POST', '**Login**').as(alias)
});