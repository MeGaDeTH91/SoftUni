describe("Register page", () => {
  beforeEach(() => {
    cy.visit("http://localhost:3000/register");
  });

  it("Should show register page title!", () => {
    cy.get("h1").contains("Register page");
  });

  it("Should show nav correctly!", () => {
    cy.get("nav").should("be.visible");
  });

  it("Should register user and set auth cookie when logging in!", function () {
    const currentName = userID_generate();
    cy.get("input[name=username]").type(currentName);
    cy.get("input[name=email]").type("dummy@mail.bg");
    cy.get("input[name=first_name]").type("Test");
    cy.get("input[name=last_name]").type("User");
    cy.get("input[name=address]").type("dummy address");

    cy.get("input[name=password]").type(`123`);
    cy.get("input[name=re-password]").type(`123{enter}`);

    cy.wait(5500);

    cy.getCookie("x-auth-token").should("exist");

    cy.get("h1").contains("Products");
    cy.get("div").contains("Ibanez RG550");
    cy.get("div").contains("Jackson SL2");

    cy.visit('http://localhost:3000/profile-details');
    cy.wait(1500);
    cy.get("h1").contains('Test User');
    cy.get("h3").contains(currentName);
  });

  it("Should throw error on attempt with invalid username!", function () {
    cy.get("input[name=username]").type(" ");
    cy.get("input[name=email]").type("dummy@mail.bg");
    cy.get("input[name=first_name]").type("Test");
    cy.get("input[name=last_name]").type("User");
    cy.get("input[name=address]").type("dummy address");

    cy.get("input[name=password]").type(`123`);
    cy.get("input[name=re-password]").type(`123{enter}`);

    cy.wait(1000);

    cy.getCookies().should("have.length", 0);

    cy.get("div").contains("Please fill in all fields correctly.");
    cy.url().should("eq", "http://localhost:3000/register");
  });

  it("Should throw error on attempt with invalid full name!", function () {
    cy.get("input[name=username]").type(userID_generate());
    cy.get("input[name=email]").type("dummy@mail.bg");
    cy.get("input[name=first_name]").type(" ");
    cy.get("input[name=last_name]").type(" ");
    cy.get("input[name=address]").type("dummy address");

    cy.get("input[name=password]").type(`123`);
    cy.get("input[name=re-password]").type(`123{enter}`);

    cy.wait(1000);

    cy.getCookies().should("have.length", 0);

    cy.get("div").contains("Please fill in all fields correctly.");
    cy.url().should("eq", "http://localhost:3000/register");
  });

  it("Should throw error on attempt with invalid password!", function () {
    cy.get("input[name=username]").type(userID_generate());
    cy.get("input[name=email]").type("dummy@mail.bg");
    cy.get("input[name=first_name]").type("Test");
    cy.get("input[name=last_name]").type("User");
    cy.get("input[name=address]").type("dummy address");

    cy.get("input[name=password]").type(`1`);
    cy.get("input[name=re-password]").type(`1{enter}`);

    cy.wait(1000);

    cy.getCookies().should("have.length", 0);
    console.log(cy.getCookies())

    cy.get("div").contains("Username, full name, password and confirmation password should be more than 2 characters.");
    cy.url().should("eq", "http://localhost:3000/register");
  });

  it("Should throw error on attempt with different re-password!", function () {
    cy.get("input[name=username]").type(userID_generate());
    cy.get("input[name=email]").type("dummy@mail.bg");
    cy.get("input[name=first_name]").type("Test");
    cy.get("input[name=last_name]").type("User");
    cy.get("input[name=address]").type("dummy address");

    cy.get("input[name=password]").type(`12345`);
    cy.get("input[name=re-password]").type(`123{enter}`);

    cy.wait(300);

    cy.getCookies().should("have.length", 0);

    cy.get("div").contains("Passwords do not match.");
    cy.url().should("eq", "http://localhost:3000/register");
  });

  it("Should throw error on attempt with empty re-password!", function () {
    cy.get("input[name=username]").type(userID_generate());
    cy.get("input[name=email]").type("dummy@mail.bg");
    cy.get("input[name=first_name]").type("Test");
    cy.get("input[name=last_name]").type("User");
    cy.get("input[name=address]").type("dummy address");

    cy.get("input[name=password]").type(`123`);
    cy.get("input[name=re-password]").type(`{enter}`);

    cy.wait(1000);

    cy.getCookies().should("have.length", 0);

    cy.get("div").contains("Username, full name, password and confirmation password should be more than 2 characters.");
    cy.url().should("eq", "http://localhost:3000/register");
  });

  it("Should show footer correctly!", () => {
    cy.get("footer").should("be.visible");
    cy.get('p').contains('React-Store © 2020');
  });

  function userID_generate() {
    var text = "test-";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    for (var i = 0; i < 5; i++)
      text += possible.charAt(Math.floor(Math.random() * possible.length));

    text += "@abv.bg";
    return text;
  }
});
