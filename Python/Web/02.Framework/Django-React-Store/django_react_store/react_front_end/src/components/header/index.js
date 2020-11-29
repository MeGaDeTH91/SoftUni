import React, { useContext, useState } from "react";
import { Navbar, Nav, Form, FormControl, Button } from "react-bootstrap";
import getNavigationRoutes from "../../utils/routes";
import UserContext from "../../UserContext";
import styled from "styled-components";
import { useHistory } from "react-router-dom";

const Header = () => {
  const context = useContext(UserContext);
  const history = useHistory();

  const[search, setSearch] = useState('');

  const { user } = context;

  const links = getNavigationRoutes(user);

  const searchProducts = (e) => {
    if (search) {
      history.push(`/search/${search}`)
    } else {
      e.preventDefault();
      history.push('/');
    }
  }

  return (
    <>
      <Navbar bg="dark" variant="dark">
        <Navbar.Brand href="/" variant="outline-info">
          <LeftSpan>Django-React</LeftSpan><RightSpan>-store</RightSpan>
        </Navbar.Brand>
        <Form inline>
          <FormControl
            type="text"
            placeholder="Search Product..."
            className="mr-sm-2"
            name="search"
            onChange={(e) => setSearch(e.target.value)}
          />
          <Button type='submit' onClick={searchProducts} variant="outline-info">Search</Button>
        </Form>

        <Nav className="ml-auto">
          {links.map((x) => {
            return (
              <Nav.Link key={x.title} href={x.link}>
                {x.title}
              </Nav.Link>
            );
          })}
        </Nav>
      </Navbar>
    </>
  );
};

const LeftSpan = styled.span`
  color: #99E627;
  font-size: larger;
`;

const RightSpan = styled.span`
  color: #b817a1;
  font-size: larger;
`;

export default Header;
