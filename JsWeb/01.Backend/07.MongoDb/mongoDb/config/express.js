const express = require('express');
const handlebars = require('express-handlebars');
const bodyParser = require('body-parser');

module.exports = (app) => {

    app.engine('.hbs', handlebars({
        extname: '.hbs',
        defaultLayout: 'main',
        layoutsDir: './views/layouts',
        partialsDir: './views/partials'
    }));
    app.set('view engine', '.hbs');

    app.use(bodyParser.json()); // to support JSON-encoded bodies
    app.use(bodyParser.urlencoded({ // to support URL-encoded bodies
        extended: true
    }));

    app.use(express.json()); // to support JSON-encoded bodies
    app.use(express.urlencoded({ // to support URL-encoded bodies
        extended: true
    }));

    app.use('/static', express.static('static'))

};