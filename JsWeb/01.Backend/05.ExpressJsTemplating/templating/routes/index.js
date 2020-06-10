const Cube = require('../models/cube.js')
const {
    Router
} = require('express')
const {
    getAllCubes,
    getCube,
    getSearchedCubes
} = require('../controllers/cubes-controller')

const router = Router()

router.get('/', (req, res) => {
    getAllCubes((cubes) => {
        res.render('index', {
            title: 'Cubes Home',
            cubes
        })
    })
})

router.post('/search', (req, res) => {
    const searchParams = {
        search,
        from,
        to
    } = req.body

    if (!searchParams.search && !searchParams.from && !searchParams.to) {
        res.redirect(301, '/')
        return
    }

    getSearchedCubes(searchParams, (cubes) => {
        res.render('index', {
            title: 'Cubes Home',
            cubes
        })
    })
})

router.get('/about', (req, res) => {
    res.render('about', {
        title: 'About'
    })
})

router.get('/create', (req, res) => {
    res.render('create', {
        title: 'Create Cube'
    })
})

router.post('/create', (req, res) => {
    const {
        name,
        description,
        imageUrl,
        difficultyLevel
    } = req.body

    const cube = new Cube(name, description, imageUrl, parseInt(difficultyLevel))

    cube.save(() => {
        res.redirect('/')
    })
})

router.get('/details/:id', (req, res) => {
    getCube(req.params.id, (cube) => {
        res.render('details', {
            title: 'Cube Details',
            ...cube
        })
    })
})

router.get('*', (req, res) => {
    res.render('404', {
        title: 'Not Found'
    })
})

module.exports = router