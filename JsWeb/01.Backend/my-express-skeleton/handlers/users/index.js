
module.exports = {
    get: {
        login(req, res, next) {
            res.render('users/login.hbs')
        },
        register(req, res, next) {
            res.render('users/register.hbs')
        }
    },
    post: {
        login(req, res, next) {
            console.log(req.body)
        },
        register(req, res, next) {
            console.log(req.body)
        }
    }
}