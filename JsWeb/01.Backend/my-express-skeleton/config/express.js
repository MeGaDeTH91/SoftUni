const express = require('express');
const handlebars = require('express-handlebars');
const cookieParser = require('cookie-parser');

module.exports = (app) => {

    app.engine('.hbs', handlebars({
        extname: '.hbs',
        defaultLayout: 'base-layout',
        layoutsDir: './views/layouts',
        partialsDir: './views/partials',
        helpers: {
            "select": function(selected, options) { return options.fn(this).replace(new RegExp(' value=\"' + selected + '\"'),
            '$& selected="selected"') }
        }
    }));
    app.set('view engine', '.hbs');

    app.use(express.static('public'));
    app.use(cookieParser());
    app.use(express.json());
    app.use(express.urlencoded({ extended: true }));
};