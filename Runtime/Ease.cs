// File: Ease.cs
// Purpose: Collection of useful easing functions
// Created by: DavidFDev

using UnityEngine;

namespace DavidFDev.Tweening
{
    public delegate float EasingFunction(float t);

    public static class Ease
    {
        #region Static fields

        public static readonly EasingFunction Linear = t => t;

        public static readonly EasingFunction Quad_In = t => t * t;

        public static readonly EasingFunction Quad_Out = t => 1 - (1 - t) * (1 - t);

        public static readonly EasingFunction Quad_In_Out = t => t < 0.5f ? 2 * t * t : 1 - Mathf.Pow(-2 * t + 2, 2) / 2;

        #endregion
    }
}
