function solve() {
    var library = (function () {
        var books = [];
        var categories = [];

        function listBooks(object) {
            //  console.log('Property: ' + Object.keys(object)[0] );  // getting the name of the first prop no matter of it's name.
            //  http://stackoverflow.com/questions/983267/access-the-first-property-of-an-object
            //  object[Object.keys(object)[0]] = value of first property.

            var result = [],
                value;

            if (!object) {
                return books;
            }

            value = object[Object.keys(object)[0]];
            switch (Object.keys(object)[0]) {
                case 'author':
                    result = books.filter(function (element, index, array) {
                        return element.author === value
                    });
                    break;
                case 'title':
                    result = books.filter(function (element, index, array) {
                        return element.title === value
                    });
                    break;
                case 'isbn':
                    result = books.filter(function (element, index, array) {
                        return element.isbn === value
                    });
                    break;
                case 'category':
                    result = books.filter(function (element, index, array) {
                        return element.category === value
                    });
                    break;
                case 'all':
                    //idk what to do.
                    break;
                default:

            }
            return result;
        }

        function addBook(book) {
            // check if this variables are unique. Not contains in books[] - DONE (maybe)
            // then check the category,
            // then validation - see the conditions from task.
            if (!book) {
                throw  'ARE grumni se beee!';
            }
            if (book.title === undefined || book.isbn === undefined || book.author === undefined) {
                throw 'Properties of book missing!';
            }
            var i,
                len = books.length;
            for (i = 0; i < len; i += 1) {
                if (books[i]['title'] === book.title || books[i]['isbn'] === book.isbn) {
                    throw 'Book title and ISBN must be unique!'
                }
            }
            // validation
            if (book.title.length < 2 || book.title.length > 100) {
                throw 'Error in title length!';
            } else if (book.author === '') {
                throw 'Missing author name!';
            } else if (isNaN(book.isbn)) {
                throw 'ISBN must contains only digits!';
            } else if (book.isbn.toString().length !== 10 && book.isbn.toString().length !== 13) {
                throw 'ISBN length = 13 or 10!';
            }

            if (categories.indexOf(book.category) === -1) {

                categories.push(book.category); //???
            }
            book.ID = books.length + 1;
            books.push(book);
            return book;
        }

        function listCategories() {

            //categories = categories.sort(); // only sort() works for strings
            return categories;

        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    }());
    return library;
}


/* My tests below */

/*
 Array.prototype.equals = function (array) {
 // if the other array is a falsy value, return
 if (!array)
 return false;

 // compare lengths - can save a lot of time
 if (this.length != array.length)
 return false;

 for (var i = 0, l = this.length; i < l; i++) {
 // Check if we have nested arrays
 if (this[i] instanceof Array && array[i] instanceof Array) {
 // recurse into the nested arrays
 if (!this[i].equals(array[i]))
 return false;
 }
 else if (this[i] != array[i]) {
 // Warning - two different object instances will never be equal: {x:20} != {x:20}
 return false;
 }
 }
 return true;
 };
 */

var myLibrary = solve();
var b1 = {
        title: 'Harry Potter',
        author: 'J.K.Rollins',
        isbn: 1234567892222,
        category: 'Fantastic'
    },
    b2 = {
        title: 'The lone lake',
        author: 'Robert Whiliamson',
        isbn: 9084567892222,
        category: 'Drama'
    },
    b3 = {
        title: 'Me, out of mind',
        author: 'Albert',
        isbn: 9234567892,
        category: 'Sci-Fi'
    },
    b4 = {
        title: 'Horizontal',
        author: 'The Z',
        isbn: 2234569892222,
        category: 'Fantastic'
    },
    b5 = {
        title: 'Vertical',
        author: 'Great Mountain',
        isbn: 2234569890122,
        category: 'Applications'
    };

//console.log(myLibrary.categories.list());

 //console.log(myLibrary.books.list().equals([]));
 myLibrary.books.add(b1);
 //console.log(myLibrary.books.list().equals([b1]));
 myLibrary.books.add(b2);
 myLibrary.books.add(b3);
 myLibrary.books.add(b4);
 myLibrary.books.add(b5);
 //console.log(myLibrary.books.list().equals([]));
 console.log(myLibrary.categories.list());  // To test .equals() - uncomment prototype above

module.exports = solve;


