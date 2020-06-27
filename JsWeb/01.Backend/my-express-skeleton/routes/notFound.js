const router = require('express').Router();
const handler = require('../handlers/notFound');
const authenticate = require('../utils/authenticate');

router.get('/', authenticate(true), handler.get.notFound)

module.exports = router;