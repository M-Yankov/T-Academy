'use strict';
// stateless
// require libs
let express = require('express'),
	bodyParser = require('body-parser'),
	mongoose = require('mongoose'),
	app = express(),
	connectionString = 'mongodb://localhost/logger';

// connect to mongo
mongoose.connect(connectionString);

// use bodyParser to return json response
app.use(bodyParser.json()); // middleware

// Each row (except './authentication-config') loads files from the directory.
// By default each of them loads a index.js in the given directory.
// Example: require('./models'); will call './models/index.js' and index.js will load other files in the directory.
// It's dynamic loading method. ->
require('./models');
require('./authentication-config');
require('./routers')(app);

let port = 3001;

// this is middleware function. It's embedded in node JS.
// if an error occurs, it will return status and message only.
app.use(function (err, req, res) {
   if (err) {
	   res.status(err.status || 500) // sometimes errors doesn't have a status (some exceptions), just return 500
	    .json({
			   message: err.message
		   });
   }
});

// start server at given port. () => arrow function from ES6
app.listen(port,
	() => console.log(`server running at localhost:${port}`));