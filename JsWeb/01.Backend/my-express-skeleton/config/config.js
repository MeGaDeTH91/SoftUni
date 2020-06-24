const env = process.env.NODE_ENV || 'development';

const dbConfig = {
    development: {
        port: process.env.PORT || 8888,
        dbURL: process.env.DB_URL,
        cookieKey: process.env.COOKIE_KEY,
        privateKey: process.env.PRIVATE_KEY
    },
    production: {}
}

module.exports = dbConfig[env]