using CoursMatrices.Matrices;

namespace CoursMatrices.Tests.NonGeneric
{
    [TestFixture]
    public class Tests03IdentityMatrices
    {
        [Test]
        public void TestGenerateIdentityMatrices()
        {
            MatrixInt identity2 = MatrixInt.Identity(2);
            MatrixInt identity3 = MatrixInt.Identity(3);
            MatrixInt identity4 = MatrixInt.Identity(4);
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
            MatrixInt identity2 = new(new[,]
            {
                { 1, 0 },
                { 0, 1 }
            });
            MatrixInt identity3 = new(new[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            });
            MatrixInt notSameColumnsAndLines = new(new[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 }
            });
            MatrixInt notIdentity1 = new(new[,]
            {
                { 1, 0, 0 },
                { 0, 2, 0 },
                { 0, 0, 3 },
            });
            MatrixInt notIdentity2 = new(new[,]
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