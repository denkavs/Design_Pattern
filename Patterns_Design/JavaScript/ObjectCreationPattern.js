/// <reference path="js/jasmine.js" />
/// <reference path="js/jasmine-html.js" />

describe('Object creation patterns -->', function () {
    'use strict';

    afterEach(function () {
        var actual = 6;
        var expt = 6;
        expect(actual).toEqual(expt);
    });

    describe('-- Module Pattern', function () {
        // Check if namespace exist
        var MYAPP = MYAPP || {};

        MYAPP.namespace = function (ns_string) {
            var parts = ns_string.split('.'), parent = MYAPP, i;

            // strip redundant leading global
            if (parts[0] === "MYAPP") {
                parts = parts.slice(1);
            }
            for (i = 0; i < parts.length; i += 1) {
                // create a property if it doesn't exist
                if (typeof parent[parts[i]] === "undefined") {
                    parent[parts[i]] = {};
                }
                parent = parent[parts[i]];
            }
            return parent;
        };

        it('/Static Members private', function () {
            // constructor
            var Gadget = (function () {
                // static variable/property
                var counter = 0,
                NewGadget;
                // this will become the
                // new constructor implementation
                NewGadget = function () {
                    counter += 1;
                };
                // a privileged method
                NewGadget.prototype.getLastId = function () {
                    return counter;
                };
                // overwrite the constructor
                return NewGadget;
            }()); // execute immediately

            var iphone = new Gadget();
            iphone.getLastId(); // 1
            var ipod = new Gadget();
            ipod.getLastId(); // 2
            var ipad = new Gadget();
            ipad.getLastId(); // 3
        });

        it('/Static Members public', function () {
            // constructor
            var Gadget = function () { };
            // a static method
            Gadget.isShiny = function () {
                return "you bet";
            };
            // a normal method added to the prototype
            Gadget.prototype.setPrice = function (price) {
                this.price = price;
                console.log(Gadget.isShiny());
            };

            // calling a static method
            Gadget.isShiny(); // "you bet"
            // creating an instance and calling a method
            var iphone = new Gadget();
            iphone.setPrice(500);
        });

        it('/Sandbox', function () {

            function Sandbox() {
                // turning arguments into an array
                var args = Array.prototype.slice.call(arguments),
                // the last argument is the callback
                callback = args.pop(),
                // modules can be passed as an array or as individual parameters
                modules = (args[0] && typeof args[0] === "string") ? args : args[0],
                i;
                // make sure the function is called
                // as a constructor
                if (!(this instanceof Sandbox)) {
                    return new Sandbox(modules, callback);
                }
                // add properties to `this` as needed:
                this.a = 1;
                this.b = 2;
                // now add modules to the core `this` object
                // no modules or "*" both mean "use all modules"
                if (!modules || modules === '*') {
                    modules = [];
                    for (i in Sandbox.modules) {
                        if (Sandbox.modules.hasOwnProperty(i)) {
                            modules.push(i);
                        }
                    }
                }
                // initialize the required modules
                for (i = 0; i < modules.length; i += 1) {
                    Sandbox.modules[modules[i]](this);
                }
                // call the callback
                callback(this);
            };

            Sandbox.modules = {};
            Sandbox.modules.dom = function (box) {
                box.domFunction = function (name) {
                    console.log('We are calling dom function from dom module with parameter - ' + name);
                };
            };

            Sandbox.modules.ajax = function (box) {
                box.makeClientReqeust = function (data) {
                    console.log('Ajax module request to client with parameter --' + data);
                };
            };

            // any prototype properties as needed
            Sandbox.prototype = {
                name: "My Application",
                version: "1.0",
                getName: function () {
                    return this.name;
                }
            };

            var box1, box2;
            Sandbox(['dom'], function (box) {
                box1 = box;
            });

            Sandbox(['ajax'], function (box) {
                box2 = box;
            });

            var bSame = box1 === box2;
            box1.domFunction('Wouu!!');
            box2.makeClientReqeust(999);

        });

        it('/Curriyng', function () {

            function bindFunc() {
                var slice = Array.prototype.slice,
                    fn = arguments[0],
                    oldAgruments = slice.call(arguments, 1);
                return function () {
                    var newArg = slice.call(arguments),
                        args = oldAgruments.concat(newArg);
                    fn.apply(null, args);
                };
            };

            function sport(x, y, c) {
                console.log(x);
                console.log(y);
                console.log(c);
                return x + y + c;
            };

            var fox = bindFunc(sport, 3);
            fox(1, 2);

        });

        it('/Modules that create constructors', function () {
        MYAPP.namespace('MYAPP.utilities.Array');
        MYAPP.utilities.Array = (function () {
            // dependencies
            var uobj = MYAPP.utilities.object,
            ulang = MYAPP.utilities.lang,
            // private properties and methods...
            Constr;
            // end var

            // optionally one-time init procedures
            // ...

            // public API -- constructor
            Constr = function (o) {
                this.elements = this.toArray(o);
            };

            // public API -- prototype
            Constr.prototype = {
                constructor: MYAPP.utilities.Array,
                version: "2.0",
                toArray: function (obj) {
                    var a = [];
                    if (typeof obj === 'object') {
                        var slice = Array.prototype.slice,
                        stored_args = slice.call(obj);
                        for(var name in obj)
                        {
                            if (Object.prototype.hasOwnProperty.call(obj, name)) {
                                a.push(obj[name]);
                            }
                        }
                    }
                    else {
                        for (var i = 0, len = obj.length; i < len; i += 1) {
                            a[i] = obj[i];
                        }
                    }
                    return a;
                }
            };
            // return the constructor
            // to be assigned to the new namespace
            return Constr;
        }());

        var obj = { name: "Vova", age: 15 };
        var arr = new MYAPP.utilities.Array(obj);
        });

        it('/Import global into the module ', function () {
            MYAPP.namespace('MYAPP.utilities.Array');
            var newModule = (function (myApp, glb) {
                // references to the global object
                // and to the global app namespace object
                // are now localized
            }(MYAPP.utilities.Array, 124));
        });

        it('/ Module pattern simple ', function () {
            MYAPP.namespace('MYAPP.utilities.array');

            MYAPP.utilities.array = (function () {
                // dependencies
                var uobj = MYAPP.utilities.object,
                ulang = MYAPP.utilities.lang,
                // private properties
                array_string = "[object Array]",
                ops = Object.prototype.toString;
                // private methods
                // ...
                // end var

                // optionally one-time init procedures
                // ...
                // public API
                return {
                    inArray: function (needle, haystack) {
                        for (var i = 0, max = haystack.length; i < max; i += 1) {
                            if (haystack[i] === needle) {
                            }
                        }
                    },
                    isArray: function (a) {
                        return ops.call(a) === array_string;
                    }
                    // ... more methods and properties
                };
            }());
        });
    });

    describe('-- Prototype and Privecy', function () {
        function Gadget() {
            // private member
            var name = 'iPod';
            // public function
            this.getName = function () {
                return name;
            };
        };

        Gadget.prototype = (function () {
            // private member
            var browser = "Mobile Webkit";
            // public prototype members
            return {
                getBrowser: function () {
                    return browser;
                }
            };
        }());

        var toy = new Gadget();
        console.log(toy.getName()); // privileged "own" method
        console.log(toy.getBrowser()); // privileged prototype method
    });

    describe('-- Object Literals and Privacy', function () {
        var toy = (function () {
            var name;
            return {
                getName: function () {
                    return name;
                }
            };
        }());

        console.log(toy.name);
        console.log(toy.getName());
    });

    describe('-- Private Properties and Methods', function () {
        function Gadget() {
            // private member
            var name = 'iPod';
            // public function
            this.getName = function () {
                return name;
            };
        };

        var toy = new Gadget();
        // `name` is undefined, it's private
        console.log(toy.name); // undefined
        console.log(toy.getName()); // undefined
    });

    describe('-- Declaring Dependencies', function () {
        var myFunction = function () {
            // dependencies
            var event = YAHOO.util.Event,
            dom = YAHOO.util.Dom;
            // use event and dom variables
            // for the rest of the function...
        };
    });

    describe('--Namespace pattern', function () {
        // Check if namespace exist
        var MYAPP = MYAPP || {};

        MYAPP.namespace = function (ns_string) {
            var parts = ns_string.split('.'), parent = MYAPP, i;

            // strip redundant leading global
            if (parts[0] === "MYAPP") {
                parts = parts.slice(1);
            }
            for (i = 0; i < parts.length; i += 1) {
                // create a property if it doesn't exist
                if (typeof parent[parts[i]] === "undefined") {
                    parent[parts[i]] = {};
                }
                parent = parent[parts[i]];
            }
            return parent;
        };

        // assign returned value to a local var
        var module2 = MYAPP.namespace('MYAPP.modules.module2');
        module2 === MYAPP.modules.module2; // true
        // skip initial `MYAPP`
        MYAPP.namespace('modules.module51');
        // long namespace
        MYAPP.namespace('once.upon.a.time.there.was.this.long.nested.property');
    });
});