describe("Profile page", () => {
  beforeEach(() => {
    cy.visit("http://localhost:3000/login");

    cy.get("input[name=username]").type("marto123");
    cy.get("input[name=password]").type(`123{enter}`);

    cy.wait(5500);

    cy.getCookie("x-auth-token").should("exist");

    cy.visit('http://localhost:3000/profile-details');
    cy.wait(500);
  });

  it("Should show nav correctly!", () => {
    cy.get("nav").should("be.visible");
  });

  it("Should show all user information correctly!", () => {
    cy.get("h1").contains('Martin Taskov2');
    cy.get("h3").contains('test@abv.bg');
    cy.get("h3").contains('Some address');
  });

  it("Should show buttons correctly!", () => {
    cy.get("button").contains('Update info');
    cy.get("button").contains('My orders');
  });

  it("Should show user reviews correctly!", () => {
    cy.contains('I love this guitar!').should('exist');
    cy.contains('One of the greatest axes of Jackson recently.').should('exist');
    cy.contains('Wow, amazed to see this in local shop. Great deal!').should('exist');
  });

  it("Should update user information correctly!", () => {
    cy.get("button").contains('Update info').click();
    cy.wait(300);

    const first_name = 'Martin';
    const last_name = 'Taskov2';
    const address = 'Some address';

    const tempFullName = 'Martin Taskov155';
    const tempLastName = 'Taskov155';
    const tempAddress = 'no address';

    cy.get('input[name=first_name]').should('have.value', first_name);
    cy.get('input[name=last_name]').should('have.value', last_name);
    cy.get('input[name=address]').should('have.value', address);

    cy.get('input[name=last_name]').clear().type(tempLastName);
    cy.get('input[name=address]').clear().type(tempAddress);
    cy.get("button").contains('Update info').click();
    cy.wait(300);

    cy.get("h1").contains(tempFullName);
    cy.get("h3").contains(tempAddress);
    cy.get("button").contains('Update info').click();
    cy.get("div").contains("User information updated successfully!");
    cy.wait(300);

    cy.get('input[name=last_name]').clear().type(last_name);
    cy.get('input[name=address]').clear().type(address);
    cy.get("button").contains('Update info').click();
  });

  it("Should throw error on update user information with invalid full name!", () => {
    cy.get("button").contains('Update info').click();
    cy.wait(300);

    const first_name = 'Martin';
    const last_name = 'Taskov2';
    const address = 'Some address';

    const tempLastName = ' ';
    const tempAddress = 'no address';

    cy.get('input[name=first_name]').should('have.value', first_name);
    cy.get('input[name=last_name]').should('have.value', last_name);
    cy.get('input[name=address]').should('have.value', address);

    cy.get('input[name=last_name]').clear().type(tempLastName);
    cy.get('input[name=address]').clear().type(tempAddress);
    cy.get("button").contains('Update info').click();
    
    cy.get("div").contains("Error occured: Please provide valid data.");
    cy.url().should("eq", "http://localhost:3000/profile-details");
  });

  it("Should show user orders correctly!", () => {
    cy.get("button").contains('My orders').click();

    cy.get("h4").contains('Orders history');
    cy.get("div").contains('8');
    cy.get("div").contains('7');
    cy.get("div").contains('6');
  });

  it("Should leave review successfully!", () => {
    cy.visit('http://localhost:3000');
    cy.wait(2000);
    cy.get("div").contains("Ibanez RG550").click();
    cy.wait(600);
    cy.get('button').contains('Add to cart').should('exist');
    cy.contains('Product reviews').should('not.exist');

    cy.get("button").contains('Show reviews section').click();
    cy.wait(300);

    cy.get("h4").contains('Product reviews');

    const review = reviewID_generate();

    cy.contains(review).should('not.exist');
    cy.get('textarea[name=review]').clear().type(review);

    cy.contains('Post review').click();
    cy.wait(4500);

    cy.contains('Product reviews').should('not.exist');
    cy.get("button").contains('Show reviews section').click();
    cy.wait(300);
    cy.get("h4").contains('Product reviews');

    cy.contains(review).should('exist');
  });

  it("Should show footer correctly!", () => {
    cy.get("footer").should("be.visible");
    cy.get('p').contains('Django-React-Store © 2020');
  });

  function reviewID_generate() {
    var text = "test-";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    for (var i = 0; i < 7; i++)
      text += possible.charAt(Math.floor(Math.random() * possible.length));

    text += "_review";
    return text;
  }
});
