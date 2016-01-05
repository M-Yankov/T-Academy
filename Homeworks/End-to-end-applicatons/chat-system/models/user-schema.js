'use strict';

// mongoose - for operation with mongodb.
var mongoose = require('mongoose');

// define a schema for the object. columns, requirements, types etc.
var schema = new mongoose.Schema({
	username: {
		type: String,
		required: true,
		index: { unique: true }
	},
	password: {
		type: String,
		required: true
	}
});

// creating a new model with given schema.
mongoose.model('User', schema);