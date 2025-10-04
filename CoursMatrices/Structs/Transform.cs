using System.Diagnostics.CodeAnalysis;
using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices.Structs;

public class Transform
{
    private Vector3 _localPosition;
    private Vector3 _localRotation;
    private Vector3 _localScale;
    
    // The dirty thing is just me exploring ways to try and reduce the amount of expensive operations (before seing test 21...)
    private Matrix<float> _localRotationMatrix;
    private bool _isLocalRotationMatrixDirty;
    
    private Matrix<float> _localToWorldMatrix;
    private bool _isLocalToWorldMatrixDirty;
    
    private Quaternion _localRotationQuaternion;
    private bool _isLocalRotationQuaternionDirty;

    public Vector3 LocalPosition
    {
        get => _localPosition;
        set
        { 
            _localPosition = value;
            SetLocalToWorldDirty();
        }
    }
    
    public Vector3 LocalRotation
    {
        get => _localRotation;
        set 
        {
            _localRotation = value;
            SetLocalRotationMatrixDirty();
            SetLocalToWorldDirty();
            SetLocalRotationQuaternionDirty();
        }
    }

    public Vector3 LocalScale
    {
        get => _localScale;
        set
        {
            _localScale = value;
            SetLocalToWorldDirty();
        }
    }

    #region Matrixes

    public Matrix<float> LocalTranslationMatrix
    {
        get
        {
            Matrix<float> localTranslationMatrix = MatrixOperations.Identity<float>(4);
            localTranslationMatrix.SetColumn(3, [LocalPosition.x, LocalPosition.y, LocalPosition.z, 1f]);
            return localTranslationMatrix;
        }
    }

    public Matrix<float> LocalRotationXMatrix
    {
        get
        {
            float theta = LocalRotation.x * Utils.Math.Deg2Rad;
            return new Matrix<float>(new[,]
            {
                {1f, 0f, 0f, 0f},
                {0f, MathF.Cos(theta), -MathF.Sin(theta), 0f},
                {0f, MathF.Sin(theta), MathF.Cos(theta), 0f},
                {0f, 0f, 0f, 1f}
            });
        }
    }
    
    public Matrix<float> LocalRotationYMatrix
    {
        get
        {
            float theta = LocalRotation.y * Utils.Math.Deg2Rad;
            return new Matrix<float>(new[,]
            {
                {MathF.Cos(theta), 0f, MathF.Sin(theta), 0f},
                {0f, 1f, 0f, 0f},
                {-MathF.Sin(theta), 0f, MathF.Cos(theta), 0f},
                {0f, 0f, 0f, 1f}
            });
        }
    }
    
    public Matrix<float> LocalRotationZMatrix
    {
        get
        {
            float theta = LocalRotation.z * Utils.Math.Deg2Rad;
            return new Matrix<float>(new[,]
            {
                {MathF.Cos(theta), -MathF.Sin(theta), 0f, 0f},
                {MathF.Sin(theta), MathF.Cos(theta), 0f, 0f},
                {0f, 0f, 1f, 0f},
                {0f, 0f, 0f, 1f}
            });
        }
    }

    public Matrix<float> LocalRotationMatrix
    {
        get
        {
            if (_isLocalRotationMatrixDirty) RecalculateLocalRotationMatrix();
            return _localRotationMatrix;
        }
    }

    public Matrix<float> LocalScaleMatrix
    {
        get
        {
            return new Matrix<float>(new[,]
            {
                {LocalScale.x, 0f, 0f, 0f},
                {0f, LocalScale.y, 0f, 0f},
                {0f, 0f, LocalScale.z, 0f},
                {0f, 0f, 0f, 1f}
            });
        }
    }

    public Matrix<float> LocalToWorldMatrix
    {
        get
        {
            if (_isLocalToWorldMatrixDirty) RecalculateLocalToWorldMatrixLocal();
            
            return Parent is null ? _localToWorldMatrix : MatrixOperations.Multiply(Parent.LocalToWorldMatrix, _localToWorldMatrix);
        }
    }

    public Matrix<float> WorldToLocalMatrix => LocalToWorldMatrix.InvertByDeterminant();

    #endregion
    
    public Transform? Parent { get; set; }

    public Vector3 WorldPosition
    {
        get
        {
            if (Parent is null) return LocalPosition;
            
            Vector4 vector4Pos = new(LocalPosition.x, LocalPosition.y, LocalPosition.z, 1f);
            return Parent.LocalToWorldMatrix * vector4Pos;
        }
        set
        {
            Vector4 vector4Pos = new(value.x, value.y, value.z, 1f);
            vector4Pos = WorldToLocalMatrix * vector4Pos;
            LocalPosition = vector4Pos;
        }
    }

    public Quaternion LocalRotationQuaternion
    {
        get
        {
            if (_isLocalRotationQuaternionDirty) RecalculateLocalRotationQuaternion();
            
            return _localRotationQuaternion;
        }
        set
        {
            _localRotationQuaternion = value;
            _localRotation = _localRotationQuaternion.EulerAngles;
            SetLocalRotationMatrixDirty();
            SetLocalToWorldDirty();
        }
    }

    public Transform()
    {
        LocalPosition = new Vector3();
        LocalRotation = new Vector3();
        LocalScale = new Vector3(1f, 1f, 1f);
        
        RecalculateLocalRotationMatrix();
        RecalculateLocalToWorldMatrixLocal();
        RecalculateLocalRotationQuaternion();
    }

    #region Dirty methods

    [MemberNotNull(nameof(_localRotationMatrix))]
    private void RecalculateLocalRotationMatrix()
    {
        _localRotationMatrix =
            MatrixOperations.Multiply(LocalRotationYMatrix, LocalRotationXMatrix, LocalRotationZMatrix);
        _isLocalRotationMatrixDirty = false;
    }
    
    [MemberNotNull(nameof(_localToWorldMatrix))]
    private Matrix<float> RecalculateLocalToWorldMatrixLocal()
    {
        _localToWorldMatrix = MatrixOperations.Multiply(LocalTranslationMatrix, LocalRotationMatrix, LocalScaleMatrix);
        _isLocalToWorldMatrixDirty = false;
        return _localToWorldMatrix;
    }
    
    [MemberNotNull(nameof(_localRotationQuaternion))]
    private void RecalculateLocalRotationQuaternion()
    {
        _localRotationQuaternion = Quaternion.Euler(LocalRotation);
        _isLocalRotationMatrixDirty = false;
    }
    
    private void SetLocalToWorldDirty()
    {
        _isLocalToWorldMatrixDirty = true;
    }
    
    private void SetLocalRotationMatrixDirty()
    {
        _isLocalRotationMatrixDirty = true;
    }
    
    private void SetLocalRotationQuaternionDirty()
    {
        _isLocalRotationQuaternionDirty = true;
    }

    #endregion

    public void SetParent(Transform tParent)
    {
        Parent =  tParent;
    }
}