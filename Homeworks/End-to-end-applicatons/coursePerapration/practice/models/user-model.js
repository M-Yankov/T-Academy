'use strict';

// mongoose - for operation with mongodb.
let mongoose = require('mongoose');

// define a schema for the object. columns, requirements, types etc.
let schema = new mongoose.Schema({
	username: {
		type: String,
		required: true,
		index: { unique: true }

	},
	nameToLower: {
		type: String,
		required: true,
		index: { unique: true }

	},
	password: {
		type: String,
		required: true
	},
	token: String
});

// creating a new model with given schema.
mongoose.model('User', schema);