const express = require('express')
const {
    guestAccess
} = require('../controllers/user-controller')

const {
    saveUser,
    verifyUser
} = require('../controllers/user-controller')


const router = express.Router()

router.get('/login', guestAccess, (req, res) => {
    res.render('loginPage')
})

router.post('/login', async (req, res) => {
    const {error} = await verifyUser(req, res)

    if (error) {
        return res.render('loginPage', {
            error: 'Username or password is not correct'
        })
    }
    res.redirect('/')
})

router.get('/register', guestAccess, (req, res) => {
    res.render('registerPage')
})

router.post('/register', async (req, res) => {
    const { password } = req.body

    if (!password || password.length < 8 || !password.match(/^[A-Za-z0-9]+$/)) {
        return res.render('registerPage', {
            error: 'Username or password is invalid.'
        })
    }

    const { error } = await saveUser(req, res)

    if (error) {
        return res.render('registerPage', {
            error: 'Username or password is invalid.'
        })
    }

    res.redirect('/')
})

module.exports = router