const Cube = require('../models/cube.js')
const Accessory = require('../models/accessory.js')
const {
    Router
} = require('express')
const {
    getCubes,
    getCube,
    searchCubes,
    updateCube,
    getCubeWithAccessories
} = require('../controllers/cubes-controller')

const {
    getAccessories,
    attachedAccessories
} = require('../controllers/accessories-controller')

const router = Router()

router.get('/', async (req, res) => {
    const cubes = await getCubes()

    res.render('index', {
        title: 'Cubes Home',
        cubes
    })
})

router.post('/search', async (req, res) => {
    const searchParams = {
        search,
        from,
        to
    } = req.body

    if (!searchParams.search && !searchParams.from && !searchParams.to) {
        res.redirect(301, '/')
        return
    }

    const cubes = await searchCubes(searchParams)

    res.render('index', {
        title: 'Cubes Home',
        cubes
    })
})

router.get('/about', async (req, res) => {
    res.render('about', {
        title: 'About'
    })
})

router.get('/create/cube', (req, res) => {
    res.render('./cubes/create', {
        title: 'Create Cube'
    })
})

router.post('/create/cube', (req, res) => {
    const {
        name,
        description,
        imageUrl,
        difficultyLevel
    } = req.body

    const cube = new Cube({
        name,
        description,
        imageUrl,
        difficulty: parseInt(difficultyLevel)
    })

    cube.save((err) => {
        if (err) {
            console.error(err)
            res.redirect('/create/cube')
        } else {
            res.redirect('/')
        }
    })
})

router.get('/details/:id', async (req, res) => {
    const cube = await getCubeWithAccessories(req.params.id)

    res.render('./cubes/details', {
        title: 'Cube Details',
        ...cube
    })
})

router.get('/create/accessory', (req, res) => {
    res.render('./accessories/create', {
        title: 'Create Accessory'
    })
})

router.post('/create/accessory', async (req, res) => {
    const {
        name,
        description,
        imageUrl,
    } = req.body

    const accessory = new Accessory({
        name,
        description,
        imageUrl
    })

    cube.save((err) => {
        if (err) {
            console.error(err)
            res.redirect('/create/accessory')
        } else {
            res.redirect('/')
        }
    })
})

router.get('/attach/accessory/:id', async (req, res) => {
    const {
        id: cubeId
    } = req.params

    try {
        const cube = await attachedAccessories(cubeId)
    
        res.render('./accessories/attach', {
          title: 'Attach accessory',
          ...cube
        });
      } catch (err) {
        res.redirect(`/details/${cubeId}`)
      }
})

router.post('/attach/accessory/:id', async (req, res) => {
    const {
        accessory: accessoryId
    } = req.body
    const { id: cubeId} = req.params

    await updateCube(cubeId, accessoryId)

    res.redirect(`/details/${req.params.id}`)
})

router.get('*', async (req, res) => {
    res.render('404', {
        title: 'Not Found'
    })
})

module.exports = router