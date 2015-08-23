/* 
 Create a function that:
 *   **Takes** an array of animals
 *   Each animal has propeties `name`, `species` and `legsCount`
 *   **finds** and **prints** the total number of legs to the console in the format:
 *   "Total number of legs: TOTAL_NUMBER_OF_LEGS"
 *   **Use underscore.js for all operations**
 */

function solve() {
    "use strict";
    return function (animals) {
        var _ =require('../node_modules/underscore/underscore.js');
        var sum = _.reduce(animals, function (callback, current) {
             return callback + current.legsCount;
        }, 0);

        console.log('Total number of legs: ' + sum);
    };
}

module.exports = solve;
