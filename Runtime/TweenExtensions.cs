// File: TweenExtensions.cs
// Created by: DavidFDev

using UnityEngine;
using UnityEngine.UI;

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Collection of extension methods for tweening common Unity properties.
    /// </summary>
    public static class TweenExtensions
    {
        #region Transform

        /// <summary>
        ///     Create a new instance that tweens the world position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector2> TweenPosition(this Transform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var position = transform.position;
                position.x = value.x;
                position.y = value.y;
                transform.position = position;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector3> TweenPosition(this Transform transform, Vector3 start, Vector3 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => transform.position = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world x position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenX(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var position = transform.position;
                position.x = value;
                transform.position = position;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world y position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenY(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var position = transform.position;
                position.y = value;
                transform.position = position;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world z position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenZ(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var position = transform.position;
                position.z = value;
                transform.position = position;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the local position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector2> TweenLocalPosition(this Transform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var position = transform.localPosition;
                position.x = value.x;
                position.y = value.y;
                transform.localPosition = position;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the local position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector3> TweenLocalPosition(this Transform transform, Vector3 start, Vector3 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => transform.localPosition = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the local x position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenLocalX(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var position = transform.localPosition;
                position.x = value;
                transform.localPosition = position;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the local y position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenLocalY(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var position = transform.localPosition;
                position.y = value;
                transform.localPosition = position;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the local z position of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenLocalZ(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var position = transform.localPosition;
                position.z = value;
                transform.localPosition = position;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector2> TweenRotation(this Transform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var rotation = transform.eulerAngles;
                rotation.x = value.x;
                rotation.y = value.y;
                transform.eulerAngles = rotation;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector3> TweenRotation(this Transform transform, Vector3 start, Vector3 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => transform.eulerAngles = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world rotation of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Quaternion> TweenRotation(this Transform transform, Quaternion start, Quaternion end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => transform.rotation = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world x rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenRotationX(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var rotation = transform.eulerAngles;
                rotation.x = value;
                transform.eulerAngles = rotation;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world y rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenRotationY(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var rotation = transform.eulerAngles;
                rotation.y = value;
                transform.eulerAngles = rotation;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world z rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenRotationZ(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var rotation = transform.eulerAngles;
                rotation.z = value;
                transform.eulerAngles = rotation;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector2> TweenLocalRotation(this Transform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var rotation = transform.localEulerAngles;
                rotation.x = value.x;
                rotation.y = value.y;
                transform.localEulerAngles = rotation;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector3> TweenLocalRotation(this Transform transform, Vector3 start, Vector3 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => transform.localEulerAngles = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world rotation of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Quaternion> TweenLocalRotation(this Transform transform, Quaternion start, Quaternion end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => transform.localRotation = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world x rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenLocalRotationX(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var rotation = transform.localEulerAngles;
                rotation.x = value;
                transform.localEulerAngles = rotation;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world y rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenLocalRotationY(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var rotation = transform.localEulerAngles;
                rotation.y = value;
                transform.localEulerAngles = rotation;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the world z rotation of an object's transform (euler).
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenLocalRotationZ(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var rotation = transform.localEulerAngles;
                rotation.z = value;
                transform.localEulerAngles = rotation;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the scale of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector2> TweenScale(this Transform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var scale = transform.localScale;
                scale.x = value.x;
                scale.y = value.y;
                transform.localScale = scale;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the scale of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector3> TweenScale(this Transform transform, Vector3 start, Vector3 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => transform.localScale = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the x scale of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenScaleX(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var rotation = transform.localScale;
                rotation.x = value;
                transform.localScale = rotation;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the y scale of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenScaleY(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var rotation = transform.localScale;
                rotation.y = value;
                transform.localScale = rotation;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the z scale of an object's transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenScaleZ(this Transform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var rotation = transform.localScale;
                rotation.z = value;
                transform.localScale = rotation;
            };
            return tween;
        }

        #endregion

        #region RectTransform

        /// <summary>
        ///     Create a new instance that tweens the anchored position of an object's rect transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector2> TweenAnchoredPosition(this RectTransform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => transform.anchoredPosition = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the 3d anchored position of an object's rect transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector3> TweenAnchoredPosition3D(this RectTransform transform, Vector3 start, Vector3 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => transform.anchoredPosition3D = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the size delta of an object's rect transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector2> TweenSizeDelta(this RectTransform transform, Vector2 start, Vector2 end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => transform.sizeDelta = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the size delta x component of an object's rect transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenSizeDeltaX(this RectTransform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var sizeDelta = transform.sizeDelta;
                sizeDelta.x = value;
                transform.sizeDelta = sizeDelta;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the size delta y component of an object's rect transform.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenSizeDeltaY(this RectTransform transform, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var sizeDelta = transform.sizeDelta;
                sizeDelta.y = value;
                transform.sizeDelta = sizeDelta;
            };
            return tween;
        }

        #endregion

        #region SpriteRenderer

        /// <summary>
        ///     Create a new instance that tweens the colour of a sprite renderer.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Color> TweenColour(this SpriteRenderer renderer, Color start, Color end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => renderer.color = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the red component of a sprite renderer's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenRed(this SpriteRenderer renderer, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var colour = renderer.color;
                colour.r = value;
                renderer.color = colour;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the green component of a sprite renderer's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenGreen(this SpriteRenderer renderer, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var colour = renderer.color;
                colour.g = value;
                renderer.color = colour;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the blue component of a sprite renderer's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenBlue(this SpriteRenderer renderer, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var colour = renderer.color;
                colour.b = value;
                renderer.color = colour;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the alpha component of a sprite renderer's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenAlpha(this SpriteRenderer renderer, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var colour = renderer.color;
                colour.a = value;
                renderer.color = colour;
            };
            return tween;
        }

        #endregion

        #region Graphic

        /// <summary>
        ///     Create a new instance that tweens the colour of a graphic.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Color> TweenColour<T>(this T graphic, Color start, Color end, float duration, EasingFunction easingFunction) where T : Graphic
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => graphic.color = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the red component of a graphic's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenRed<T>(this T graphic, float start, float end, float duration, EasingFunction easingFunction) where T : Graphic
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var colour = graphic.color;
                colour.r = value;
                graphic.color = colour;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the green component of a graphic's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenGreen<T>(this T graphic, float start, float end, float duration, EasingFunction easingFunction) where T : Graphic
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var colour = graphic.color;
                colour.g = value;
                graphic.color = colour;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the blue component of a graphic's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenBlue<T>(this T graphic, float start, float end, float duration, EasingFunction easingFunction) where T : Graphic
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var colour = graphic.color;
                colour.b = value;
                graphic.color = colour;
            };
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the alpha component of a graphic's colour.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenAlpha<T>(this T graphic, float start, float end, float duration, EasingFunction easingFunction) where T : Graphic
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value =>
            {
                var colour = graphic.color;
                colour.a = value;
                graphic.color = colour;
            };
            return tween;
        }

        #endregion

        #region AudioSource

        /// <summary>
        ///     Create a new instance that tweens the volume of an audio source.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenVolume(this AudioSource audioSource, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => audioSource.volume = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the pitch of an audio source.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenPitch(this AudioSource audioSource, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => audioSource.pitch = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the spatial blend of an audio source.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenSpatialBlend(this AudioSource audioSource, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => audioSource.spatialBlend = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the stereo pan of an audio source.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenPanStereo(this AudioSource audioSource, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => audioSource.panStereo = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the playback time of an audio source.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenTime(this AudioSource audioSource, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => audioSource.time = value;
            return tween;
        }

        #endregion

        #region Light

        /// <summary>
        ///     Create a new instance that tweens the intensity of a light.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenIntensity(this Light light, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => light.intensity = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the range of a light.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenRange(this Light light, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => light.range = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the spot angle of a light.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenSpotAngle(this Light light, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => light.spotAngle = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the colour of a light.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Color> TweenColour(this Light light, Color start, Color end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => light.color = value;
            return tween;
        }

        #endregion

        #region Camera

        /// <summary>
        ///     Create a new instance that tweens the field of view of a camera.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenFieldOfView(this Camera camera, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => camera.fieldOfView = value;
            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens the orthographic size of a camera.
        /// </summary>
        /// <inheritdoc cref="Tween.Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> TweenOrthographicSize(this Camera camera, float start, float end, float duration, EasingFunction easingFunction)
        {
            var tween = Tween.Create(start, end, duration, easingFunction);
            tween.Updated += value => camera.orthographicSize = value;
            return tween;
        }

        #endregion
    }
}