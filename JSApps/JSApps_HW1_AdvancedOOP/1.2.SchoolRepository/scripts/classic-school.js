var School = Class.create({
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    },
});

var Person = Class.create({
    init: function (fname, lname, age, grade) {
        this.firstName = fname;
        this.lastName = lname;
        this.age = age;
    },

    introduce: function () {
        return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
    }
});

var Student = Class.create({
    init: function (fname, lname, age, grade) {
        this._super = new this._super(arguments);
        this._super.init(fname, lname, age);
        this.grade = grade;
    },

    introduce: function () {
        return this._super.introduce() + ", Grade: " + this.grade;
    }
});
Student.inherit(Person);

var Teacher = Class.create({
    init: function (fname, lname, age, speciality) {
        this._super = new this._super(arguments);
        this._super.init(fname, lname, age);
        this.speciality = speciality;
    },

    introduce: function () {
        return this._super.introduce() + ", Speciality: " + this.speciality;
    }
});
Teacher.inherit(Person);


