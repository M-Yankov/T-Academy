'use strict';

let express= require('express'),
	router = new express.Router();

router.get('/', function (req, res) {
	res.render('home');
});

module.exports = function(app) {
	app.use('/home', router);
};