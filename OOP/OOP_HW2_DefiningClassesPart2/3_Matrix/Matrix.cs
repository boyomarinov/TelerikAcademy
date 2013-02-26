using System;

namespace _3_Matrix
{
    class Matrix<T>
        where T : IComparable<T>
    {
        private int rows;
        private int cols;
        private T[,] matrix;

        #region Constructors
        public Matrix()
        {
            this.rows = 0;
            this.cols = 0;
            matrix = new T[this.rows, this.cols];
        }

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new T[this.rows, this.cols];
        }
        #endregion

        #region Properties
        public int Rows
        {
            get { return this.rows; }
        }

        public int Cols
        {
            get { return this.cols; }
        }
        #endregion

        #region Operators
        public T this[int rows, int cols]
        {
            get
            {
                if (rows < 0 || rows >= this.rows || cols < 0 || cols >= this.cols)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.matrix[rows, cols];
            }
            set
            {
                if (rows < 0 || rows >= this.rows || cols < 0 || cols >= this.cols)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.matrix[rows, cols] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new ArgumentException("Only matrices with same dimensions can be accumulated");
            }

            Matrix<T> result = new Matrix<T>(first.Rows, first.Cols);
            for (int i = 0; i < first.Rows; i++)
            {
                for (int j = 0; j < first.Cols; j++)
                {
                    result[i, j] = (dynamic)first.matrix[i, j] + second.matrix[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new ArgumentException("Only matrices with same dimensions can be subtracted.");
            }

            Matrix<T> result = new Matrix<T>(first.Rows, first.Cols);
            for (int i = 0; i < first.Rows; i++)
            {
                for (int j = 0; j < first.Cols; j++)
                {
                    result[i, j] = (dynamic)first.matrix[i, j] - second.matrix[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Cols || first.Cols != second.Rows)
            {
                throw new ArgumentException("Matrices are with invalid dimensions.");
            }

            Matrix<T> result = new Matrix<T>();
            for (int i = 0; i < first.Rows; i++)
            {
                for (int j = 0; j < second.Cols; j++)
                {
                    dynamic sum = 0;
                    for (int k = 0; k < second.Cols; k++)
                    {
                        sum += (dynamic)first.matrix[i, k] * second.matrix[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }

        //Returns true if zero-element is found in matrix
        public static bool operator true(Matrix<T> m)
        {
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    if (m.matrix[i, j].CompareTo(default(T)) == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //false operator is required when operator true is implemented
        public static bool operator false(Matrix<T> m)
        {
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    if (m.matrix[i, j].CompareTo(default(T)) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
    }


    class Test
    {
        static void Main() { }
    }
}
