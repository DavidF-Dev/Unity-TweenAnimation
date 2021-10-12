// File: TweenExtensions.cs
// Purpose: Extension methods for performing tween animations more easily
// Created by: DavidFDev

using System;
using UnityEngine;

namespace DavidFDev.Tweening
{
    public static class TweenExtensions
    {
        public static Tween TweenX(this Transform transform, float start, float end, float duration, EasingFunction easingFunction, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
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
