'use strict';

let express = require('express'),
	router = new express.Router(),
	userController = require('../controllers/users-controller');

router.get('/register', userController.registerForm);
router.post('/login', userController.login);
router.post('/register', userController.register);
router.post('/logout', userController.logout);

module.exports = function (app) {
    app.use('/auth', router);
};