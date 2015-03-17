/* Problem 8. Matrix
 * Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals).
 * 
 * Problem 9. Matrix indexer
 * Implement an indexer this[row, col] to access the inner matrix cells.
 * 
 * Problem 10. Matrix operations
    Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
    Throw an exception when the operation cannot be performed.
    Implement the true operator (check for non-zero elements).

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes_Part2
{
    public class Matrix<T> where T : struct
    {
        private T[,] matrica;
        /// <summary>
        /// Matrix rows , cols.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public Matrix(int row, int col)
        {
            matrica = new T[row, col];
        }
        public T this[int row, int col]  // problem 9
        {

            get
            {
                if (row >= matrica.GetLength(0) || col >= matrica.GetLength(1))
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }
                return matrica[row, col];
            }
            set
            {
                if (row >= matrica.GetLength(0) || col >= matrica.GetLength(1))
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }
                matrica[row, col] = value;

            }
        }
        /// <summary>
        /// The two matrices must be with equal rows and cols.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)  // if rows or cols are different , no operator implement
        {
            if (a.matrica.GetLength(0) != b.matrica.GetLength(0) || a.matrica.GetLength(1) != b.matrica.GetLength(1))
            {
                throw new ArgumentException("Different rows or cols. The dimmesions must be same!");
            }
            int rowlenght = a.matrica.GetLength(0);
            int collenght = a.matrica.GetLength(1);

            Matrix<T> result = new Matrix<T>(rowlenght, collenght);

            for (int row = 0; row < a.matrica.GetLength(0); row++)  // they are equal so...
            {
                for (int col = 0; col < a.matrica.GetLength(1); col++)
                {

                    result[row, col] = (dynamic)a[row, col] + (dynamic)b[row, col];

                }
            }
            return result;
        }
        /// <summary>
        /// The two matrices must be with equal rows and cols.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)  // if rows or cols are different , no operator implement
        {
            if (a.matrica.GetLength(0) != b.matrica.GetLength(0) || a.matrica.GetLength(1) != b.matrica.GetLength(1))
            {
                throw new ArgumentException("Different rows or cols. The dimmesions must be same!");
            }
            int rowlenght = a.matrica.GetLength(0);
            int collenght = a.matrica.GetLength(1);

            Matrix<T> result = new Matrix<T>(rowlenght, collenght);

            for (int row = 0; row < a.matrica.GetLength(0); row++)  // they are equal so...
            {
                for (int col = 0; col < a.matrica.GetLength(1); col++)
                {

                    result[row, col] = (dynamic)a[row, col] - (dynamic)b[row, col];

                }
            }
            return result;
        }

        /// <summary>
        /// Matrix multiplication. First matrix columns = second matrix rows.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            if (a.matrica.GetLength(1) != b.matrica.GetLength(0))   // logic based on http://matrix.reshish.com/multCalculation.php
            {
                throw new ArgumentException("Columns of first matrix must be equal to rows of second Matrix.");
            }
            int rows = a.matrica.GetLength(0);
            int cols = b.matrica.GetLength(1);
            Matrix<T> result = new Matrix<T>(rows, cols);
            for (int row = 0; row < result.matrica.GetLength(0); row++)
            {
                for (int col = 0; col < result.matrica.GetLength(1); col++)
                {

                    result[row, col] = Summ(row, col, a, b);
                }
            }
            return result;
        }
        /// <summary>
        /// To check matrix is contains non zero elements.
        /// </summary>
        /// <param name="mmm"></param>
        /// <returns></returns>
        public static bool operator true(Matrix<T> mmm) // problem 10
        {
            for (int row = 0; row < mmm.matrica.GetLength(0); row++)
            {
                for (int col = 0; col < mmm.matrica.GetLength(1); col++)
                {
                    if (mmm.matrica[row,col] == (dynamic)0)
                    {
                        return false;
                       
                    }
                }
            }
            return true;
        }
        public static bool operator false(Matrix<T> mmm)
        {
            for (int row = 0; row < mmm.matrica.GetLength(0); row++)
            {
                for (int col = 0; col < mmm.matrica.GetLength(1); col++)
                {
                    if (mmm.matrica[row, col] == (dynamic)0)
                    {
                        return true;
                        
                    }
                }
            }
            return false;
        }
        private static T Summ(int row, int col, Matrix<T> a, Matrix<T> b) // a redowe , b coloni
        {
            T sum = (dynamic)0;
            for (int iA = 0, jB = 0; iA < a.matrica.GetLength(1); iA++, jB++)
            {
                sum += (dynamic)a.matrica[row, iA] * (dynamic)b.matrica[jB, col];
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < matrica.GetLength(0); row++)
            {
                for (int col = 0; col < matrica.GetLength(1); col++)
                {
                    result.AppendFormat("{0,10} ", matrica[row, col]);
                }
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
