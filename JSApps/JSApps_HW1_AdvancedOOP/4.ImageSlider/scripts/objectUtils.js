if (!Object.create) {
    Object.create = function (obj) {
        function createObject() { };
        createObject.prototype = obj;
        return new createObject();
    }
}

if (!Object.prototype.extend) {
    Object.prototype.extend = function (props) {
        function createObject() { };
        createObject.prototype = Object.create(this);
        for (var prop in props) {
            createObject.prototype[prop] = props[prop];
        }
        createObject.prototype._super = this;
        return new createObject();
    }
}
