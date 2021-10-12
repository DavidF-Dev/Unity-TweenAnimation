// File: Ease.cs
// Purpose: Collection of useful easing functions
// Created by: DavidFDev

// References
// https://github.com/sole/tween.js/blob/master/src/Tween.js
// https://www.febucci.com/2018/08/easing-functions/
// https://easings.net/

using System.Diagnostics.Contracts;
using UnityEngine;

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Easing function used by a lerping function.
    /// </summary>
    /// <param name="t">Progress (0.0 - 1.0).</param>
    /// <returns>Manipulated progress (0.0 - 1.0).</returns>
    public delegate float EasingFunction(float t);

    /// <summary>
    ///     Collection of useful easing functions.
    ///     Visualisations at https://easings.net/.
    /// </summary>
    public static class Ease
    {
        #region Static fields

        /// <summary>
        ///     Linearly reach the destination state.
        /// </summary>
        public static readonly EasingFunction Linear = t => t;

        /// <summary>
        ///     Ease in (^2).
        /// </summary>
        public static readonly EasingFunction QuadIn = t => t * t;

        /// <summary>
        ///     Ease out (^2).
        /// </summary>
        public static readonly EasingFunction QuadOut = t => 1 - (1 - t) * (1 - t);

        /// <summary>
        ///     Ease in and out (^2).
        /// </summary>
        public static readonly EasingFunction QuadInOut = t => t < 0.5f ? 2 * t * t : 1 - Mathf.Pow(-2 * t + 2, 2) / 2;

        #endregion

        #region Static methods

        /// <summary>
        ///     Get an easing function by enum value.
        /// </summary>
        /// <param name="easeType"></param>
        /// <returns></returns>
        [Pure]
        public static EasingFunction Get(EaseType easeType)
        {
            switch (easeType)
            {
                case EaseType.QuadIn:
                    return QuadIn;
                case EaseType.QuadOut:
                    return QuadOut;
                case EaseType.QuadInOut:
                    return QuadInOut;
                case EaseType.Linear:
                default:
                    return Linear;
            }
        }

        /// <summary>
        ///     Get the enum value corresponding to the provided easing function.
        /// </summary>
        /// <param name="easingFunction"></param>
        /// <returns>Null if the easing function is not part of the built-in collection.</returns>
        [Pure]
        public static EaseType? Get(EasingFunction easingFunction)
        {
            if (easingFunction == Linear)
            {
                return EaseType.Linear;
            }

            if (easingFunction == QuadIn)
            {
                return EaseType.QuadIn;
            }

            if (easingFunction == QuadOut)
            {
                return EaseType.QuadOut;
            }

            if (easingFunction == QuadInOut)
            {
                return EaseType.QuadInOut;
            }

            return null;
        }

        #endregion
    }

    /// <summary>
    ///     Use Ease.Get() to retrieve the respective easing function.
    ///     Represented as an enum to make it easier to serialise in the inspector if needed.
    /// </summary>
    public enum EaseType
    {
        /// <summary>
        ///     Linearly reach the destination state.
        /// </summary>
        Linear,

        /// <summary>
        ///     Ease in (^2).
        /// </summary>
        QuadIn,

        /// <summary>
        ///     Ease out (^2).
        /// </summary>
        QuadOut,

        /// <summary>
        ///     Ease in and out (^2).
        /// </summary>
        QuadInOut
    }
}
