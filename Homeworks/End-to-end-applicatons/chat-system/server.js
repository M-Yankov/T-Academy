'use strict';

// Use postman for evaluation of homework;
var express = require('express'),
	bodyParser = require('body-parser'),
	mongoose = require('mongoose'),
	app = express(),
	connectionString = 'mongodb://localhost/chat-system',
	port = 1222;

mongoose.connect(connectionString);

app.use(bodyParser.json());

require('./models/user-schema');
require('./models/message-schema');

var data = require('./chat-db');

require('./routers/user-router')(app, data);

app.listen(port,
	() => console.log(`server running at localhost:${port}`));