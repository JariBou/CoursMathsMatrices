using CoursMatrices.Matrices;
using CoursMatrices.Matrices.Generic;

namespace CoursMatrices.TestsGeneric
{
    [TestFixture]
    public class Tests01_NewMatricesGeneric
    {
        [Test]
        public void TestNewEmptyMatrices()
        {
            Matrix<int> m1 = new(3, 2);
            Matrix<int> m2 = new(2, 3);
            
            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                {
                { 0, 0 },
                { 0, 0 },
                { 0, 0 }
            }, Is.EqualTo(m1.ToArray2D()));
                Assert.That(m1.RowCount, Is.EqualTo(3));
                Assert.That(m1.ColumnCount, Is.EqualTo(2));

                Assert.That(new[,]
                {
                { 0, 0, 0 },
                { 0, 0, 0 },
            }, Is.EqualTo(m2.ToArray2D()));
                Assert.That(m2.RowCount, Is.EqualTo(2));
                Assert.That(m2.ColumnCount, Is.EqualTo(3));
            });
        }

        [Test]
        public void TestNewMatricesFrom2DArray()
        {
            //See GetLength documentation to retrieve length of a multi-dimensional array
            //https://docs.microsoft.com/en-us/dotnet/api/system.array.getlength
            Matrix<int> m = new(new[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 },
                }
            );
            Assert.Multiple(() =>
            {
                Assert.That(m.RowCount, Is.EqualTo(3));
                Assert.That(m.ColumnCount, Is.EqualTo(3));

                //See Indexers Documentation =>
                //https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/indexers/
                Assert.That(m[0, 0], Is.EqualTo(1));
                Assert.That(m[0, 1], Is.EqualTo(2));
                Assert.That(m[0, 2], Is.EqualTo(3));
                Assert.That(m[1, 0], Is.EqualTo(4));
                Assert.That(m[1, 1], Is.EqualTo(5));
                Assert.That(m[1, 2], Is.EqualTo(6));
                Assert.That(m[2, 0], Is.EqualTo(7));
                Assert.That(m[2, 1], Is.EqualTo(8));
                Assert.That(m[2, 2], Is.EqualTo(9));
            });
        }
    }
}