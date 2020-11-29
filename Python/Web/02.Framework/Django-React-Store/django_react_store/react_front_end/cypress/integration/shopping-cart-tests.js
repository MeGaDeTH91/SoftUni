describe("Shopping cart page", () => {
  beforeEach(() => {
    cy.visit("http://localhost:3000/login");

    cy.get("input[name=username]").type("marto123");
    cy.get("input[name=password]").type(`123{enter}`);

    cy.wait(5500);

    cy.getCookie("x-auth-token").should("exist");

    cy.visit("http://localhost:3000/shopping-cart");
    cy.wait(500);
  });

  it("Should show nav correctly!", () => {
    cy.get("nav").should("be.visible");
  });

  it("Should show shopping cart page title!", () => {
    cy.get("h1").contains("Your shopping cart");
  });

  it("Should show no products in cart successfully!", () => {
    cy.get("p").contains("No products in your cart.");
  });

  it("Cart should work as expected!", () => {
    cy.get("p").contains("No products in your cart.");
    cy.get("a").contains("Explore Products").click();

    cy.get("div").contains("Jackson SL2");
    cy.get("div").contains("Ibanez RG550").click();
    cy.wait(300);

    cy.contains("Add to cart").click();
    cy.wait(300);
    cy.get("a").contains("ShoppingCart").click();

    cy.url().should("eq", "http://localhost:3000/shopping-cart");

    cy.get("div").contains("Ibanez RG550");
    cy.contains("Jackson SL2").should("not.exist");
    cy.contains("First Play Title 404").should("not.exist");
    cy.contains("First Play Title 2150").should("not.exist");

    cy.get("button").contains("Remove product").click();
    cy.wait(200);

    cy.get("div").contains("Product removed from cart successfully!");
    cy.wait(1000);

    cy.contains("No products in your cart.").should('exist');
  });

  it("Cart finish order as expected!", () => {
    cy.get("p").contains("No products in your cart.");
    cy.get("a").contains("Explore Products").click();

    cy.get("div").contains("Jackson SL2");
    cy.get("div").contains("Ibanez RG550").click();
    cy.wait(300);

    cy.contains("Add to cart").click();
    cy.wait(1000);
    cy.get("div").contains("Jackson SL2").click();
    cy.wait(300);
    cy.contains("Add to cart").click();
    cy.wait(1000);

    cy.get("a").contains("ShoppingCart").click();
    cy.wait(2000);
    cy.url().should("eq", "http://localhost:3000/shopping-cart");

    cy.get("div").contains("Ibanez RG550");
    cy.get("div").contains("Jackson SL2");
    cy.contains("First Play Title 404").should("not.exist");
    cy.contains("First Play Title 2150").should("not.exist");

    cy.get("button").contains("Place order").click();
    cy.wait(200);
    cy.get("div").contains("Order placed successfully!");

    cy.wait(3000);

    cy.contains("No products in your cart.").should('exist');
  });

  it("Should show footer correctly!", () => {
    cy.get("footer").should("be.visible");
    cy.get("p").contains("Django-React-Store © 2020");
  });
});
