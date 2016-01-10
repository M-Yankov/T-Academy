'use strict';

let mongoose = require('mongoose');

let imageSchema = new mongoose.Schema({
	path: {
		type: String
	},

	title: {
		type: String
	},

	user: {
		type: Object
	},

	comments: {
		type: []
	}
});

mongoose.model('Image', imageSchema);