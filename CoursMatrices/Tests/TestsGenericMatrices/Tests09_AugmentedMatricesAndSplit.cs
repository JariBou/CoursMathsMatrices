using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices.Tests.TestsGenericMatrices
{
    [TestFixture]
    public class Tests09_AugmentedMatricesAndSplitGeneric
    {
        [Test]
        public void TestGenerateAugmentedMatrix()
        {
            Matrix<int> m1 = new(new[,]
            {
                { 3, 2, -3 },
                { 4, -3, 6 },
                { 1, 0, -1 }
            });

            Matrix<int> m2 = new(new[,]
            {
                { -13 },
                { 7 },
                { -5 }
            });

            Matrix<int> augmentedMatrix = MatrixOperations.GenerateAugmentedMatrix(m1, m2);
            Assert.That(new[,]
            {
                { 3, 2, -3, -13 },
                { 4, -3, 6, 7 },
                { 1, 0, -1, -5 }
            }, Is.EqualTo(augmentedMatrix.ToArray2D()));
        }

        [Test]
        public void TestSplitMatrix()
        {
            Matrix<int> m = new(new[,]
            {
                { 2, 1, 3, 0 },
                { 0, 1, -1, 0 },
                { 1, 3, -1, 0 }
            });
        
            //This method use deconstruction tuple system
            //More information here =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/fundamentals/functional/deconstruct
            (Matrix<int> m1, Matrix<int> m2) = m.Split(2);
        
            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                        {
                { 2, 1, 3 },
                { 0, 1, -1 },
                { 1, 3, -1 }
            }, Is.EqualTo(m1.ToArray2D()));
        
                Assert.That(new[,]
                {
                { 0 },
                { 0 },
                { 0 }
            }, Is.EqualTo(m2.ToArray2D()));
            });
        }
    }
}