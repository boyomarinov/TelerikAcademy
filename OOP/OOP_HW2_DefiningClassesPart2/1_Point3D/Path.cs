using System;
using System.Collections.Generic;

namespace _1_Point3D
{
    //Holds a sequence of 3D points
    class Path
    {
        private List<Point3D> pointSequence;

        //constructors
        public Path()
        {
            this.pointSequence = new List<Point3D>();
        }

        //properties
        public List<Point3D> PointSequence
        {
            get { return this.pointSequence; }
            set { this.pointSequence = value; }
        }

        #region Methods
        public void AddPoint(Point3D toAdd)
        {
            this.pointSequence.Add(toAdd);
        }

        public void ClearPoints()
        {
            this.pointSequence.Clear();
        }

        //Indexer
        public Point3D this[int index]
        {
            get
            {
                if (index >= 0 && index < this.pointSequence.Count)
                {
                    return this.pointSequence[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < this.pointSequence.Count)
                {
                    this.pointSequence[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public int Count
        {
            get { return this.pointSequence.Count; }
        }
        #endregion
    }
}
