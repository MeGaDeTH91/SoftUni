require('dotenv').config()
require('./config/database')

const config = require('./config/config');
const app = require('express')();
const appRunningText = `Listening on port ${config.port}! Now its up to you...`;

require('./config/express')(app);
require('./config/routes')(app);

app.listen(config.port, console.log(appRunningText));