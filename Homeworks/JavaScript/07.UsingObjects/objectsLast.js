/*** Problem 6 ***/

function groupBy() {
    var MakePerson = function (a, b, c) {
        this.name = a;
        this.family = b;
        this.age = c;
    };
    MakePerson.prototype.toString = function() {
        return this.name + ' ' + this.family + ' Age: ' + this.age;
    };
    var resultAge,
        resultName,
        resultFamily,
        p1 = new MakePerson('Gosho', 'Georgiev', 22),
        p2 = new MakePerson('Petar', 'Georgiev', 16),
        p3 = new MakePerson('Yordan', 'Georgiev', 22),
        p4 = new MakePerson('Gosho', 'Peshev', 17),
        p5 = new MakePerson('Gosho', 'Trakaiiev', 22),
        p6 = new MakePerson('Victor', 'Georgiev', 17),
        p7 = new MakePerson('Gosho', 'Yordanov', 22),
        p8 = new MakePerson('Gosho', 'Georgiev', 17),
        p9 = new MakePerson('Yordan', 'Ivailov', 22),
        p10 = new MakePerson('Petar', 'Trakaiiev', 16),
        p11 = new MakePerson('Zlatan', 'Yordanov', 16),
        myArr = [p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11];
    var groupingBy = function (array, stringProp) {
        var item, i,
            grandeObject = {};
        for (i = 0; i < array.length; i += 1) {
            item = array[i];
            if (!grandeObject[item[stringProp]]) {
                grandeObject[item[stringProp]] = [item];
            } else {
                grandeObject[item[stringProp]].push(item);

            }
        }
        return grandeObject
    };
    resultAge = groupingBy(myArr, 'age');
    show(resultAge); // will show [object object] just debugging
    resultName = groupingBy(myArr, 'name');
    resultFamily = groupingBy(myArr, 'family');
    for (var a in resultAge) {
        add(a + ':');
        add('\t' + resultAge[a].join('\r\n\t'));
    }
    add('---- group by name: ----');
    for (var b in resultName) {
        add(b + ':');
        add('\t' + resultName[b].join('\r\n\t'));
    }
    add('---- group by family ----');
    for (var c in resultFamily) {
        add(c + ':');
        add('\t' + resultFamily[c].join('\r\n\t'));
    }

    //add(p1);
    //add(p1.toString());
}

