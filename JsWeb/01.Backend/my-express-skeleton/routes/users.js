const router = require('express').Router()
const handler = require('../handlers/users');

router.get('/login', handler.get.login);
router.get('/register', handler.get.register);

router.post('/login', handler.post.login);
router.post('/register', handler.post.register);

module.exports = router;