var express = require('express');
var router = express.Router();
var timeStamp = require('../timeStamp');

/* GET users listing. */
router.get('/', function(req, res, next) {
  timeStamp(req);
  res.send('respond with a resource');
});

router.get('/manifest', function(req, res, next) {
  res.send('access to drone manifest...');
});

module.exports = router;
