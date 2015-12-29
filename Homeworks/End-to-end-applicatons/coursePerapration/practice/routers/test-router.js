'use strict';

// this router was made for testing purposes, you can create one like that for practice. It should work without any other configuration.
let express = require('express'),
    router = express.Router();

router
    .get('/', function (req, res) {
        res.json({
            result: 'Works!'
        });
    });

module.exports = function (app) {
    app.use('/api/tests', router);
};