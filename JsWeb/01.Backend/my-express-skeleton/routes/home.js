const router = require('express').Router();
const handler = require('../handlers/home');
const authenticate = require('../utils/authenticate');

router.get('/', authenticate(true), handler.get.home)

module.exports = router;