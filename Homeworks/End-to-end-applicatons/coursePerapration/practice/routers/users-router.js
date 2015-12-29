'use strict';

// express - it's like ASP.NET for C#
// passport - is authentication library helps with easy resolve auth headers.
let express = require('express'),
	router = express.Router(),
	usersController = require('./../controllers/users-controller');

// registration and login functions: see controllers.
router.post('/register', usersController.register)
	.post('/login', usersController.login);

// exports a function which accepts a instance of express() and sets to use on '/api/users' route above configuration.
module.exports = function (app) {
  app.use('/api/users', router);
};