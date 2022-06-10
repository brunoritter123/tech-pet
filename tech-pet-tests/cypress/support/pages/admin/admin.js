export {ELEMENTOS, DADOS}

const ELEMENTOS = {
  menu: ".po-icon-menu",
  itemMenu: "div.po-menu-icon-label"
}

const DADOS = {
}

Cypress.Commands.add("abrirMenu", () => {
  cy.get(ELEMENTOS.menu)
    .should('be.visible')
    .click()
});

Cypress.Commands.add("clickItemMenu", (item) => {
  cy.get(ELEMENTOS.itemMenu)
    .should('be.visible')
    .contains(item)
    .click()
});

Cypress.Commands.add("visitItemMenu", (item) => {
  cy.visitAdmin();
  cy.location('pathname').should('eq', '/admin')

  cy.abrirMenu();
  cy.clickItemMenu(item);
});