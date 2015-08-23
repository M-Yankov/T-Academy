/*
 Create a function that:
 *   Takes an array of students
 *   Each student has a `firstName`, `lastName` and `age` properties
 *   **finds** the students whose age is between 18 and 24
 *   **prints**  the fullname of found students, sorted lexicographically ascending
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve() {
    "use strict";
    return function (students) {
        var MIN_AGE = 18,
            MAX_AGE = 24,
            _; // underscore

        if (typeof require !== 'undefined') {
            //load underscore if on Node.js
            _ = require('../node_modules/underscore/underscore.js');
        }

        var isValidArrayOfStudents = _.every(students, function (student) {
            return (student.hasOwnProperty('firstName') &&
                    student.hasOwnProperty('lastName') &&
                    student.hasOwnProperty('age'));
        });

        if (!isValidArrayOfStudents) {
            throw new Error('One or more object are invalid!');
        }

        _.chain(students)
            .filter(function (student) {
                return  (MIN_AGE <= student.age  && student.age <= MAX_AGE);
            })
            .sortBy(function (student) {
                return student.firstName + ' ' + student.lastName;
            })
            .each(function (student) {
                console.log(student.firstName + ' ' + student.lastName);
            });
    };
}

module.exports = solve;
