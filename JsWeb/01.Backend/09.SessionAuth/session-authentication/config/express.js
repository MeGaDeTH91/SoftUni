const express = require('express');
const handlebars = require('express-handlebars');
const bodyParser = require('body-parser');
const cookieParser = require('cookie-parser')

module.exports = (app) => {

    app.engine('.hbs', handlebars({
        extname: '.hbs',
        defaultLayout: 'main',
        layoutsDir: './views/layouts',
        partialsDir: './views/partials',
        helpers: {
            "select": function(selected, options) { return options.fn(this).replace(new RegExp(' value=\"' + selected + '\"'),
            '$& selected="selected"') }
        }
    }));
    app.set('view engine', '.hbs');

    app.use(cookieParser())
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