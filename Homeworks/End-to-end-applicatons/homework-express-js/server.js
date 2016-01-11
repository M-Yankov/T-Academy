'use strict';

let express = require('express'),
	mongoose = require('mongoose'),
	bodyParser = require('body-parser'),
	cookieParser = require('cookie-parser'),
	jade = require('jade'),
	app = express(),
	port = process.env.PORT || 3300,
	connectionString = 'mongodb://localhost/nine-gag';

mongoose.connect(connectionString);

app.use(express.static(__dirname + '/public'));
app.set('views', __dirname + '/views');
app.set('view engine', 'jade');

require('./models/user-model');
require('./models/image-model');

app.use(cookieParser());

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
	extended: true
}));

require('./config/passport-config');
require('./routes/auth-route')(app);
require('./routes/image-route')(app);
require('./routes/home-route')(app);

app.listen(port, () => console.log(`server is running on http://localhost:${port}/`));

// Opens project in default browser.
const exec = require('child_process').exec;
exec(`explorer.exe http://localhost:${port}/home`);