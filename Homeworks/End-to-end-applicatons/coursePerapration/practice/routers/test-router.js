'use strict';
let express = require('express');

let router = express.Router();

router
    .get('/', function (req, res) {
        res.json({
            result: 'Works!'
        });
    });

module.exports = function (app) {
    app.use('/api/tests', router);
};