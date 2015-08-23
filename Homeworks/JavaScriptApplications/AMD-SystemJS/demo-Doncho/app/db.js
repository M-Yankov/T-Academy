import storageLoader from 'app/storage'; // ./storage

var storage = storageLoader.get('local');

let storageKey = 'data-items';
let items = storage.load(storageKey) || [];

let idGenerator = (function () {
    "use strict";
    let id = 0;

    return {
        next: function () {
            id += 1;
            return id;
        }
    };
}());

function add(item) {
    "use strict";
    item.id = idGenerator.next();

    let indexOfCurrentIDInDB = items.findIndex((searchItem) => {
        return searchItem.id === item.id;
    });

    while (indexOfCurrentIDInDB >= 0) {
        item.id = idGenerator.next();
        indexOfCurrentIDInDB = items.findIndex((searchItem) => {
            return searchItem.id === item.id;
        });
    }

    items.push(item);
    storage.save(storageKey, items);
}

function all() {
    "use strict";
    return items.slice();
}

function removeByID(id) {
    "use strict";
    let indexOfItemToRemove = items.findIndex((item) => {
        return item.id === id;
    });

    if (indexOfItemToRemove < 0) {
        throw new Error('Element not found!');
    }

    items.splice(indexOfItemToRemove, 1);
    storage.save(storageKey, items);
}

export default {
    add, all, removeByID
}