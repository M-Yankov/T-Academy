/* 
 Create a function that:
 *   Takes an array of students
 *   Each student has:
 *   `firstName`, `lastName` and `age` properties
 *   Array of decimal numbers representing the marks
 *   **finds** the student with highest average mark (there will be only one)
 *   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
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
            return (
            _.propertyOf(student)('firstName') &&
            _.propertyOf(student)('lastName') &&
            _.propertyOf(student)('age') &&
            _.propertyOf(student)('marks'));
        });

        if (!isValidArrayOfStudents) {
            throw new Error('One or more object are invalid!');
        }

        var nerdStudent = _.chain(students)
            .sortBy(function (student) {
                var sum = _.reduce(student.marks, function (callback, current) {
                    return callback + current;
                }, 0);
                student.avg = sum / student.marks.length;
                return student.avg;
            })
            .last()
            .value();

        var fullNameOfNerd = nerdStudent.firstName + ' ' + nerdStudent.lastName;
        console.log(fullNameOfNerd + ' has an average score of ' + nerdStudent.avg);
    };
}

module.exports = solve;
