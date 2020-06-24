const router = require('express').Router();
const handler = require('../handlers/home');

router.get('/', handler.get.home)

module.exports = router;