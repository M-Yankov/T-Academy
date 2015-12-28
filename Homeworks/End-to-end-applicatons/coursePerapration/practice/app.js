'use strict';
// stateless

let express = require('express'),
	bodyParser = require('body-parser'),
	mongoose = require('mongoose'),
	app = express();

let connectionString = 'mongodb://localhost/logger';
mongoose.connect(connectionString);


app.use(bodyParser.json()); // middleware

require('./models');
require('./authentication-config');
require('./routers')(app);

let router = express.Router();

app.use('/api/logs', router);

// middleware
/* TODO app.use(function (req, res, next) {
	console.log(res.body);
	next();
});*/

let port = 3001;

app.use(function (err, req, res, next) {
   if (err) {
	   res.status(err.status || 500) // !!!!!!!
	    .json({
			   message: err.message
		   });
   }
});

app.listen(port,
	() => console.log(`server running at localhost:${port}`));