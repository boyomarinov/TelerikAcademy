var Class = (function(){
    'use strict';
    function create(props) {
        var func = function () {
            this.init.apply(this, arguments);
        }

        for (var prop in props) {
            func.prototype[prop] = props[prop];
        }

        if (!func.prototype.init) {
            func.prototype.init = function () { }
        }

        return func;
    };

    Function.prototype.inherit = function (parent) {
        var oldPrototype = this.prototype;
        var newPrototype = new parent();
        this.prototype = Object.create(newPrototype);
        this.prototype._super = parent;

        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop];
        }
    };

    return {
        create: create
    };
}());