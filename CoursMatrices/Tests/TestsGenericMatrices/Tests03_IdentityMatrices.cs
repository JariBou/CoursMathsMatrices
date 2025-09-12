using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices.Tests.TestsGenericMatrices
{
    [TestFixture]
    public class Tests03_IdentityMatricesGeneric
    {
        [Test]
        public void TestGenerateIdentityMatrices()
        {
            Matrix<int> identity2 = MatrixOperations.Identity<int>(2);
            Matrix<int> identity3 = MatrixOperations.Identity<int>(3);
            Matrix<int> identity4 = MatrixOperations.Identity<int>(4);
            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                {
                { 1, 0 },
                { 0, 1 },
            }, Is.EqualTo(identity2.ToArray2D()));

                Assert.That(new[,]
                {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 },
            }, Is.EqualTo(identity3.ToArray2D()));

                Assert.That(new[,]
                {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 },
            }, Is.EqualTo(identity4.ToArray2D()));
            });
        }

        [Test]
        public void TestMatricesIsIdentity()
        {
            Matrix<int> identity2 = new(new[,]
            {
                { 1, 0 },
                { 0, 1 }
            });
            Matrix<int> identity3 = new(new[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            });
            Matrix<int> notSameColumnsAndLines = new(new[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 }
            });
            Matrix<int> notIdentity1 = new(new[,]
            {
                { 1, 0, 0 },
                { 0, 2, 0 },
                { 0, 0, 3 },
            });
            Matrix<int> notIdentity2 = new(new[,]
            {
                { 1, 0, 4 },
                { 0, 1, 0 },
                { 0, 0, 1 },
            });
            
            Assert.Multiple(() =>
            {
                Assert.That(identity2.IsIdentity());

                Assert.That(identity3.IsIdentity());

                Assert.That(notSameColumnsAndLines.IsIdentity(), Is.False);
                
                Assert.That(notIdentity1.IsIdentity(), Is.False);

                Assert.That(notIdentity2.IsIdentity(), Is.False);
            });
        }
    }
}