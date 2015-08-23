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

        _.chain(groupedByAuthor)
            .pairs()
            .sortBy(function (item) {
                return -item[1].length;
            })
            .filter(function (item, index, list) {
                var maxLength = list[0][1].length;
                return maxLength === item[1].length;
            })
            .map(function (authorBooks) {
                return _.first(authorBooks);
            })
            .sortBy()
            .each(function (item) {
                console.log(item);
            })
            .value();
    };
}

module.exports = solve;
