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
        /// <summary>
        ///     Create a new instance that tweens the world position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenPosition(this Transform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector2> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.position = new Vector3(v.x, v.y, transform.position.z);
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenPosition(this Transform transform, Vector3 start, Vector3 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector3> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.position = v;
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world x position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenX(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, x =>
            {
                transform.position = new Vector3(x, transform.position.y, transform.position.z);
                onUpdate?.Invoke(x);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world y position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenY(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, y =>
            {
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
                onUpdate?.Invoke(y);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world z position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenZ(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, z =>
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, z);
                onUpdate?.Invoke(z);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the local position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenLocalPosition(this Transform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector2> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.localPosition = new Vector3(v.x, v.y, transform.localPosition.z);
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the local position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenLocalPosition(this Transform transform, Vector3 start, Vector3 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector3> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.localPosition = v;
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the local x position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenLocalX(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, x =>
            {
                transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
                onUpdate?.Invoke(x);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the local y position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenLocalY(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, y =>
            {
                transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
                onUpdate?.Invoke(y);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the local z position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenLocalZ(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, z =>
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
                onUpdate?.Invoke(z);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenRotation(this Transform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector2> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.eulerAngles = new Vector3(v.x, v.y, transform.eulerAngles.z);
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenRotation(this Transform transform, Vector3 start, Vector3 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector3> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.eulerAngles = v;
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world rotation of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenRotation(this Transform transform, Quaternion start, Quaternion end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Quaternion> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, q =>
            {
                transform.rotation = q;
                onUpdate?.Invoke(q);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world x rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenRotatationX(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, x =>
            {
                transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.z);
                onUpdate?.Invoke(x);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world y rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenRotatationY(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, y =>
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, transform.eulerAngles.z);
                onUpdate?.Invoke(y);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world z rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenRotatationZ(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, z =>
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, z);
                onUpdate?.Invoke(z);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenLocalRotation(this Transform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector2> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.localEulerAngles = new Vector3(v.x, v.y, transform.localEulerAngles.z);
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenLocalRotation(this Transform transform, Vector3 start, Vector3 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector3> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.localEulerAngles = v;
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world rotation of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenLocalRotation(this Transform transform, Quaternion start, Quaternion end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Quaternion> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, q =>
            {
                transform.localRotation = q;
                onUpdate?.Invoke(q);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world x rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenLocalRotatationX(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, x =>
            {
                transform.localEulerAngles = new Vector3(x, transform.localEulerAngles.y, transform.localEulerAngles.z);
                onUpdate?.Invoke(x);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world y rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenLocalRotatationY(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, y =>
            {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, y, transform.localEulerAngles.z);
                onUpdate?.Invoke(y);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the world z rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenLocalRotatationZ(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, z =>
            {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, z);
                onUpdate?.Invoke(z);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the scale of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenScale(this Transform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector2> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.localScale = new Vector3(v.x, v.y, transform.localScale.z);
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the scale of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenScale(this Transform transform, Vector3 start, Vector3 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector3> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.localScale = v;
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the x scale of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenScaleX(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, x =>
            {
                transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
                onUpdate?.Invoke(x);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the y scale of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenScaleY(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, y =>
            {
                transform.eulerAngles = new Vector3(transform.localScale.x, y, transform.localScale.z);
                onUpdate?.Invoke(y);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the z scale of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenScaleZ(this Transform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, z =>
            {
                transform.eulerAngles = new Vector3(transform.localScale.x, transform.localScale.y, z);
                onUpdate?.Invoke(z);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the colour of a sprite renderer.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenColourRGB(this SpriteRenderer renderer, Color start, Color end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Color> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, c =>
            {
                renderer.color = c;
                onUpdate?.Invoke(c);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the red component of a sprite renderer's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenRed(this SpriteRenderer renderer, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, r =>
            {
                renderer.color = new Color(r, renderer.color.g, renderer.color.b, renderer.color.a);
                onUpdate?.Invoke(r);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the green component of a sprite renderer's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenGreen(this SpriteRenderer renderer, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, g =>
            {
                renderer.color = new Color(renderer.color.r, g, renderer.color.b, renderer.color.a);
                onUpdate?.Invoke(g);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the blue component of a sprite renderer's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenBlue(this SpriteRenderer renderer, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, b =>
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, b, renderer.color.a);
                onUpdate?.Invoke(b);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the alpha component of a sprite renderer's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenAlpha(this SpriteRenderer renderer, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, a =>
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, a);
                onUpdate?.Invoke(a);
            }, onComplete);
        }
    }
}
