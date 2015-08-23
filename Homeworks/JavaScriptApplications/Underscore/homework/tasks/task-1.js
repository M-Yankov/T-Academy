/*
 Create a function that:
 *   Takes an array of students
 *   Each student has a `firstName` and `lastName` properties
 *   **Finds** all students whose `firstName` is before their `lastName` alphabetically
 *   Then **sorts** them in descending order by fullname
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   Then **prints** the fullname of founded students to the console
 *   **Use underscore.js for all operations**
 */

function solve() {
    "use strict";
    return function (students) {
        var _; // underscore

        if (typeof require !== 'undefined') {
            //load underscore if on Node.js
            _ = require('../node_modules/underscore/underscore.js');
        }

        var isValidArrayOfStudents = _.every(students, function (student) {
            return (student.hasOwnProperty('firstName') && student.hasOwnProperty('lastName'));
        });

        if (!isValidArrayOfStudents) {
            throw new Error('One or more object are invalid!');
        }

        _.chain(students)
            .filter(function (student) {
                return student.firstName < student.lastName;
            })
            .sortBy(function (student) {
                return student.firstName + ' ' + student.lastName;
            })
            .reverse()
            .each(function (student) {
                console.log(student.firstName + ' ' + student.lastName);
            })
            .value();
    };
}

module.exports = solve;