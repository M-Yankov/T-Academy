'use strict';

let mongoose = require('mongoose');

let userSchema = new mongoose.Schema({
	username: {
		type: String,
		required: true,
		index: {
			unique: true
		}
	},

	password: {
		type: String,
		required: true
	},

	token: {
		type: String
	},

	comments: {
		type: [mongoose.Types.Mixed]
	},

	images: {
		type: [mongoose.Types.Mixed]
	}
});

mongoose.model('User', userSchema);