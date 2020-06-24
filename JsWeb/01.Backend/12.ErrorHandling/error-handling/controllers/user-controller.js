const env = process.env.NODE_ENV || 'development'

const bcrypt = require('bcrypt')
const jwt = require('jsonwebtoken')
const User = require('../models/user')
const config = require('../config/config')[env]

const generateToken = data => {
    const token = jwt.sign(data, config.privateKey)

    return token
}

const saveUser = async (req, res) => {
    const {
        username,
        password,
        repeatPassword
    } = req.body

    if (password !== repeatPassword) {
        return {
            error: true
        }
    }

    const salt = await bcrypt.genSalt(10)
    const hashedPass = await bcrypt.hash(password, salt)

    try {
        const user = new User({
            username,
            password: hashedPass
        })

        const userObject = await user.save()

        const token = generateToken({
            userID: userObject._id,
            username: userObject.username
        })

        res.cookie('aid', token)

        return token
    } catch (err) {
        return {
            error: true,
            message: err
        }
    }
}

const verifyUser = async (req, res) => {
    const {
        username,
        password
    } = req.body

    try {
        const user = await User.findOne({
            username
        })

        const status = await bcrypt.compare(password, user.password)

        if (status) {
            const token = generateToken({
                userId: user._id,
                username: user.username
            })

            res.cookie('aid', token)
        }

        return {
            error: !status,
            message: status || 'Wrong password.'
        }
    } catch (err) {
        return {
            error: true,
            message: 'There is no such user'
          }
    }
}

const verifyCreator = async (creatorIdObj, req, res) => {
    const creatorId = String(creatorIdObj)
    const token = req.cookies['aid']
    if (!token) {
        return false
    }

    const decoded = jwt.verify(token, config.privateKey)
    if (!decoded) {
        return false
    }

    return decoded.userId === creatorId
}

const guestAccess = (req, res, next) => {
    const token = req.cookies['aid']

    if (token) {
        return res.redirect('/')
    }
    next()
}

const authenticateUser = (req, res, next) => {
    const token = req.cookies['aid']

    if (!token) {
        return res.redirect('/')
    }

    try {
        jwt.verify(token, config.privateKey)
        next()
    } catch (e) {
        return res.redirect('/')
    }
}

const getUserStatus = (req, res, next) => {
    const token = req.cookies['aid']

    if (!token) {
        req.loggedUser = false
    }

    try {
        jwt.verify(token, config.privateKey)
        req.loggedUser = true
    } catch (e) {
        req.loggedUser = false
    }
    next()
}

module.exports = {
    saveUser,
    verifyUser,
    authenticateUser,
    guestAccess,
    getUserStatus,
    verifyCreator
}