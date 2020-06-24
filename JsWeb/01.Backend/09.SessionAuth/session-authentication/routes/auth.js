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
    await verifyUser(req, res)

    res.redirect('/')
})

router.get('/register', guestAccess, (req, res) => {
    res.render('registerPage')
})

router.post('/register', async (req, res) => {
    saveUser(req, res)

    res.redirect('/')
})

module.exports = router