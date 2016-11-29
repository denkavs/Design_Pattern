/// <reference path="js/jasmine.js" />
/// <reference path="js/jasmine-html.js" />

describe('Sort Algoritms ->', function () {

    afterEach(function () {
        var actual = 6;
        var expt = 6;
        expect(actual).toEqual(expt);
    });

    var arr = [7, 3, 13, 5, 17, 9, 11, 15];

    function getInitArray() {
        var data = [];
        for (var i = 0, len = arr.length; i < len; i++) {
            data.push(arr[i]);
        }

        return data;
    }

    describe('-- Search Algoritms', function () {

        it('/-- Bi_search', function () {
            var arr = getInitArray();
            var index = -1;
            var seachVal = 17;
            var biSearch = function (data, find) {

                var index = -1;
                if(data.length == 0)
                    return index;

                var low = 0;
                var high = data.length - 1;
                while (low <= high) {
                    var mid = parseInt((low + high) / 2, 10);
                    if (find == data[mid]) {
                        index = mid;
                        break;
                    }
                    if (find < data[mid])
                        high = mid - 1;
                    else
                        low = mid + 1;
                }

                return index;
            };

            arr = arr.sort(function (a, b) { return a - b; });
            console.log(arr);
            console.log(biSearch(arr, 17));
            console.log(biSearch(arr, 5));
            console.log(biSearch(arr, 9));
        });

        it(' /-- Liner search or brootforce', function () {
            var arr = getInitArray();
            var index = -1;
            var seachVal = 17;
            for (var i = 0; i < arr.length; i++) {
                if (arr[i] == seachVal) {
                    index = i;
                    break;
                }
            }
            console.log(index);
        });

    });

    describe('-- Sort Algoritms', function () {

        var exchange_f = function (array, l, r) {
            var temp = array[l];
            array[l] = array[r];
            array[r] = temp;
        };
        var compare_f = function (l, r) {
            if (l == r) return 0;
            if (l < r) return -1;
            if (l > r) return 1;
        };

        it('/ - Insertion sort', function () {
            var arr = getInitArray();
            var len = arr.length;

            var shiftElement = function (arr, startPos, endPos) {
                if (startPos >= endPos)
                    return;
                var endIndex = endPos;
                for (var i = endIndex - 1; i >= startPos; i--) {
                    arr[endIndex] = arr[i];
                    endIndex--;
                }
            };

            var searchAndInsertion = function (currIndex) {

                var curVal = arr[currIndex];
                var posToInsert = -1;

                for (var i = currIndex - 1; i >= 0; i--) {
                    if ((compare_f(arr[i], curVal) == 1)) {
                        posToInsert = i;
                    }
                    else {
                        break;
                    }
                }

                if (posToInsert > -1) {
                    shiftElement(arr, posToInsert, currIndex);
                    arr[posToInsert] = curVal;
                }
                console.log(arr);
            };
            console.log(arr);

            // enumeration elements
            for (var i = 0; i < len; i++) {
                searchAndInsertion(i);
            }
        });

        it('/ - Bubble sort', function () {

            var array = getInitArray();
            var bubbleSort = function (data) {
                var arr = data;
                var len = arr.length - 1;

                while (len > 0)
                {
                    var max = len - 1;
                    var i = 0;
                    while (i <= max) {
                        if (compare_f(arr[i], arr[i+1]) == 1) {
                            exchange_f(arr, i, i + 1);
                        }
                        i++;
                    }
                    len--;
                }
            };
            bubbleSort(array);
            console.log(array);
        });

        it('/ - Build in array sort', function () {
            var arr = [12, 2, 15];
            function compareNumeric(a, b) {
                if (a > b) return 1;
                if (b > a) return -1;
            };

            arr.sort(compareNumeric);
            alert(arr);
        });

        it('/ - Quick sort own implementation', function () {

            var array = getInitArray();

            function qsort(data, compare, change) {
                var a = data,
                    f_compare = compare,
                    f_change = change;

                if (!a instanceof Array) { // Данные не являются массивом
                    return undefined;
                };
                if (f_compare == undefined) { // Будем использовать простую функцию (для чисел)
                    f_compare = function (a, b) { return ((a == b) ? 0 : ((a > b) ? 1 : -1)); };
                };
                if (f_change == undefined) { // Будем использовать простую смены (для чисел)
                    f_change = function (a, i, j) { var c = a[i]; a[i] = a[j]; a[j] = c; };
                };

                var qs = function (l, r) {
                    var i = l,
                        j = r,
                        x = a[l + r >> 1];
                    console.log('left - ' + l + ', right - ' + r + ', pivot - ' + x);
                    //x = a[Math.floor(Math.random()*(r-l+1))+l];
                    // x = a[l]; // Если нет желания использовать объект Math

                    while (i <= j) {
                        while (f_compare(a[i], x) == -1) { i++; }
                        while (f_compare(a[j], x) == 1) { j--; }
                        if (i <= j) { f_change(a, i++, j--); }
                    };
                    console.log(array);
                    if (l < j) { qs(l, j); }
                    if (i < r) { qs(i, r); }
                };
                qs(0, a.length - 1);
            };

            qsort(array);
            //console.log(array);
        });
    });
});