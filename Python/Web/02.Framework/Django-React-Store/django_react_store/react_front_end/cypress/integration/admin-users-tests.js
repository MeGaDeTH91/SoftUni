describe("Admin user managemenet pages", () => {
  beforeEach(() => {
    cy.visit("http://localhost:3000/login");

    cy.get("input[name=username]").type("marto");
    cy.get("input[name=password]").type(`123{enter}`);

    cy.wait(5500);

    cy.getCookie("x-auth-token").should("exist");

    cy.visit("http://localhost:3000/users");
    cy.wait(500);
  });

  it("Should show nav correctly!", () => {
    cy.get("nav").should("be.visible");
  });

  it("Should show users management page title!", () => {
    cy.get("h1").contains("Users management");
    cy.get("h4").contains("Manage user roles and bans");
  });

  it("Should list all users successfully!", () => {
    cy.get("tr").contains("marto@abv.bg");
    cy.get("tr").contains("marto1@abv.bg");
    cy.get("tr").contains("dummy@abv.bg");
  });

  it("Should change user status successfully!", () => {
    cy.get("td")
      .contains("dummy@abv.bg")
      .parent()
      .find('input[type="checkbox"]')
      .first()
      .should("be.disabled")
      .should("have.attr", "checked");
    cy.get("td").contains("dummy@abv.bg").parent().contains("Ban").click();
    cy.wait(300);
    cy.get("div").contains("User status changed successfully!");

    cy.wait(4000);

    cy.get("td")
      .contains("dummy@abv.bg")
      .parent()
      .find('input[type="checkbox"]')
      .first()
      .should("be.disabled")
      .should("not.have.attr", "checked");
    cy.get("td").contains("dummy@abv.bg").parent().contains("Unban").click();
    cy.wait(300);
    cy.get("div").contains("User status changed successfully!");
    cy.wait(4000);

    cy.get("td")
      .contains("dummy@abv.bg")
      .parent()
      .find('input[type="checkbox"]')
      .first()
      .should("be.disabled")
      .should("have.attr", "checked");
  });

  it("Should change user privileges successfully!", () => {
    cy.get("td")
      .contains("dummy@abv.bg")
      .parent()
      .find('input[type="checkbox"]')
      .eq(1)
      .should("be.disabled")
      .should("not.have.attr", "checked");
    cy.get("td")
      .contains("dummy@abv.bg")
      .parent()
      .contains("Make admin")
      .click();
    cy.wait(300);
    cy.get("div").contains("User role changed successfully!");

    cy.wait(4000);

    cy.get("td")
      .contains("dummy@abv.bg")
      .parent()
      .find('input[type="checkbox"]')
      .eq(1)
      .should("be.disabled")
      .should("have.attr", "checked");
    cy.get("td").contains("dummy@abv.bg").parent().contains("Revoke").click();
    cy.wait(300);
    cy.get("div").contains("User role changed successfully!");
    cy.wait(4000);

    cy.get("td")
      .contains("dummy@abv.bg")
      .parent()
      .find('input[type="checkbox"]')
      .eq(1)
      .should("be.disabled")
      .should("not.have.attr", "checked");
  });

  it("Should show footer correctly!", () => {
    cy.get("footer").should("be.visible");
    cy.get("p").contains("Django-React-Store © 2020");
  });
});
