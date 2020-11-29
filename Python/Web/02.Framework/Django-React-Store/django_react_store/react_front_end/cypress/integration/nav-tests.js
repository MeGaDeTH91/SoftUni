describe("Navbar buttons", () => {
  beforeEach(() => {
    cy.visit("http://localhost:3000/");
  });

  it("Should show nav correctly!", () => {
    cy.get("nav").should("be.visible");
  });

  it("Should show home button link correctly!", () => {
    cy.get("a").contains("Django-React-store");
  });

  it("Should show search link correctly!", () => {
    cy.get("form").contains("Search");
  });

  it("Should filter products on search link correctly!", () => {
    cy.get("input[name=search]").type("Ibanez{enter}");
    cy.wait(500);
    cy.get("div").contains("Ibanez RG550");
    cy.contains("Jackson SL2").should("not.exist");
  });

  it("Should show guest links correctly!", () => {
    cy.get("a").contains("Explore Products");
    cy.get("a").contains("Explore Categories");
    cy.get("a").contains("Register");
    cy.get("a").contains("Login");
    cy.contains("Profile").should("not.exist");
    cy.get("div").contains("Ibanez RG550");
    cy.get("div").contains("Jackson SL2");
  });

  it("Should show user buttons", function () {
    cy.visit("http://localhost:3000/login");

    cy.get("input[name=username]").type("marto123");
    cy.get("input[name=password]").type(`123{enter}`);

    cy.wait(5500);

    cy.getCookie("x-auth-token").should("exist");

    cy.get("a").contains("Explore Products");
    cy.get("a").contains("Shop by Category");
    cy.get("a").contains("Profile");
    cy.get("a").contains("ShoppingCart");
    cy.get("a").contains("Logout");
    cy.contains("Users").should("not.exist");
    cy.contains("Add Product").should("not.exist");
    cy.contains("Add Category").should("not.exist");
    cy.get("h1").contains("Products");
    cy.get("div").contains("Ibanez RG550");
    cy.get("div").contains("Jackson SL2");
  });

  it("Should show admin buttons", function () {
    cy.visit("http://localhost:3000/login");

    cy.get("input[name=username]").type("marto");
    cy.get("input[name=password]").type(`123{enter}`);

    cy.wait(5500);

    cy.getCookie("x-auth-token").should("exist");

    cy.get("a").contains("Explore Products");
    cy.get("a").contains("Shop by Category");
    cy.get("a").contains("User");
    cy.get("a").contains("Add Product");
    cy.get("a").contains("Add Category");
    cy.get("a").contains("Profile");
    cy.get("a").contains("ShoppingCart");
    cy.get("a").contains("Logout");
    cy.get("h1").contains("Products");
    cy.get("div").contains("Ibanez RG550");
    cy.get("div").contains("Jackson SL2");
  });

  it("Should show footer correctly!", () => {
    cy.get("footer").should("be.visible");
    cy.get("p").contains("Django-React-Store © 2020");
  });
});
