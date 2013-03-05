using System;
using System.Collections.Generic;

namespace _1_SchoolHierarchy
{
    class Discipline : Comment
    {
        private string name;
        private int lecturesCount;
        private int exercisesCount;

        #region Constructors
        public Discipline(string name, int lecturesCount, int exercisesCount)
            : base()
        {
            this.name = name;
            this.lecturesCount = lecturesCount;
            this.exercisesCount = exercisesCount;
        }

        public Discipline(string name, int lecturesCount, int exercisesCount, string comment)
            : base(comment)
        {
            this.name = name;
            this.lecturesCount = lecturesCount;
            this.exercisesCount = exercisesCount;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int LecturesCount
        {
            get { return this.lecturesCount; }
            set { this.lecturesCount = value; }
        }
        public int ExercisesCount
        {
            get { return this.exercisesCount; }
            set { this.exercisesCount = value; }
        }
        #endregion

        public override string ToString()
        {
            return String.Format("{0}\nLectures: {1}\nExercises:{2}",
                this.name, this.lecturesCount, this.exercisesCount);
        }
    }
}
