﻿// File: TweenExtensions.cs
// Purpose: Collection of useful tweening extension methods
// Created by: DavidFDev

using System;
using UnityEngine;
using UnityEngine.UI;

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Collection of tweening extension methods.
    /// </summary>
    public static class TweenExtensions
    {
        #region Transform

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

        #endregion

        #region RectTransform

        /// <summary>
        ///     Create a new instance that tweens the anchored position of an object's rect transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenAnchoredPosition(this RectTransform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector2> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.anchoredPosition = v;
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the 3d anchored position of an object's rect transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenAnchoredPosition3D(this RectTransform transform, Vector3 start, Vector3 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector3> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.anchoredPosition3D = v;
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the size delta of an object's rect transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenSizeDelta(this RectTransform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector2> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                transform.sizeDelta = v;
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the size delta x component of an object's rect transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenSizeDeltaX(this RectTransform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, x =>
            {
                transform.sizeDelta = new Vector2(x, transform.sizeDelta.y);
                onUpdate?.Invoke(x);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the size delta y component of an object's rect transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenSizeDeltaY(this RectTransform transform, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, y =>
            {
                transform.sizeDelta = new Vector2(transform.sizeDelta.x, y);
                onUpdate?.Invoke(y);
            }, onComplete);
        }

        #endregion

        #region SpriteRenderer

        /// <summary>
        ///     Create a new instance that tweens the colour of a sprite renderer.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenColour(this SpriteRenderer renderer, Color start, Color end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Color> onUpdate = null, Action onComplete = null)
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

        #endregion

        #region Graphic

        /// <summary>
        ///     Create a new instance that tweens the colour of a graphic.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenColour<T>(this T graphic, Color start, Color end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Color> onUpdate = null, Action onComplete = null) where T : Graphic
        {
            return Tween.Create(start, end, duration, easingFunction, begin, c =>
            {
                graphic.color = c;
                onUpdate?.Invoke(c);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the red component of a graphic's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenRed<T>(this T graphic, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null) where T : Graphic
        {
            return Tween.Create(start, end, duration, easingFunction, begin, r =>
            {
                graphic.color = new Color(r, graphic.color.g, graphic.color.b, graphic.color.a);
                onUpdate?.Invoke(r);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the green component of a graphic's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenGreen<T>(this T graphic, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null) where T : Graphic
        {
            return Tween.Create(start, end, duration, easingFunction, begin, g =>
            {
                graphic.color = new Color(graphic.color.r, g, graphic.color.b, graphic.color.a);
                onUpdate?.Invoke(g);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the blue component of a graphic's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenBlue<T>(this T graphic, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null) where T : Graphic
        {
            return Tween.Create(start, end, duration, easingFunction, begin, b =>
            {
                graphic.color = new Color(graphic.color.r, graphic.color.g, b, graphic.color.a);
                onUpdate?.Invoke(b);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the alpha component of a graphic's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenAlpha<T>(this T graphic, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null) where T : Graphic
        {
            return Tween.Create(start, end, duration, easingFunction, begin, a =>
            {
                graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, a);
                onUpdate?.Invoke(a);
            }, onComplete);
        }

        #endregion

        #region AudioSource

        /// <summary>
        ///     Create a new instance that tweens the volume of an audio source.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenVolume(this AudioSource audioSource, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, v =>
            {
                audioSource.volume = v;
                onUpdate?.Invoke(v);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the pitch of an audio source.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenPitch(this AudioSource audioSource, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, p =>
            {
                audioSource.pitch = p;
                onUpdate?.Invoke(p);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the spatial blend of an audio source.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenSpatialBlend(this AudioSource audioSource, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, b =>
            {
                audioSource.spatialBlend = b;
                onUpdate?.Invoke(b);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the stereo pan of an audio source.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenPanStereo(this AudioSource audioSource, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, p =>
            {
                audioSource.panStereo = p;
                onUpdate?.Invoke(p);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the playback time of an audio source.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenTime(this AudioSource audioSource, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, t =>
            {
                audioSource.time = t;
                onUpdate?.Invoke(t);
            }, onComplete);
        }

        #endregion

        #region Light

        /// <summary>
        ///     Create a new instance that tweens the intensity of a light.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenIntensity(this Light light, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, i =>
            {
                light.intensity = i;
                onUpdate?.Invoke(i);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the range of a light.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenRange(this Light light, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, r =>
            {
                light.range = r;
                onUpdate?.Invoke(r);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the spot angle of a light.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenSpotAngle(this Light light, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, a =>
            {
                light.spotAngle = a;
                onUpdate?.Invoke(a);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the colour of a light.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenColour(this Light light, Color start, Color end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Color> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, c =>
            {
                light.color = c;
                onUpdate?.Invoke(c);
            }, onComplete);
        }

        #endregion

        #region Camera

        /// <summary>
        ///     Create a new instance that tweens the field of view of a camera.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenFieldOfView(this Camera camera, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, fov =>
            {
                camera.fieldOfView = fov;
                onUpdate?.Invoke(fov);
            }, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens the orthographic size of a camera.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween TweenOrthographicSize(this Camera camera, float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Tween.Create(start, end, duration, easingFunction, begin, s =>
            {
                camera.orthographicSize = s;
                onUpdate?.Invoke(s);
            }, onComplete);
        }

        #endregion
    }
}
