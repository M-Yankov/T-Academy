'use strict';

// mongoose - for operation with mongodb.
let mongoose = require('mongoose');

// define a schema for the object. columns, requirements, types etc.
let schema = new mongoose.Schema({
	text: {
		type: String,
		required: true
	},
	date: {
		type: Date,
		required: true
	},
	type: {
		type: mongoose.Schema.Types.Mixed,
		required: true
	},
	user: {
		type: mongoose.Schema.Types.Mixed,
		required: true
	}
});

// creating a new model with given schema.
mongoose.model('Log', schema);