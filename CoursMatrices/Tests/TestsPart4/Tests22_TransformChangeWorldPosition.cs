using CoursMatrices.Structs;

namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture, DefaultFloatingPointTolerance(0.001d)]
    public class Tests22TransformChangeWorldPosition
    {
        [Test]
        public void TestChangeWorldPosition()
        {
            Transform t = new()
            {
                WorldPosition = new Vector3(100f, 1f, 42f)
            };

            Assert.That(new[,]
            {
                { 1f, 0f, 0f, 100f },
                { 0f, 1f, 0f, 1f },
                { 0f, 0f, 1f, 42f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalToWorldMatrix.ToArray2D()));

            Assert.That(100f, Is.EqualTo(t.LocalPosition.x));
            Assert.That(1f, Is.EqualTo(t.LocalPosition.y));
            Assert.That(42f, Is.EqualTo(t.LocalPosition.z));
        }

        [Test]
        public void TestChangeWorldPositionInsideParent()
        {
            Transform tParent = new()
            {
                LocalPosition = new Vector3(100f, 1f, 42f)
            };

            Transform tChild = new();
            tChild.SetParent(tParent);
            tChild.WorldPosition = new Vector3(0f, 0f, 0f);
            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(tChild.LocalToWorldMatrix.ToArray2D()));

                Assert.That(tChild.LocalPosition.x, Is.EqualTo(-100f));
                Assert.That(tChild.LocalPosition.y, Is.EqualTo(-1f));
                Assert.That(tChild.LocalPosition.z, Is.EqualTo(-42f));
            });
        }
        
        [Test]
        public void TestChangeWorldPositionInsideParentWithRotation()
        {
            Transform tParent = new()
            {
                LocalPosition = new Vector3(20f, 0f, 0f),
                LocalRotation = new Vector3(0f, 0f, 45f)
            };

            Transform tChild = new();
            tChild.SetParent(tParent);
            tChild.WorldPosition = new Vector3(0f, 0f, 0f);
            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                {
                { 0.707f, -0.707f, 0f, 0f },
                { 0.707f, 0.707f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(tChild.LocalToWorldMatrix.ToArray2D()));

                Assert.That(tChild.LocalPosition.x, Is.EqualTo(-14.142f));
                Assert.That(tChild.LocalPosition.y, Is.EqualTo(14.142f));
                Assert.That(tChild.LocalPosition.z, Is.EqualTo(0f));
            });
        }
        
        [Test]
        public void TestChangeWorldPositionInsideParentWithScale()
        {
            Transform tParent = new()
            {
                LocalPosition = new Vector3(200, -10f, 9f),
                LocalScale = new Vector3(2f, 4f, 6f)
            };

            Transform tChild = new();
            tChild.SetParent(tParent);
            tChild.WorldPosition = new Vector3(0f, 0f, 0f);
            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                {
                { 2f, 0f, 0f, 0f },
                { 0f, 4f, 0f, 0f },
                { 0f, 0f, 6f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(tChild.LocalToWorldMatrix.ToArray2D()));

                Assert.That(tChild.LocalPosition.x, Is.EqualTo(-100f));
                Assert.That(tChild.LocalPosition.y, Is.EqualTo(2.5f));
                Assert.That(tChild.LocalPosition.z, Is.EqualTo(-1.5f));
            });
        }
    }
}