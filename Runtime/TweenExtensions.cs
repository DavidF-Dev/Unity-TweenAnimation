// File: TweenExtensions.cs
// Purpose: Collection of useful tweening extension methods
// Created by: DavidFDev

using System;
using UnityEngine;

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Collection of tweening extension methods.
    /// </summary>
    public static class TweenExtensions
    {
        public static Tween TweenX(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, x =>
            {
                transform.position = new Vector3(x, transform.position.y, transform.position.z);
                onUpdate(x);
            },
            onComplete);
        }
    }
}
