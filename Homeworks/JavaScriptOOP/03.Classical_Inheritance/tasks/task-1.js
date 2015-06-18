function solve() {
    var Person = (function () {
        Person.prototype.introduce = function () {
            return 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old';
        };

        function Person(fname, lname, age) {
            var that = this;

            Object.defineProperties(that, {
                fullname: {
                    get: function () {
                        //console.log('In getter!');
                        return this.firstname + ' ' + this.lastname;
                    },
                    set: function (fullname) {
                        //console.log('setter passed!');
                        var names = fullname.split(' ');
                        this.firstname = names[0];
                        this.lastname = names[1]
                    },
                    configurable: true
                },

                age: {
                    get: function () {
                        return age;
                    },
                    set: function (num) {
                        age = num;
                    },
                    configurable: true
                }
            });

            // validations. btw what is passed in the func ? obj or params?
            // I can make this task with Person.prototype.getters and setters.


            validations(fname);
            validations(lname);

            if (isNaN(age) || +age < 0 || +age > 150) {
                throw 'Age range is invalid!';
            }

            that.firstname = fname;
            that.lastname = lname;
            that.age = age;
            that.fullname = fname + ' ' + lname;    // to be sure that this code goes to setter in 'fullname' I place defineProperty
                                                    // in the begin of the function

            return that;
        }

        function validations(name) {
            if (!name) {
                throw 'Parameter missing!';
            }

            var len = name.length,
                regExer = new RegExp('[А-Яа-я]+', 'g');

            if (len < 3 || len > 20) {
                throw 'Error in name length!';
            }

            if (regExer.test(name)) {
                throw 'cyrillic letters are NOT allowed!';
            }
        }

        return Person;
    }());

    return Person;
}

/*var func = solve();
var p1 = new func('Pesho', 'Petrov', 23);
console.log(p1.fullname);
console.log(p1.introduce());*/

/*      testing to match cyrillic letters;

 var text = 'Tyk ima кирилски bukvi ГОЛЕМИ i malki',
 regExer = new RegExp('[А-Яа-я]+', 'g');
 console.log(regExer.test(text));  // true
 */

module.exports = solve;