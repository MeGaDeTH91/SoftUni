require('dotenv').config()
require('./config/database')

const config = require('./config/config');
const app = require('express')();
const appRunningText = `Listening on port ${config.port}! Now its up to you...`;

require('./config/express')(app);
require('./config/routes')(app);

app.get('*', (req, res) => {
    res.render('404', {
        title: 'Not Found'
    })
})

app.listen(config.port, console.log(appRunningText));