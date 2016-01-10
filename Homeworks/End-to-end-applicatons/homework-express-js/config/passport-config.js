'use strict';

let passport =require('passport'),
	CookieStrategy = require('./passport-cookie'),
	mongoose = require('mongoose'),
	User = mongoose.model('User');

passport.use(new CookieStrategy(function (token, done) {
    User.findOne({token: token})
		.exec(function (err, user) {
		    if (err) {
		    	return done(err, null);
		    }

			done(null, user);
		});
}));