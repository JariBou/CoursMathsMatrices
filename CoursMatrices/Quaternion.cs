using CoursMatrices.Matrices.Generic;

namespace CoursMatrices;

public struct Quaternion(float x, float y, float z, float w)
{
    public float x = x;
    public float y = y;
    public float z = z;
    public float w = w;

    public Matrix<float> Matrix => new(new[,]
    {
        { 1 - 2*y*y - 2*z*z , 2*x*y - 2*w*z     , 2*x*z + 2*w*y     , 0  },
        { 2*x*y + 2*w*z     , 1 - 2*x*x - 2*z*z , 2*y*z - 2*w*x     , 0f },
        { 2*x*z - 2*w*y     , 2*y*z + 2*w*x     , 1 - 2*x*x - 2*y*y , 0f },
        { 0f                , 0f                , 0f                , 1f },
    });

    public Quaternion Conjugate() => new(-x, -y, -z, w);
    public Quaternion Inverse() => Conjugate() / SqrMagnitude();
    
    public float Magnitude() => MathF.Sqrt(x*x + y*y + z*z + w*w);
    public float SqrMagnitude() => x*x + y*y + z*z + w*w;
    
    public static Quaternion Identity => new(0, 0, 0, 1);

    public static Quaternion AngleAxis(float angle, Vector3 axis)
    {
        axis = axis.Normalize();
        float cos = MathF.Cos(angle/2 * Utils.Math.Deg2Rad);
        float sin = MathF.Sin(angle/2 * Utils.Math.Deg2Rad);

        return new Quaternion(axis.x * sin, axis.y * sin, axis.z * sin, cos);
    }

    public static Quaternion operator *(Quaternion a, Quaternion b)
    {
        float w = a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z;
        float x = a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y;
        float y = a.w * b.y - a.x * b.z + a.y * b.w + a.z * b.x;
        float z = a.w * b.z + a.x * b.y - a.y * b.x + a.z * b.w;
        
        return new Quaternion(x, y, z, w);
    }
    
    public static Quaternion operator *(Quaternion a, float b)
    {
        return new Quaternion(a.x*b, a.y*b, a.z*b, a.w*b);
    }
    
    public static Quaternion operator /(Quaternion a, float b)
    {
        return new Quaternion(a.x/b, a.y/b, a.z/b, a.w/b);
    }
    
    public static Vector3 operator *(Quaternion a, Vector3 b)
    {
        Quaternion vectorQuaternion = new(b.x, b.y, b.z, 0);
        Quaternion quaternion = a * vectorQuaternion * a.Inverse();
        return new Vector3(quaternion.x, quaternion.y, quaternion.z);
    }
}