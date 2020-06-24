require('dotenv').config()
const env = process.env.NODE_ENV || 'development';

const config = require('./config/config')[env];
const app = require('express')();
const indexRouter = require('./routes')
const authRouter = require('./routes/auth')
const cubeRouter = require('./routes/cube')
const accessoryRouter = require('./routes/accessory')
require('./config/mongoose')

require('./config/express')(app);

app.use('/', authRouter)
app.use('/', cubeRouter)
app.use('/', accessoryRouter)
app.use('/', indexRouter)

app.get('*', (req, res) => {
    res.render('404', {
        title: 'Not Found'
    })
})

app.listen(config.port, console.log(`Listening on port ${config.port}! Now its up to you...`));