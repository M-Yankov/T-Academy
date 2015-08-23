/* 
 Create a function that:
 *   **Takes** an array of animals
 *   Each animal has propeties `name`, `species` and `legsCount`
 *   **groups** the animals by `species`
 *   the groups are sorted by `species` descending
 *   **sorts** them ascending by `legsCount`
 *	if two animals have the same number of legs sort them by name
 *   **prints** them to the console in the format:

 ```
 ----------- (number of dashes is equal to the length of the GROUP_1_NAME + 1)
 GROUP_1_NAME:
 ----------- (number of dashes is equal to the length of the GROUP_1_NAME + 1)
 NAME has LEGS_COUNT legs //for the first animal in group 1
 NAME has LEGS_COUNT legs //for the second animal in group 1
 ----------- (number of dashes is equal to the length of the GROUP_2_NAME + 1)
 GROUP_2_NAME:
 ----------- (number of dashes is equal to the length of the GROUP_2_NAME + 1)
 NAME has LEGS_COUNT legs //for the first animal in the group 2
 NAME has LEGS_COUNT legs //for the second animal in the group 2
 NAME has LEGS_COUNT legs //for the third animal in the group 2
 NAME has LEGS_COUNT legs //for the fourth animal in the group 2
 ```
 *   **Use underscore.js for all operations**
 */

function solve() {
    "use strict";
    return function (animals) {
        var _ = require('../node_modules/underscore/underscore.js'),
            dashes = '';

        var grouped = _.chain(animals)
            .sortBy('name')
            .sortBy('legsCount')
            .groupBy('species')
            .value();

        var keys = _.chain(grouped).keys().sortBy().reverse().value();

        _.each(keys, function (key) {
            _.map(key, function () {
                dashes += '-';
            });
            console.log(dashes + '-');
            console.log(key + ':');
            console.log(dashes + '-');
            dashes = '';

            _.each(grouped[key], function (animal) {
                console.log(animal.name + ' has ' + animal.legsCount + ' legs');
            });
        });
    };
}

/*var animals = [{
    name: 'jack',
    species: 'aaaaaa',
    legsCount: 9
}, {
    name: 'back',
    species: 'zblabla',
    legsCount: 4
}, {
    name: 'boby',
    species: 'beta',
    legsCount: 4
}, {
    name: 'jack',
    species: 'beta',
    legsCount: 4
}, {
    name: 'petar',
    species: 'aaaaaa',
    legsCount: 1
}, {
    name: 'back',
    species: 'aaaaaa',
    legsCount: 3
}, {
    name: 'boby',
    species: 'zblabla',
    legsCount: 2
}, {
    name: 'zich',
    species: 'aaaaaa',
    legsCount: 4
}];

solve()(animals);*/

module.exports = solve;
