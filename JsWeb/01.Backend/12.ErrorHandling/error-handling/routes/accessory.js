const express = require('express')
const Accessory = require('../models/accessory.js')
const {
    attachedAccessories
} = require('../controllers/accessories-controller')

const {
    updateCube
} = require('../controllers/cubes-controller')
const {
    authenticateUser,
    getUserStatus
} = require('../controllers/user-controller')

const router = express.Router()

router.get('/create/accessory', authenticateUser, getUserStatus, (req, res) => {
    res.render('./accessories/create', {
        title: 'Create Accessory',
        loggedUser: req.loggedUser,
    })
})

router.post('/create/accessory', authenticateUser, getUserStatus, async (req, res) => {
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

    try {
        await accessory.save()
        return res.redirect('/')
    } catch (err) {
        
        return res.render('./accessories/create', {
            title: 'Create Accessory',
            loggedUser: req.loggedUser,
            error: 'Accessory details are not valid'
        })
    }
})

router.get('/attach/accessory/:id', authenticateUser, getUserStatus, async (req, res) => {
    const {
        id: cubeId
    } = req.params

    try {
        const cube = await attachedAccessories(cubeId)

        res.render('./accessories/attach', {
            title: 'Attach accessory',
            loggedUser: req.loggedUser,
            ...cube
        });
    } catch (err) {
        res.redirect(`/details/${cubeId}`)
    }
})

router.post('/attach/accessory/:id', authenticateUser, getUserStatus, async (req, res) => {
    const {
        accessory: accessoryId
    } = req.body
    const {
        id: cubeId
    } = req.params

    await updateCube(cubeId, accessoryId)

    res.redirect(`/details/${req.params.id}`)
})

module.exports = router