describe("Admin Category pages", () => {
  beforeEach(() => {
    cy.visit("http://localhost:3000/login");

    cy.get("input[name=username]").type("marto");
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
    cy.get("div").contains("Musical instruments");
    cy.get("div").contains("Electronics");
    cy.get("div").contains("Accessories");
    cy.get("div").contains("Sports equipment");
    cy.get("div").contains("Machines");
  });

  it("Should list all category products successfully!", () => {
    cy.get("div").contains("Musical instruments").click();

    cy.get("h1").contains('Products in category "Musical instruments"');
    cy.get("div").contains("Ibanez RG550");
    cy.get("div").contains("Jackson SL2");

    cy.contains("First Play Title 404").should("not.exist");
    cy.contains("First Play Title 2150").should("not.exist");
  });

  it("Should change category from card successfully!", () => {
    const categoryName = "Dummy testing category";

    cy.get("div")
      .contains(categoryName)
      .parent()
      .parent()
      .parent()
      .contains("Edit Category")
      .click();

    cy.get("input[name=title]").should("have.value", categoryName);

    const categoryTempName = categoryName + "Temp";

    cy.get("input[name=title]").clear().type(categoryTempName);
    cy.get("button").contains("Change category").click();

    // cleanup
    cy.get("div")
      .contains(categoryName)
      .parent()
      .parent()
      .parent()
      .contains("Edit Category")
      .click();
    cy.get("input[name=title]").clear().type(categoryName);
    cy.get("button").contains("Change category").click();
  });

  it("Should throw error on change category with invalid title!", () => {
    const categoryName = "Dummy testing category";

    cy.get("div")
      .contains(categoryName)
      .parent()
      .parent()
      .parent()
      .contains("Edit Category")
      .click();

    cy.get("input[name=title]").should("have.value", categoryName);

    cy.get("input[name=title]").clear().type(" ");
    cy.get("button").contains("Change category").click();

    cy.get("div").contains(
      "Error occured: Please provide valid data."
    );
  });

  it("Should show footer correctly!", () => {
    cy.get("footer").should("be.visible");
    cy.get("p").contains("Django-React-Store © 2020");
  });
});
