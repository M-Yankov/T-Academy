function solve() {
    function validation(titleToValidate) {
        if (titleToValidate[0] === ' ' || titleToValidate[titleToValidate.length - 1] === ' ' ||
            /\s{2,}/.test(titleToValidate) || titleToValidate === '') {
            throw new Error('Invalid Title name!');
        }
    }

    // receives a names of the student in this format: "Firstname Lastname"
    function validateStudentNames(nameTovalidate) {
        var arrayOfNames = nameTovalidate.split(' '),
            firstName = arrayOfNames[0].substring(1),
            lastName = arrayOfNames[1].substring(1);
        if(arrayOfNames.length !== 2){
            throw new Error('Only two names allowed');
        }

        if(arrayOfNames[0].length === 1){
            firstName = true;
        }

        if(arrayOfNames[1].length === 1){
            lastName = true;
        }

        if (!(/[A-Z]/.test(arrayOfNames[0][0])) ||
            !(/[A-Z]/.test(arrayOfNames[1][0])) ||
            !(/[a-z]/.test(firstName)) ||
            !(/[a-z]/.test(lastName))) {
            throw new Error('Invalid name of student');
        }
    }

    function checkDuplicateIds(array) {
        var k,
            arrayForKeepStudents = [],
            arrayOfIDs = [],
            arrLength = array.length;
        array.forEach(function (element) {
           arrayOfIDs.push(element.StudentID);
        });
        for (k = 0; k < arrLength; k += 1) {
            if(arrayForKeepStudents.indexOf(arrayOfIDs[k]) !== -1){
                throw new Error('Ids can\'t duplicate! --> pushExamResults()!');
            } else {
                arrayForKeepStudents.push(arrayOfIDs[k]);
            }

        }
    }

    var Course = {
        // Singleton function
        getId: (function () {
            var id = 0;
            return {
                get: function () {
                    return ++id;
                }
            };
        }()),

        init: function (title, presentations) {
            validation(title);
            if (presentations.length === 0) {
                throw new Error('No presentations');
            }

            var hasCorrectNamesPresentation = presentations.every(function (obj) {
                return (obj !== '' && !/\s{2,}/.test(obj));
            });

            if(!hasCorrectNamesPresentation){
                throw new Error('Presentation with empty names are not allowed');
            }
            this.title = title;
            this.presentations = presentations.slice();
            this.students = [];
            return this;
        },

        addStudent: function (name) {
            validateStudentNames(name);
            var studentNames = name.split(' '),
                firstName = studentNames[0],
                lastName = studentNames[1],
                student = {};

            student.firstname = firstName;
            student.lastname = lastName;
            student.id = this.getId.get();

            this.students.push(student);
            return student.id;
        },

        getAllStudents: function () {
            // deep copy;
            return this.students.slice();
        },

        submitHomework: function (studentID, homeworkID) {
            if (isNaN(studentID) || isNaN(homeworkID) || studentID !== (studentID |0) || homeworkID !== (homeworkID | 0) ||
                studentID < 1 || homeworkID < 1) {
                throw new Error('Invalid ID when submit homework');
            } else if(studentID > this.students.length || homeworkID > this.presentations.length){
                throw new Error('Out of Range ID!');
            }

            var j,
                len = this.students.length,
                homework = this.presentations[homeworkID - 1];
            for (j = 0; j < len; j += 1) {
                if (this.students[j].id === studentID) {
                    this.students[j].homeworks = this.students[j].homeworks || [];
                    this.students[j].homeworks.push(homework);
                }
            }
        },

        pushExamResults: function (results) {
            this.students.forEach(function (element, index, array) {
                array[index].score = 0;
            });

            var z,
                lenResults = results.length,
                lenStudents = this.students.length,
                allStudentsHasCorrectIDs = results.every(function (element, index, array) {
                    return element.StudentID <= lenStudents;
                }),
                allStudentsHasScoreFromTypeNumber = results.every(function (element, index, array) {
                    return !isNaN(element.Score);
                });

            if (!allStudentsHasCorrectIDs) {
                throw new Error('Invalid Id in pushExamResults()!');
            }

            if(!allStudentsHasScoreFromTypeNumber){
                throw new Error('Invalid Score pushExamResults()!');
            }

            checkDuplicateIds(results);

            for (z = 0; z < lenResults; z += 1) {
                this.students[results[z].StudentID].score = results[z].Score;
            }

        },

        getTopStudents: function () {

        }
    };
    return Course;
}

function test() {
    var id,
        jsoop = Object.create(solve());
    jsoop.init('JavaScriptOOP', ['Wall hack']);
    id = jsoop.addStudent('Myname' + ' ' + 'Islong');
    jsoop.submitHomework(id, 1);
    console.log(jsoop.getAllStudents());
}

test();

module.exports = solve;
