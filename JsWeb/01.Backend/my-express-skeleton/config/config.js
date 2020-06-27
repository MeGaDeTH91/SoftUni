const env = process.env.NODE_ENV || 'development';

const dbConfig = {
    development: {
        port: process.env.PORT || 4000,
        dbURL: process.env.DB_URL,
        cookie: process.env.COOKIE_KEY,
        secret: process.env.PRIVATE_KEY
    },
    production: {}
}

module.exports = dbConfig[env]