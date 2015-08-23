/* 
 Create a function that:
 *   **Takes** a collection of books
 *   Each book has propeties `title` and `author`
 **  `author` is an object that has properties `firstName` and `lastName`
 *   **finds** the most popular author (the author with biggest number of books)
 *   **prints** the author to the console
 *	if there is more than one author print them all sorted in ascending order by fullname
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve() {
    "use strict";
    return function (books) {
        var _ = require('../node_modules/underscore/underscore.js');

        var groupedByAuthor = _.groupBy(books, function (book) {
            return book.author.firstName + ' ' + book.author.lastName;
        });

        var authors = _.chain(groupedByAuthor).keys().sortBy().value();
        var sortedBooksByLength = _.sortBy(groupedByAuthor, function (value, key, list) {
            /*console.log(value.length);*/
            return -list[key].length;
        });

        var c = _.chain(groupedByAuthor)
            .pairs()
            .sortBy(function(item, index, list) {
                return -item[1].length;
            })
            .filter(function (item, index, list) {
                var maxLength  = list[0][1].length;
                return maxLength === item[1].length;
            })
            .map(function (authorBooks, index, list) {
              return _.first(authorBooks);
            })
            .sortBy()
            .each(function (item) {
                console.log(item);
            })
            .value();


        /*console.log(authors);
        console.log(groupedByAuthor);
        console.log(sortedBooksByLength);*/
    };
}

var books = [{
    title: 'JS io',
    author: {
        firstName: 'Pesho',
        lastName: 'foo'
    }
}, {
    title: 'C++',
    author: {
        firstName: 'Pesho',
        lastName: 'foo'
    }
}, {
    title: 'Server side nodes',
    author: {
        firstName: 'Pesho',
        lastName: 'foo'
    }
}, {
    title: 'WEB Sites',
    author: {
        firstName: 'Pesho',
        lastName: 'foo'
    }
}, {
    title: 'OOP Styles',
    author: {
        firstName: 'Pesho',
        lastName: 'foo'
    }
}, {
    title: 'C#1',
    author: {
        firstName: 'Konstantin',
        lastName: 'foo'
    }
}, {
    title: 'C#2',
    author: {
        firstName: 'Konstantin',
        lastName: 'foo'
    }
}, {
    title: 'C#3',
    author: {
        firstName: 'Konstantin',
        lastName: 'foo'
    }
}, {
    title: 'C#4',
    author: {
        firstName: 'Konstantin',
        lastName: 'foo'
    }
}, {
    title: 'C#5',
    author: {
        firstName: 'Konstantin',
        lastName: 'foo'
    }
}, {
    title: 'Morninng',
    author: {
        firstName: 'The Voice',
        lastName: 'foo'
    }
}];


solve()(books);

module.exports = solve;
