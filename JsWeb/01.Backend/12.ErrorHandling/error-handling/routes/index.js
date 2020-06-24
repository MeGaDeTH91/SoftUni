const {
    Router
} = require('express')
const {
    getCubes
} = require('../controllers/cubes-controller')
const { getUserStatus } = require('../controllers/user-controller')

const router = Router()

router.get('/', getUserStatus, async (req, res) => {
    const cubes = await getCubes()

    res.render('index', {
        title: 'Cubes Home',
        loggedUser: req.loggedUser,
        cubes
    })
})

router.get('/logout', (req, res) => {
    res.clearCookie('aid')
  
    res.redirect('/')
  })

router.get('/about', getUserStatus, async (req, res) => {
    res.render('about', {
        title: 'About',
        loggedUser: req.loggedUser
    })
})

module.exports = router