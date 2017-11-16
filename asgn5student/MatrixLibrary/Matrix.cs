﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asgn5v1.MatrixLibrary
{
    class Matrix
    {
        private int columns;
        private int rows;
        private double[,] matrix;

        public Matrix (int columns, int rows)
        {
            this.columns = columns;
            this.rows = rows;
            this.matrix = new double[columns, rows];
        }

        public Matrix (int columns, int rows, double [,] matrix)
        {
            this.columns = columns;
            this.rows = rows;
            this.matrix = matrix;
        }

        public void setColumns (int columns)
        {
            this.columns = columns;
            this.matrix = new double[columns, rows];
        }
        
        public void setRows (int rows)
        {
            this.rows = rows;
            this.matrix = new double[columns, rows];
        }

        public void setMatrix(double[,] matrix, int x, int y)
        {
            this.matrix = matrix;
            columns = x;
            rows = y;
        }

        public int getColumns ()
        {
            return columns;
        }

        public int getRows ()
        {
            return rows;
        }

        public double[,] getMatrix()
        {
            return this.matrix;
        }

        public void insertValue (int x, int y, double value)
        {
            this.matrix[x, y] = value;
        }

        public double getValue (int x, int y)
        {
            return this.matrix[x, y];
        }

        public static Matrix operator+ (Matrix a, Matrix b)
        {
            if (a == null || b == null || a.getColumns() != b.getColumns() || a.getRows() != b.getRows())
            {
                return null;
            }

            int width = a.getColumns();
            int height = b.getRows();

            Matrix c = new Matrix(width, height);

            double value = 0;

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    value = a.getValue(x, y) + b.getValue(x, y);
                    c.insertValue(x, y, value);
                }
            }

            return c;
        }

        public static Matrix operator- (Matrix a, Matrix b)
        {
            if (a == null || b == null || a.getColumns() != b.getColumns() || a.getRows() != b.getRows())
            {
                return null;
            }

            int width = a.getColumns();
            int height = b.getRows();

            Matrix c = new Matrix(width, height);

            double value = 0;

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    value = a.getValue(x, y) - b.getValue(x, y);
                    c.insertValue(x, y, value);
                }
            }

            return c;
        }

        public static Matrix operator* (Matrix a, Matrix b)
        {
            if (a == null || b == null || a.getColumns() != b.getRows())
            {
                return null;
            }

            int width = b.getColumns();
            int height = a.getRows();
            int colLength = a.getColumns();

            Matrix c = new Matrix(width, height);

            double value = 0;

            for (int row = 0; row < width; ++row)
            {
                for (int col = 0; col < height; ++col)
                {
                    for (int ndx = 0; ndx < colLength; ++ndx)
                    {
                        value = c.getValue(row, col);
                        value += a.getValue(ndx, col) * b.getValue(row, ndx);
                        c.insertValue(row, col, value);
                    }
                }
            }
            return c;
        }

        public static bool operator== (Matrix a, Matrix b)
        {

            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null || a.getColumns() != b.getColumns() || a.getRows() != b.getRows())
            {
                return false;
            }

            int width = a.getColumns();
            int height = a.getRows();
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    if (a.getValue(i, j) != b.getValue(i, j))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            if (a == null && b == null)
            {
                return false;
            }

            if (a == null || b == null || a.getColumns() != b.getColumns() || a.getRows() != b.getRows())
            {
                return true;
            }

            int width = a.getColumns();
            int height = a.getRows();
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    if (a.getValue(i, j) != b.getValue(i, j))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void printMatrix()
        {
            for (int y = 0; y < rows; ++y)
            {
                Console.Write("[");
                for (int x = 0; x < columns; ++x)
                {
                    Console.Write(this.matrix[x, y] + " ");
                }
                Console.WriteLine("]");
            }

        }

        public override bool Equals(object obj)
        {
            var matrix = obj as Matrix;
            return matrix != null &&
                   columns == matrix.columns &&
                   rows == matrix.rows &&
                   EqualityComparer<double[,]>.Default.Equals(this.matrix, matrix.matrix);
        }

        public override int GetHashCode()
        {
            var hashCode = -2012147648;
            hashCode = hashCode * -1521134295 + columns.GetHashCode();
            hashCode = hashCode * -1521134295 + rows.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<double[,]>.Default.GetHashCode(matrix);
            return hashCode;
        }
    }
}
