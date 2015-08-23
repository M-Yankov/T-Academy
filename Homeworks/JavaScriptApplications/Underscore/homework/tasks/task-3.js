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

        var greatestStudent = _.chain(students)
            .sortBy(function (student) {
                var len = student.marks.length,
                    sum = 0,
                    i;

                for (i = 0; i < len; i += 1) {
                    sum += student.marks[i];
                }

                student.avg = sum / len;
                return sum / len;
            })
            .last()
            .value();

        var fullnames = greatestStudent.firstName + ' ' + greatestStudent.lastName;
        console.log(fullnames + ' has an average score of ' + greatestStudent.avg);
    };
}
var studs = [{
    firstName: 'Strahil',
    lastName: 'Ivan',
    age: 5,
    marks: [2, 3, 5, 2]
}, {
    firstName: 'Ivan',
    lastName: 'Ivan',
    age: 18,
    marks: [3, 6, 6, 5]
}];

solve()(studs);

module.exports = solve;
