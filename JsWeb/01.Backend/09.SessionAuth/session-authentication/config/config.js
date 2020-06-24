module.exports = {
    development: {
        port: process.env.PORT || 3000,
        privateKey: process.env.PRIVATE_KEY,
        dbURL: process.env.DB_URL
    },
    production: {}
};