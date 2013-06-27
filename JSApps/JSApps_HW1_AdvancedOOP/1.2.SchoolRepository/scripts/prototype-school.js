﻿var Person = {
    init: function (fname, lname, age) {
        this.fname = fname;
        this.lname = lname;
        this.age = age;
    },

    introduce: function () {
        return "Name:" + this.fname + " " + this.lname + ", Age: " + this.age;
    }
};

var Student = Person.extend({
    init: function (fname, lname, age, grade) {
        this._super = Object.create(this._super);
        this._super.init(fname, lname, age);
        this.grade = grade;
    },

    introduce: function () {
        return this._super.introduce() + ", grade: " + this.grade;
    }
});

var Teacher = Person.extend({
    init: function (fname, lname, age, speciality) {
        this._super = Object.create(this._super);
        this._super.init(fname, lname, age);
        this.speciality = speciality;
    },

    introduce: function () {
        return this._super.introduce() + ", speciality: " + this.speciality;
    }
});

var School = {
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    },

    introduce: function () {
        var str = "Name:" + this.name + ", Town:" + this.town + ", Classes:";
        for (var i = 0; i < this.classes.length; i++) {
            str += this.classes[i].name + ", ";
        }
        return str.substr(0, str.length - 2);
    }
};

var Course = {
    init: function (name, capacity, students, formTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.students = students;
        this.formTeacher = formTeacher;
    },

    introduce: function () {
        var str = "Name:" + this.name + ", Capacity:" + this.capacity + ", Students:";
        for (var i = 0; i < this.students.length; i++) {
            str += this.students[i].introduce() + ", ";
        }
        str += "Form-teacher" + this.formTeacher.introduce();
        return str;
    }
};