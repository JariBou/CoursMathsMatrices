using CoursMatrices.Matrices;

namespace CoursMatrices.Tests.NonGeneric
{
    [TestFixture]
    public class Tests02CopyAndModifyMatrices
    {
        [Test]
        public void TestModifyMatrix()
        {
            MatrixInt m = new(2, 2);
            
            
            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                {
                    { 0, 0 },
                    { 0, 0 },
                }, Is.EqualTo(m.ToArray2D()));

                //See Indexers Documentation =>
                //https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/indexers/
                m[0, 0] = 1;
                m[0, 1] = 2;
                m[1, 0] = 3;
                m[1, 1] = 4;
                
                Assert.That(new[,]
                {
                    { 1, 2 },
                    { 3, 4 },
                }, Is.EqualTo(m.ToArray2D()));
            });
        }

        [Test]
        public void TestCopyAndChangeMatrices()
        {
            MatrixInt m1 = new(new[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 },
                }
            );

            MatrixInt m2 = new(m1);
            m2[0, 0] = 23;

            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                        {
                { 23, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
            }, Is.EqualTo(m2.ToArray2D()));

                Assert.That(new[,]
                {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
            }, Is.EqualTo(m1.ToArray2D()));
            });
        }
    }
}