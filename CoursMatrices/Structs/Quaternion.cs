using System.Diagnostics.CodeAnalysis;
using CoursMatrices.Matrices.Generic;

namespace CoursMatrices.Structs;

public struct Quaternion
{
    private float _x;
    private float _y;
    private float _z;
    private float _w;

    private Matrix<float> _matrix;
    private bool _isMatrixDirty;
    
    private Vector3 _eulerAngles;
    private bool _isEulerAnglesDirty;

    public Quaternion(float x, float y, float z, float w)
    {
        _x = x;
        _y = y;
        _z = z;
        _w = w;
        
        // I could just set dirty but then resharper annoys me with warnings because i.e: _matrix would be nullable
        // and it would make me use the ! nullable operator which I don't like 
        RecalculateMatrix();
        RecalculateEulerAngles();
    }

    public Matrix<float> Matrix
    {
        get
        {
            if (_isMatrixDirty) RecalculateMatrix();
            
            return _matrix;
        }
    }

    public Vector3 EulerAngles
    {
        get {
            if (_isEulerAnglesDirty) RecalculateEulerAngles();
            
            return _eulerAngles;
        }
    }

    // Changed public fields to properties to be able to set the matrix dirty to cache it, hope it's fine
    public float X
    {
        get => _x;
        set
        {
            _x = value;
            SetMatrixDirty();
        }
    }

    public float Y
    {
        get => _y;
        set
        {
            _y = value;
            SetMatrixDirty();
        }
    }

    public float Z
    {
        get => _z;
        set
        {
            _z = value;
            SetMatrixDirty();
        }
    }

    public float W
    {
        get => _w;
        set
        {
            _w = value;
            SetMatrixDirty();
        }
    }

    public Quaternion Conjugate() => new(-X, -Y, -Z, W);
    public Quaternion Inverse() => Conjugate() / SqrMagnitude();
    
    public float Magnitude() => MathF.Sqrt(X*X + Y*Y + Z*Z + W*W);
    public float SqrMagnitude() => X*X + Y*Y + Z*Z + W*W;
    
    public static Quaternion Identity => new(0, 0, 0, 1);

    public static Quaternion AngleAxis(float angle, Vector3 axis)
    {
        axis = axis.Normalize();
        float cos = MathF.Cos(angle/2 * Utils.Math.Deg2Rad);
        float sin = MathF.Sin(angle/2 * Utils.Math.Deg2Rad);

        return new Quaternion(axis.x * sin, axis.y * sin, axis.z * sin, cos);
    }
    
    public static Quaternion Euler(float x, float y, float z)
    {
        // return AngleAxis(z, Vector3.ZAxis) * AngleAxis(y, Vector3.XAxis) * AngleAxis(x, Vector3.XAxis);
        return AngleAxis(y, Vector3.YAxis) * AngleAxis(x, Vector3.XAxis) * AngleAxis(z, Vector3.ZAxis);
    }

    public static Quaternion Euler(Vector3 localRotation)
    {
        return Euler(localRotation.x, localRotation.y, localRotation.z);
    }

    #region Operators
    
    public static Quaternion operator *(Quaternion a, Quaternion b)
    {
        float w = a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z;
        float x = a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y;
        float y = a.W * b.Y - a.X * b.Z + a.Y * b.W + a.Z * b.X;
        float z = a.W * b.Z + a.X * b.Y - a.Y * b.X + a.Z * b.W;
        
        return new Quaternion(x, y, z, w);
    }
    
    public static Quaternion operator *(Quaternion a, float b)
    {
        return new Quaternion(a.X*b, a.Y*b, a.Z*b, a.W*b);
    }
    
    public static Quaternion operator /(Quaternion a, float b)
    {
        return new Quaternion(a.X/b, a.Y/b, a.Z/b, a.W/b);
    }
    
    public static Vector3 operator *(Quaternion a, Vector3 b)
    {
        Quaternion vectorQuaternion = new(b.x, b.y, b.z, 0);
        Quaternion quaternion = a * vectorQuaternion * a.Inverse();
        return new Vector3(quaternion.X, quaternion.Y, quaternion.Z);
    }
    
    #endregion

    [MemberNotNull(nameof(_matrix))]
    private void RecalculateMatrix()
    {
        _matrix = new Matrix<float>(new[,]
        {
            { 1 - 2*Y*Y - 2*Z*Z , 2*X*Y - 2*W*Z     , 2*X*Z + 2*W*Y     , 0  },
            { 2*X*Y + 2*W*Z     , 1 - 2*X*X - 2*Z*Z , 2*Y*Z - 2*W*X     , 0f },
            { 2*X*Z - 2*W*Y     , 2*Y*Z + 2*W*X     , 1 - 2*X*X - 2*Y*Y , 0f },
            { 0f                , 0f                , 0f                , 1f },
        });
        _isMatrixDirty = false;
    }
    
    [MemberNotNull(nameof(_eulerAngles))]
    private void RecalculateEulerAngles()
    {
        float pitch = MathF.Asin(-Matrix[1, 2]);
        float yaw = MathF.Cos(pitch) != 0 ? MathF.Atan2(Matrix[0, 2], Matrix[2, 2]) : MathF.Atan2(-Matrix[2, 0], Matrix[0, 0]);
        float roll = MathF.Cos(pitch) != 0 ? MathF.Atan2(Matrix[1, 0], Matrix[1, 1]) : 0f;
        _eulerAngles = new Vector3(pitch, yaw, roll) * Utils.Math.Rad2Deg;
        
        _isEulerAnglesDirty = false;
    }

    private void SetMatrixDirty()
    {
        _isMatrixDirty = true;
        SetEulerAnglesDirty(); // if matrix is dirty, euler angels are as well since they comme from it
    }

    private void SetEulerAnglesDirty()
    {
        _isEulerAnglesDirty = true;
    }
}