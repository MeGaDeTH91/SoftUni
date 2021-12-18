describe("Categories page", () => {
  beforeEach(() => {
    cy.visit("http://localhost:3000/login");

    cy.get("input[name=username]").type("marto123");
    cy.get("input[name=password]").type(`123{enter}`);

    cy.wait(5500);

    cy.getCookie("x-auth-token").should("exist");

    cy.visit("http://localhost:3000/categories/all");
    cy.wait(500);
  });

  it("Should show nav correctly!", () => {
    cy.get("nav").should("be.visible");
  });

  it("Should show categories page title!", () => {
    cy.get("h1").contains("Categories");
  });

  it("Should list all categories successfully!", () => {
    cy.get('div').contains('Musical Instruments');
    cy.get('div').contains('Electronics');
    cy.get('div').contains('Accessories');
    cy.get('div').contains('Sports equipment');
    cy.get('div').contains('Machines');
  });

  it("Should list all category products successfully!", () => {
    cy.get('div').contains('Musical Instruments').click();

    cy.get("h1").contains("Musical Instruments");
    cy.get("div").contains("Ibanez RG550");
    cy.get("div").contains("Jackson SL2");

    cy.contains("First Play Title 404").should("not.exist");
    cy.contains("First Play Title 2150").should("not.exist");
  });

  it("Should show footer correctly!", () => {
    cy.get("footer").should("be.visible");
    cy.get("p").contains("Spring^React-Store © 2021");
  });
});
