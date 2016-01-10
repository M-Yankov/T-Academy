'use strict';

let mongoose = require('mongoose'),
	User = mongoose.model('User');

function generateRandomToken() {
	let symbols = 'ABCDEF1234567890';
	let token = '';
	for (let i = 0, tokLen = 20; i < tokLen; i += 1) {
		token += symbols[getRandomArbitrary(0, symbols.length - 1)];
	}

	return token;
}

function getRandomArbitrary(min, max) {
	var a = Math.random() * (max - min) + min;
	return Math.round(a);
}

module.exports = {
	register: function (req, res) {

		if (!req.body || !req.body.username && !req.body.password) {
			res.render('error', {error: 'Provide username and password'});
			return;
		}

		let dbUser = new User(req.body);
		dbUser.save(function (err, user) {
			if (err) {
				res.render('error', {error: 'Cannot register, try again later'});
				return;
			}

			res.render('redirect');
		});
	},
	login: function (req, res) {
		if (!req.body || !req.body.username && !req.body.password) {
			res.render('error', {error: 'Provide username and password'});
			return;
		}

		User.findOne({username: req.body.username, password: req.body.password})
			.exec(function (err, user) {
				if (err || !user) {
					return res.render('error', {error: 'Username or password mismatch'});
				}

				if (!user.token) {
					user.token = generateRandomToken();
					user.save();
				}

				req.app.locals.user = user;
				res.cookie('Authorization', user.token);
				res.redirect('/images');
			});

	},
	logout: function (req, res) {
		req.app.locals.user = undefined;
		req.logout();
		res.clearCookie('Authorization');
		res.redirect('/images');
	},
	registerForm: function (req, res) {
		res.render('register');
	}
};