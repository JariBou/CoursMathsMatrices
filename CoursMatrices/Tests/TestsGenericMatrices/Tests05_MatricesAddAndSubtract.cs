using CoursMatrices.Exceptions;
using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices.Tests.TestsGenericMatrices
{
    [TestFixture]
    public class Tests05_MatricesAddAndSubtractGeneric
    {
        [Test]
        public void TestSumMatricesInstances()
        {
            Matrix<int> m1 = new(new[,]
            {
                { 1, 7 },
                { 8, 5 },
                { 4, 17 }
            });

            Matrix<int> m2 = new(new[,]
            {
                { 65, 4 },
                { 3, 1 },
                { 48, 2 }
            });

            m1.Add(m2);

            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                        {
                { 66, 11 },
                { 11, 6 },
                { 52, 19 },
            }, Is.EqualTo(m1.ToArray2D()));

                Assert.That(new[,]
                {
                { 65, 4 },
                { 3, 1 },
                { 48, 2 }
            }, Is.EqualTo(m2.ToArray2D()));
            });
        }
        
        [Test]
        public void TestSumMatricesStatic()
        {
            Matrix<int> m1 = new Matrix<int>(new[,]
            {
                { 1, 7 },
                { 8, 5 },
                { 4, 17 }
            });

            Matrix<int> m2 = new Matrix<int>(new[,]
            {
                { 65, 4 },
                { 3, 1 },
                { 48, 2 }
            });

            Matrix<int> m3 = MatrixOperations.Add(m1, m2);

            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                        {
                { 66, 11 },
                { 11, 6 },
                { 52, 19 },
            }, Is.EqualTo(m3.ToArray2D()));

                Assert.That(new[,]
                {
                { 1, 7 },
                { 8, 5 },
                { 4, 17 }
            }, Is.EqualTo(m1.ToArray2D()));

                Assert.That(new[,]
                {
                { 65, 4 },
                { 3, 1 },
                { 48, 2 }
            }, Is.EqualTo(m2.ToArray2D()));
            });
        }
        
        [Test]
        public void TestSumMatricesOperator()
        {
            Matrix<int> m1 = new Matrix<int>(new[,]
            {
                { 1, 7 },
                { 8, 5 },
                { 4, 17 }
            });

            Matrix<int> m2 = new Matrix<int>(new[,]
            {
                { 65, 4 },
                { 3, 1 },
                { 48, 2 }
            });

            Matrix<int> m3 = m1 + m2;

            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                        {
                { 66, 11 },
                { 11, 6 },
                { 52, 19 },
            }, Is.EqualTo(m3.ToArray2D()));

                Assert.That(new[,]
                {
                { 1, 7 },
                { 8, 5 },
                { 4, 17 }
            }, Is.EqualTo(m1.ToArray2D()));

                Assert.That(new[,]
                {
                { 65, 4 },
                { 3, 1 },
                { 48, 2 }
            }, Is.EqualTo(m2.ToArray2D()));
            });
        }

        [Test]
        public void TestSubtractMatricesOperator()
        {
            Matrix<int> m1 = new Matrix<int>(new[,]
            {
                { 1, 62 },
                { 17, 2 },
                { 3, 5 },
            });

            Matrix<int> m2 = new Matrix<int>(new[,]
            {
                {-3, 51},
                {9, 1},
                {4, 18},
            });

            Matrix<int> m3 = m1 - m2;

            Assert.That(new[,]
            {
                { 4, 11 },
                { 8, 1 },
                { -1, -13 },
            }, Is.EqualTo(m3.ToArray2D()));
        }
        
        [Test]
        public void TestImpossibleSumMatrices()
        {
            Matrix<int> m1 = new Matrix<int>(new[,]
            {
                { 3, 4 },
                { 8, 5 },
            });

            Matrix<int> m2 = new Matrix<int>(new[,]
            {
                { 1, 7 },
                { 7, 4 },
                { 2, 0 },
            });
            
            //Add Methods need to throw exception if size are different
            //See Exception Documentation =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/fundamentals/exceptions/
            //https://docs.microsoft.com/fr-fr/dotnet/api/system.exception?view=net-6.0
            
            Assert.Throws<MatrixSizeOperationException>(() =>
            {
                m1.Add(m2);
            });
            
            Assert.Throws<MatrixSizeOperationException>(() =>
            {
                MatrixOperations.Add(m1, m2);
            });
            
            Assert.Throws<MatrixSizeOperationException>(() =>
            {
                Matrix<int> m3 = m1 + m2;
            });
        }
    }
}