const env = process.env.NODE_ENV || 'development'
const config = require('../config/config')[env]
const jwt = require('jsonwebtoken')

const express = require('express')
const Cube = require('../models/cube.js')
const {
    searchCubes,
    getCubeWithAccessories,
    getCube
} = require('../controllers/cubes-controller')
const {
    authenticateUser,
    getUserStatus,
    verifyCreator
} = require('../controllers/user-controller')

const router = express.Router()

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

router.get('/create/cube', authenticateUser, getUserStatus, (req, res) => {
    res.render('./cubes/create', {
        title: 'Create Cube',
        loggedUser: req.loggedUser,
    })
})

router.post('/create/cube', authenticateUser, (req, res) => {
    const {
        name,
        description,
        imageUrl,
        difficultyLevel
    } = req.body

    const token = req.cookies['aid']
    const decodedObject = jwt.verify(token, config.privateKey)

    const cube = new Cube({
        name,
        description,
        imageUrl,
        difficulty: parseInt(difficultyLevel),
        creatorId: decodedObject.userId
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

router.get('/details/:id', getUserStatus, async (req, res) => {
    const cube = await getCubeWithAccessories(req.params.id)
    const creatorAuth = await verifyCreator(cube.creatorId, req, res)

    console.log(creatorAuth, 'creatorAuth')
    res.render('./cubes/details', {
        title: 'Cube Details',
        loggedUser: req.loggedUser,
        ...cube,
        creatorAuth
    })
})

router.get('/edit/:id', authenticateUser, getUserStatus, async (req, res) => {
    const cube = await getCube(req.params.id)

    res.render('./cubes/edit', {
        title: 'Edit Cube',
        loggedUser: req.loggedUser,
        ...cube
    })
})

router.post('/edit/:id', authenticateUser, async (req, res) => {
    const cubeId = req.params.id
    const cube = Cube(await getCube(cubeId))

    const {
        name,
        description,
        imageUrl,
        difficultyLevel
    } = req.body

    console.log(cube)
    cube.name = name
    cube.description = description
    cube.imageUrl = imageUrl
    cube.difficultyLevel = difficultyLevel

    cube.save((err) => {
        if (err) {
            console.error(err)
            res.redirect(`/edit/${cubeId}`)
        } else {
            res.redirect('/')
        }
    })
})

router.get('/delete/:id', authenticateUser, getUserStatus, async (req, res) => {
    const cube = await getCube(req.params.id)

    res.render('./cubes/delete', {
        title: 'Delete Cube',
        loggedUser: req.loggedUser,
        ...cube
    })
})

module.exports = router