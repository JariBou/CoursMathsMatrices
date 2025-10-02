using System.Diagnostics.CodeAnalysis;
using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices;

public class Transform
{
    private Vector3 _localPosition;
    private Vector3 _localRotation;
    private Vector3 _localScale;
    
    private Matrix<float> _localRotationMatrix;
    
    private Matrix<float> _localToWorldMatrix;
    private bool _localToWorldMatrixDirty;

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
            RecalculateRotationMatrix();
            SetLocalToWorldDirty();
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
                {0f, 0f, 0f, 1f},
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
                {0f, 0f, 0f, 1f},
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
                {0f, 0f, 0f, 1f},
            });
        }
    }

    public Matrix<float> LocalRotationMatrix => _localRotationMatrix;

    public Matrix<float> LocalScaleMatrix
    {
        get
        {
            return new Matrix<float>(new[,]
            {
                {LocalScale.x, 0f, 0f, 0f},
                {0f, LocalScale.y, 0f, 0f},
                {0f, 0f, LocalScale.z, 0f},
                {0f, 0f, 0f, 1f},
            });
        }
    }

    public Matrix<float> LocalToWorldMatrix
    {
        get
        {
            if (!_localToWorldMatrixDirty) return _localToWorldMatrix;

            return RecalculateLocalToWorldMatrix();;
        }
    }

    public Matrix<float> WorldToLocalMatrix => LocalToWorldMatrix.InvertByDeterminant();
    
    #endregion

    public Transform()
    {
        LocalPosition = new Vector3();
        LocalRotation = new Vector3();
        LocalScale = new Vector3(1f, 1f, 1f);
        
        RecalculateRotationMatrix();
        RecalculateLocalToWorldMatrix();
    }
    
    [MemberNotNull(nameof(_localRotationMatrix))]
    private void RecalculateRotationMatrix()
    {
        _localRotationMatrix =
            MatrixOperations.Multiply(LocalRotationYMatrix, LocalRotationXMatrix, LocalRotationZMatrix);
    }
    
    [MemberNotNull(nameof(_localToWorldMatrix))]
    private Matrix<float> RecalculateLocalToWorldMatrix()
    {
        _localToWorldMatrix =
            MatrixOperations.Multiply(LocalTranslationMatrix, LocalRotationMatrix, LocalScaleMatrix);
        _localToWorldMatrixDirty = false;
        return _localToWorldMatrix;
    }

    private void SetLocalToWorldDirty()
    {
        _localToWorldMatrixDirty = true;
    }
}