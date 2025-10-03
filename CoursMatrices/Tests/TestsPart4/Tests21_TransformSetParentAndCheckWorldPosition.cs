namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture, DefaultFloatingPointTolerance(0.001d)]
    public class Tests21TransformSetParentAndCheckWorldPosition
    {
        [Test]
        public void TestParentChangePosition()
        {
            Transform tParent = new()
            {
                LocalPosition = new Vector3(10f, 5f, 2f)
            };

            Transform tChild = new();
            tChild.SetParent(tParent);
            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                {
                    { 1f, 0f, 0f, 10f },
                    { 0f, 1f, 0f, 5f },
                    { 0f, 0f, 1f, 2f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(tParent.LocalToWorldMatrix.ToArray2D()));

                Assert.That(tParent.WorldPosition.x, Is.EqualTo(10f));
                Assert.That(tParent.WorldPosition.y, Is.EqualTo(5f));
                Assert.That(tParent.WorldPosition.z, Is.EqualTo(2f));
            });

            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                {
                    { 1f, 0f, 0f, 10f },
                    { 0f, 1f, 0f, 5f },
                    { 0f, 0f, 1f, 2f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(tChild.LocalToWorldMatrix.ToArray2D()));

                Assert.That(tChild.WorldPosition.x, Is.EqualTo(10f));
                Assert.That(tChild.WorldPosition.y, Is.EqualTo(5f));
                Assert.That(tChild.WorldPosition.z, Is.EqualTo(2f));
            });
        }
        
        [Test]
        public void TestDoubleParentChangePosition()
        {
            //tRoot (10,5,2)
            //  -> tParent (1,4,42) => (11,9,44)
            //      -> tChild (1,2,3) => (12,11,47)
            
            Transform tRoot = new()
            {
                LocalPosition = new Vector3(10f, 5f, 2f)
            };

            Transform tParent = new()
            {
                LocalPosition = new Vector3(1f, 4f, 42f)
            };
            tParent.SetParent(tRoot);
        
            Transform tChild = new()
            {
                LocalPosition = new Vector3(-1f, 2f, 3f)
            };
            tChild.SetParent(tParent);
            Assert.Multiple(() =>
            {

                //Check tParent Matrix and World Position
                Assert.That(new[,]
                {
                { 1f, 0f, 0f, 11f },
                { 0f, 1f, 0f, 9f },
                { 0f, 0f, 1f, 44f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(tParent.LocalToWorldMatrix.ToArray2D()));

                Assert.That(tParent.WorldPosition.x, Is.EqualTo(11f));
                Assert.That(tParent.WorldPosition.y, Is.EqualTo(9f));
                Assert.That(tParent.WorldPosition.z, Is.EqualTo(44f));

                //Check tChild Matrix and World Position
                Assert.That(new[,]
                {
                { 1f, 0f, 0f, 10f },
                { 0f, 1f, 0f, 11f },
                { 0f, 0f, 1f, 47f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(tChild.LocalToWorldMatrix.ToArray2D()));

                Assert.That(tChild.WorldPosition.x, Is.EqualTo(10f));
                Assert.That(tChild.WorldPosition.y, Is.EqualTo(11f));
                Assert.That(tChild.WorldPosition.z, Is.EqualTo(47f));
            });
        }
        
        [Test]
        public void TestParentChangePositionAndRotation()
        {
            Transform tParent = new()
            {
                LocalPosition = new Vector3(10f, 5f, 2f),
                LocalRotation = new Vector3(0f, 0f, 45f)
            };

            Transform tChild = new()
            {
                LocalPosition = new Vector3(1f, 0f, 0f)
            };
            tChild.SetParent(tParent);
            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                {
                { 0.707f, -0.707f, 0.000f, 10.707f },
                { 0.707f, 0.707f, 0.000f, 5.707f },
                { 0.000f, 0.000f, 1.000f, 2.000f },
                { 0.000f, 0.000f, 0.000f, 1.000f },
            }, Is.EqualTo(tChild.LocalToWorldMatrix.ToArray2D()));

                Assert.That(tChild.WorldPosition.x, Is.EqualTo(10.707f));
                Assert.That(tChild.WorldPosition.y, Is.EqualTo(5.707f));
                Assert.That(tChild.WorldPosition.z, Is.EqualTo(2f));
            });
        }
        
        [Test]
        public void TestParentChangePositionAndScale()
        {
            Transform tParent = new()
            {
                LocalPosition = new Vector3(100f, 0f, -20f),
                LocalScale = new Vector3(2f, 4f, 6f)
            };

            Transform tChild = new()
            {
                LocalPosition = new Vector3(1f, 1f, 1f)
            };
            tChild.SetParent(tParent);
            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                {
                { 2f, 0f, 0f, 102f },
                { 0f, 4f, 0f, 4f },
                { 0f, 0f, 6f, -14f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(tChild.LocalToWorldMatrix.ToArray2D()));

                Assert.That(tChild.WorldPosition.x, Is.EqualTo(102f));
                Assert.That(tChild.WorldPosition.y, Is.EqualTo(4f));
                Assert.That(tChild.WorldPosition.z, Is.EqualTo(-14f));
            });
        }
    }
}
