using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices.Tests.TestsGenericMatrices
{
    [TestFixture]
    public class Tests04ScalarMultiplicationGeneric
    {
        [Test]
        public void TestScalarMultiplicationInstance()
        {
            Matrix<int> m = new(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            });

            m.Multiply(2);

            Assert.That(new[,]
            {
                { 2, 4, 6 },
                { 8, 10, 12 },
                { 14, 16, 18 },
            }, Is.EqualTo(m.ToArray2D()));
        }

        [Test]
        public void TestScalarMultiplicationStatic()
        {
            Matrix<int> m = new(new[,]
            {
                { 0, 0, 0 },
                { 0, 5, 0 },
                { 0, 0, 0 }
            });

            Matrix<int> m2 = MatrixOperations.Multiply(m, 5);

            Assert.That(new[,]
            {
                { 0, 0, 0 },
                { 0, 25, 0 },
                { 0, 0, 0 },
            }, Is.EqualTo(m2.ToArray2D()));

            Assert.That(new[,]
            {
                { 0, 0, 0 },
                { 0, 5, 0 },
                { 0, 0, 0 },
            }, Is.EqualTo(m.ToArray2D()));
        }

        [Test]
        public void TestScalarMultiplicationOperator()
        {
            Matrix<int> m = new(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            });

            //See Operator overloading documentation =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/operators/operator-overloading
            Matrix<int> m2 = m * 2;

            Assert.That(new[,]
            {
                { 2, 4, 6 },
                { 8, 10, 12 },
                { 14, 16, 18 },
            }, Is.EqualTo(m2.ToArray2D()));

            Assert.That(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            }, Is.EqualTo(m.ToArray2D()));

            Matrix<int> m4 = 4 * m;

            Assert.That(new[,]
            {
                { 4, 8, 12 },
                { 16, 20, 24 },
                { 28, 32, 36 },
            }, Is.EqualTo(m4.ToArray2D()));
        }

        [Test]
        public void TestNegativeMatrix()
        {
            Matrix<int> m1 = new(new int[,]
            {
                { -1, 2, 3 },
                { 4, -5, 6 },
                { -7, 8, 9 }
            });

            Matrix<int> m2 = -m1;

            Assert.That(new[,]
            {
                { 1, -2, -3 },
                { -4, 5, -6 },
                { 7, -8, -9 }
            }, Is.EqualTo(m2.ToArray2D()));
        }
    }
}