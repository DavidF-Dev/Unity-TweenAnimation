// File: Ease.cs
// Created by: DavidFDev

// References
// https://github.com/sole/tween.js/blob/master/src/Tween.js
// https://www.febucci.com/2018/08/easing-functions/
// https://easings.net/

using System;
using System.Diagnostics.Contracts;
using UnityEngine;

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Easing function used by a lerping function.
    /// </summary>
    /// <param name="t">Progress (typically 0.0 - 1.0).</param>
    /// <returns>Manipulated progress (typically 0.0 - 1.0).</returns>
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

        /// <summary>
        ///     Ease in (^3).
        /// </summary>
        public static readonly EasingFunction CubicIn = t => t * t * t;

        /// <summary>
        ///     Ease out (^3).
        /// </summary>
        public static readonly EasingFunction CubicOut = t => 1 - Mathf.Pow(1 - t, 3);

        /// <summary>
        ///     Ease in and out (^3).
        /// </summary>
        public static readonly EasingFunction CubicInOut = t => t < 0.5 ? 4 * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 3) / 2;

        /// <summary>
        ///     Ease in (^4).
        /// </summary>
        public static readonly EasingFunction QuartIn = t => t * t * t * t;

        /// <summary>
        ///     Ease out (^4).
        /// </summary>
        public static readonly EasingFunction QuartOut = t => 1 - Mathf.Pow(1 - t, 4);

        /// <summary>
        ///     Ease in and out (^4).
        /// </summary>
        public static readonly EasingFunction QuartInOut = t => t < 0.5f ? 8 * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 4) / 2;

        /// <summary>
        ///     Ease in using a sine wave.
        /// </summary>
        public static readonly EasingFunction SineIn = t => 1 - Mathf.Cos(t * Mathf.PI / 2);

        /// <summary>
        ///     Ease out using a sine wave.
        /// </summary>
        public static readonly EasingFunction SineOut = t => Mathf.Sin(t * Mathf.PI / 2);

        /// <summary>
        ///     Ease in and out using a sine wave.
        /// </summary>
        public static readonly EasingFunction SineInOut = t => -(Mathf.Cos(Mathf.PI * t) - 1) / 2;

        /// <summary>
        ///     Ease in exponentially.
        /// </summary>
        public static readonly EasingFunction ExpoIn = t => t == 0 ? 0 : Mathf.Pow(2, 10 * t - 10);

        /// <summary>
        ///     Ease out exponentially.
        /// </summary>
        public static readonly EasingFunction ExpoOut = t => Math.Abs(t - 1) < Mathf.Epsilon ? 1 : 1 - Mathf.Pow(2, -10 * t);

        /// <summary>
        ///     Ease in and out exponentially.
        /// </summary>
        public static readonly EasingFunction ExpoInOut = t => t == 0 ? 0 : Math.Abs(t - 1) < Mathf.Epsilon ? 1 : t < 0.5 ? Mathf.Pow(2, 20 * t - 10) / 2 : (2 - Mathf.Pow(2, -20 * t + 10)) / 2;

        /// <summary>
        ///     Ease in cyclically.
        /// </summary>
        public static readonly EasingFunction CircIn = t => 1 - Mathf.Sqrt(1 - Mathf.Pow(t, 2));

        /// <summary>
        ///     Ease out cyclically.
        /// </summary>
        public static readonly EasingFunction CircOut = t => Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));

        /// <summary>
        ///     Ease in and out cyclically.
        /// </summary>
        public static readonly EasingFunction CircInOut = t => t < 0.5f ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * t, 2))) / 2 : (Mathf.Sqrt(1 - Mathf.Pow(-2 * t + 2, 2)) + 1) / 2;

        /// <summary>
        ///     In ease, slightly overshooting.
        /// </summary>
        public static readonly EasingFunction BackIn = t =>
        {
            const float c1 = 1.70158f;
            const float c3 = c1 + 1;
            return c3 * t * t * t - c1 * t * t;
        };

        /// <summary>
        ///     Ease out, slightly overshooting.
        /// </summary>
        public static readonly EasingFunction BackOut = t =>
        {
            const float c1 = 1.70158f;
            const float c3 = c1 + 1;
            return 1 + c3 * Mathf.Pow(t - 1, 3) + c1 * Mathf.Pow(t - 1, 2);
        };

        /// <summary>
        ///     Ease in and out, slightly overshooting.
        /// </summary>
        public static readonly EasingFunction BackInOut = t =>
        {
            const float c1 = 1.70158f;
            const float c2 = c1 * 1.525f;

            return t < 0.5f
                ? Mathf.Pow(2 * t, 2) * ((c2 + 1) * 2 * t - c2) / 2
                : (Mathf.Pow(2 * t - 2, 2) * ((c2 + 1) * (t * 2 - 2) + c2) + 2) / 2;
        };

        /// <summary>
        ///     Ease in elastically.
        /// </summary>
        public static readonly EasingFunction ElasticIn = t =>
        {
            const float c4 = 2 * Mathf.PI / 3;
            return t == 0 ? 0 : Math.Abs(t - 1) < Mathf.Epsilon ? 1 : -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10 - 10.75f) * c4);
        };

        /// <summary>
        ///     Ease out elastically.
        /// </summary>
        public static readonly EasingFunction ElasticOut = t =>
        {
            const float c4 = 2 * Mathf.PI / 3;
            return t == 0 ? 0 : Math.Abs(t - 1) < Mathf.Epsilon ? 1 : Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10 - 0.75f) * c4) + 1;
        };

        /// <summary>
        ///     Ease in and out elastically.
        /// </summary>
        public static readonly EasingFunction ElasticInOut = t =>
        {
            const float c5 = 2 * Mathf.PI / 4.5f;
            return t == 0
                ? 0
                : Math.Abs(t - 1) < Mathf.Epsilon
                    ? 1
                    : t < 0.5f
                        ? -(Mathf.Pow(2, 20 * t - 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2
                        : Mathf.Pow(2, -20 * t + 10) * Mathf.Sin((20 * t - 11.125f) * c5) / 2 + 1;
        };

        /// <summary>
        ///     Ease in with a bounce.
        /// </summary>
        public static readonly EasingFunction BounceIn = t => 1 - BounceOut(1 - t);

        /// <summary>
        ///     Ease out with a bounce.
        /// </summary>
        public static readonly EasingFunction BounceOut = t =>
        {
            const float n1 = 7.5625f;
            const float d1 = 2.75f;

            if (t < 1 / d1)
            {
                return n1 * t * t;
            }

            if (t < 2 / d1)
            {
                return n1 * (t -= 1.5f / d1) * t + 0.75f;
            }

            if (t < 2.5 / d1)
            {
                return n1 * (t -= 2.25f / d1) * t + 0.9375f;
            }

            return n1 * (t -= 2.625f / d1) * t + 0.984375f;
        };

        /// <summary>
        ///     Ease in and out with a bounce.
        /// </summary>
        public static readonly EasingFunction BounceInOut = t => t < 0.5f ? BounceIn(t * 2) * 0.5f : BackOut(t * 2 - 1) * 0.5f + 0.5f;

        /// <summary>
        ///     Mirrored animation - reaches destination state then returns back to original state.
        /// </summary>
        public static readonly EasingFunction Spike = t => t <= 0.5f ? QuadIn(t / 0.5f) : QuadIn((1 - t) / 0.5f);

        #endregion

        #region Static methods

        /// <summary>
        ///     Get an easing function by enum value.
        /// </summary>
        /// <param name="easeType"></param>
        /// <returns></returns>
        [Pure]
        public static EasingFunction GetEasingFunction(this EaseType easeType)
        {
            return easeType switch
            {
                EaseType.QuadIn => QuadIn,
                EaseType.QuadOut => QuadOut,
                EaseType.QuadInOut => QuadInOut,
                EaseType.CubicIn => CubicIn,
                EaseType.CubicOut => CubicOut,
                EaseType.CubicInOut => CubicInOut,
                EaseType.QuartIn => QuartIn,
                EaseType.QuartOut => QuartOut,
                EaseType.QuartInOut => QuartInOut,
                EaseType.SineIn => SineIn,
                EaseType.SineOut => SineOut,
                EaseType.SineInOut => SineInOut,
                EaseType.ExpoIn => ExpoIn,
                EaseType.ExpoOut => ExpoOut,
                EaseType.ExpoInOut => ExpoInOut,
                EaseType.CircIn => CircIn,
                EaseType.CircOut => CircOut,
                EaseType.CircInOut => CircInOut,
                EaseType.BackIn => BackIn,
                EaseType.BackOut => BackOut,
                EaseType.BackInOut => BackInOut,
                EaseType.ElasticIn => ElasticIn,
                EaseType.ElasticOut => ElasticOut,
                EaseType.ElasticInOut => ElasticInOut,
                EaseType.BounceIn => BounceIn,
                EaseType.BounceOut => BounceOut,
                EaseType.BounceInOut => BounceInOut,
                EaseType.Spike => Spike,
                EaseType.Linear => Linear,
                _ => Linear
            };
        }

        /// <summary>
        ///     Get the enum value corresponding to the provided easing function.
        /// </summary>
        /// <param name="easingFunction"></param>
        /// <returns>Null if the easing function is not part of the built-in collection.</returns>
        [Pure]
        public static EaseType? GetEaseType(this EasingFunction easingFunction)
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

            if (easingFunction == CubicIn)
            {
                return EaseType.CubicIn;
            }

            if (easingFunction == CubicOut)
            {
                return EaseType.CubicOut;
            }

            if (easingFunction == CubicInOut)
            {
                return EaseType.CubicInOut;
            }

            if (easingFunction == QuartIn)
            {
                return EaseType.QuartIn;
            }

            if (easingFunction == QuartOut)
            {
                return EaseType.QuartOut;
            }

            if (easingFunction == QuartInOut)
            {
                return EaseType.QuartInOut;
            }

            if (easingFunction == SineIn)
            {
                return EaseType.SineIn;
            }

            if (easingFunction == SineOut)
            {
                return EaseType.SineOut;
            }

            if (easingFunction == SineInOut)
            {
                return EaseType.SineInOut;
            }

            if (easingFunction == ExpoIn)
            {
                return EaseType.ExpoIn;
            }

            if (easingFunction == ExpoOut)
            {
                return EaseType.ExpoOut;
            }

            if (easingFunction == ExpoInOut)
            {
                return EaseType.ExpoInOut;
            }

            if (easingFunction == CircIn)
            {
                return EaseType.CircIn;
            }

            if (easingFunction == CircOut)
            {
                return EaseType.CircOut;
            }

            if (easingFunction == CircInOut)
            {
                return EaseType.CircInOut;
            }

            if (easingFunction == BackIn)
            {
                return EaseType.BackIn;
            }

            if (easingFunction == BackOut)
            {
                return EaseType.BackOut;
            }

            if (easingFunction == BackInOut)
            {
                return EaseType.BackInOut;
            }

            if (easingFunction == ElasticIn)
            {
                return EaseType.ElasticIn;
            }

            if (easingFunction == ElasticOut)
            {
                return EaseType.ElasticOut;
            }

            if (easingFunction == ElasticInOut)
            {
                return EaseType.ElasticInOut;
            }

            if (easingFunction == BounceIn)
            {
                return EaseType.BounceIn;
            }

            if (easingFunction == BounceOut)
            {
                return EaseType.BounceOut;
            }

            if (easingFunction == BounceInOut)
            {
                return EaseType.BounceInOut;
            }

            if (easingFunction == Spike)
            {
                return EaseType.Spike;
            }

            return null;
        }

        /// <summary>
        ///     Invert (flip) the result of the provided easing function.
        ///     This is calculated as (1 - x) where x is the result of the original easing function.
        /// </summary>
        /// <param name="easingFunction"></param>
        /// <returns>Inverted easing function.</returns>
        [Pure]
        public static EasingFunction Invert(this EasingFunction easingFunction)
        {
            return x => 1f - easingFunction(x);
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
        QuadInOut,

        /// <summary>
        ///     Ease in (^3).
        /// </summary>
        CubicIn,

        /// <summary>
        ///     Ease out (^3).
        /// </summary>
        CubicOut,

        /// <summary>
        ///     Ease in and out (^3).
        /// </summary>
        CubicInOut,

        /// <summary>
        ///     Ease in (^4).
        /// </summary>
        QuartIn,

        /// <summary>
        ///     Ease out (^4).
        /// </summary>
        QuartOut,

        /// <summary>
        ///     Ease in and out (^4).
        /// </summary>
        QuartInOut,

        /// <summary>
        ///     Ease in using a sine wave.
        /// </summary>
        SineIn,

        /// <summary>
        ///     Ease out using a sine wave.
        /// </summary>
        SineOut,

        /// <summary>
        ///     Ease in and out using a sine wave.
        /// </summary>
        SineInOut,

        /// <summary>
        ///     Ease in exponentially.
        /// </summary>
        ExpoIn,

        /// <summary>
        ///     Ease out exponentially.
        /// </summary>
        ExpoOut,

        /// <summary>
        ///     Ease in and out exponentially.
        /// </summary>
        ExpoInOut,

        /// <summary>
        ///     Ease in cyclically.
        /// </summary>
        CircIn,

        /// <summary>
        ///     Ease out cyclically.
        /// </summary>
        CircOut,

        /// <summary>
        ///     Ease in and out cyclically.
        /// </summary>
        CircInOut,

        /// <summary>
        ///     In ease, slightly overshooting.
        /// </summary>
        BackIn,

        /// <summary>
        ///     Ease out, slightly overshooting.
        /// </summary>
        BackOut,

        /// <summary>
        ///     Ease in and out, slightly overshooting.
        /// </summary>
        BackInOut,

        /// <summary>
        ///     Ease in elastically.
        /// </summary>
        ElasticIn,

        /// <summary>
        ///     Ease out elastically.
        /// </summary>
        ElasticOut,

        /// <summary>
        ///     Ease in and out elastically.
        /// </summary>
        ElasticInOut,

        /// <summary>
        ///     Ease in with a bounce.
        /// </summary>
        BounceIn,

        /// <summary>
        ///     Ease out with a bounce.
        /// </summary>
        BounceOut,

        /// <summary>
        ///     Ease in and out with a bounce.
        /// </summary>
        BounceInOut,

        /// <summary>
        ///     Mirrored animation - reaches destination state then returns back to original state.
        /// </summary>
        Spike
    }
}