using System;

//Help array to hold data for student
class Student
{
    private string firstName;
    private string lastName;
    private int age;

    public Student(string fname, string lname, int age)
    {
        this.firstName = fname;
        this.lastName = lname;
        this.age = age;
    }

    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }
    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }
    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

}

