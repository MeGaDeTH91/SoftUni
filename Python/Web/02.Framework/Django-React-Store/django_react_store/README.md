<img src="http://res.cloudinary.com/devpor11z/image/upload/v1605648152/g0c6szjunjalnhwjuriv.png" alt="react-store-logo" />
<h3><i>Title: </i><br><b>Django-React Store</b> - great choice for your sales.</h3>

### <i>Introduction: </i><br>
Django-React store is simple solution for publishing, managing and selling your products with user-friendly UI.
The main goal is to make each seller's products available globally. The online store can be accessed as guest,
registered user with standard privileges and there is also administrative area.

### <i>Technologies: </i><br>
The application consists two parts - back-end REST API, based on Django REST framework and front-end application,
based on the React library.

### <i>Launch settings: </i><br>
The REST API is mainly located in the 'main_app' folder, in the nested 'django_react_store ' the .env file should be put with this info, needed for PostgreSQL database access:<br>
SECRET_KEY={specifiy secret key}<br>
DATABASE_NAME={specify PostgreSQL database name}<br>
DATABASE_USER={specify PostgreSQL database user}<br>
DATABASE_PASSWORD={specify PostgreSQL database password}<br>
DATABASE_HOST={specify PostgreSQL database host}<br>
DATABASE_PORT={specify PostgreSQL database port}<br>
Then configure Python environment:<br> 
You can do this using PyCharm or similar software and just hit 'Run' button<br>or<br>
configure with command line and after that go in project root folder - ('python manage.py runserver').catch(check your internet connection :) ). This will start the REST API on
[http://127.0.0.1:8000/](http://127.0.0.1:8000/)
Next, in the 'react_front_end' folder, in separate command-line window run 'npm install' and 'npm start' command and
this will start the React app on  [http://localhost:3000/](http://localhost:3000/)
After that, it is up to you :)

### <i>Testing: </i><br>
Cypress is used for more complex End-to-End testing with > 85% functionality coverage. Can be started with<br>
'npm run test:e2e' from the 'react_front_end' directory.<br>

### <i>Hosting: </i><br>
The application is hosted on [Heroku](https://www.heroku.com) and can be found on the following link:<br>
[https://django-react-store-frontend.herokuapp.com/](https://django-react-store-frontend.herokuapp.com/) <br>
The REST API is hosted also on [Heroku](https://www.heroku.com) and can be found on the following link:<br>
[https://django-react-store-rest.herokuapp.com/](https://django-react-store-rest.herokuapp.com/)


### <i>Table of contents: </i><br>
1. Public part:<br> 
    * Guest users can access home page with all products listed with reviews section, page with listed categories so user can browse products by category, register, login pages and search by title option.<br>
2. Private part:<br>
    * Standard user – can access all public functionalities plus adding products to shopping cart, viewing and removing products from shopping cart, finalizing order and viewing  recent orders history, exploring and update of profile details. User is able to share product feedback by writing reviews and recent reviews can be seen in Profile.
    * Administrator – can access all functionalities, which standart user is able to, plus adding, editing and removing products, also adding and editing categories. Administrators can manage users and give administrative privileges or ban(deactivate) user accounts.
