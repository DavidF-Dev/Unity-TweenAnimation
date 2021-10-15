// File: Tween.cs
// Purpose: Various static tweening methods and a tween instance
// Created by: DavidFDev

using System;
using System.Collections;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Lerping function.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="t">Progress (0.0 - 1.0).</param>
    /// <returns>Value between a and b.</returns>
    public delegate T LerpFunction<T>(T a, T b, float t);

    /// <summary>
    ///     Static Create() methods for constructing tween animation instances.
    ///     Use Start() and Stop() on an instance to control playback.
    /// </summary>
    public sealed class Tween
    {
        #region Static fields and constants

        private static TweenMono _mono;

        #endregion

        #region Static constructor

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#pragma warning disable IDE0051
        private static void Init()
#pragma warning restore IDE0051
        {
            // Create a game object that can be used to start coroutine(s) later
            _mono = new GameObject("Tween").AddComponent<TweenMono>();
            _mono.gameObject.hideFlags = HideFlags.HideInHierarchy;
            _mono.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
            UnityEngine.Object.DontDestroyOnLoad(_mono.gameObject);
        }

        #endregion

        #region Static methods

        /// <summary>
        ///     Create a new tweening instance for a specified lerpable type.
        /// </summary>
        /// <typeparam name="T">Lerpable type.</typeparam>
        /// <param name="start">Starting value (0%).</param>
        /// <param name="end">Destination value (100%).</param>
        /// <param name="duration">Time that the tweening animation should take (seconds).</param>
        /// <param name="lerpFunction">Lerping function to use.</param>
        /// <param name="easingFunction">Easing function to use (defaults to Ease.Linear).</param>
        /// <param name="begin">Whether to begin the animation straight away or wait for Start() to be called on the instance (defaults to true).</param>
        /// <param name="onUpdate">Invoked when the tweened value is updated, providing the current value.</param>
        /// <param name="onComplete">Invoked when the tween is completed.</param>
        /// <returns>Tweening instance that can be used to control playback.</returns>
        public static Tween Create<T>(T start, T end, float duration, LerpFunction<T> lerpFunction, EasingFunction easingFunction = null, bool begin = true, Action<T> onUpdate = null, Action onComplete = null)
        {
            if (duration < 0f)
            {
                throw new ArgumentException("Tween cannot have a negative duration", nameof(duration));
            }

            if (lerpFunction == null)
            {
                throw new ArgumentNullException(nameof(lerpFunction));
            }

            // Use a linear easing function if none is specified
            if (easingFunction == null)
            {
                easingFunction = Ease.Linear;
            }

            // Initialise a new tween instance
            Tween tween = new Tween
            {
                StartValue = start,
                EndValue = end,
                TotalDuration = duration,
                LerpFunction = (a, b, t) => lerpFunction((T)a, (T)b, t),
                EasingFunction = easingFunction,
                UnderlyingType = typeof(T),
                _onUpdate = x => onUpdate((T)x),
                _onComplete = onComplete
            };

            if (begin)
            {
                tween.Start();
            }

            return tween;
        }

        /// <summary>
        ///     Create a new instance that tweens floats.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween Create(float start, float end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, Mathf.LerpUnclamped, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens doubles.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween Create(double start, double end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<double> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, (a, b, t) => a + (b - a) * t, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens 2d vectors.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween Create(Vector2 start, Vector2 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector2> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, Vector2.LerpUnclamped, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens 3d vectors.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween Create(Vector3 start, Vector3 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector3> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, Vector3.LerpUnclamped, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens 4d vectors.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween Create(Vector4 start, Vector4 end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Vector4> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, Vector4.LerpUnclamped, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens quaternions.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween Create(Quaternion start, Quaternion end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Quaternion> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, Quaternion.LerpUnclamped, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens colours.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween Create(Color start, Color end, float duration, EasingFunction easingFunction = null, bool begin = true, Action<Color> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, Color.LerpUnclamped, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens an object's property (advanced).
        /// </summary>
        /// <param name="target">Reference to the target object that the property is declared on.</param>
        /// <param name="propertyName">Name of the property (recommend using nameof()).</param>
        /// <inheritdoc cref="Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)"/>
        public static Tween Create<T>(object target, string propertyName, T start, T end, float duration, LerpFunction<T> lerpFunction, EasingFunction easingFunction = null, bool begin = true, Action<T> onUpdate = null, Action onComplete = null)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            // Find the property on the target object by name
            PropertyInfo property = target.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            // Check that the property is found
            if (property == null)
            {
                throw new NullReferenceException($"Cannot find property ({propertyName}) on object ({target.GetType().Name}).");
            }

            // Ensure that the property type matches the provided generic type
            if (typeof(T) != property.PropertyType)
            {
                throw new InvalidCastException($"Cannot cast property type ({property.PropertyType.Name}) to tween type ({typeof(T).Name}).");
            }

            return Create(start, end, duration, lerpFunction, easingFunction, begin, x =>
            {
                property.SetValue(target, x);
                onUpdate?.Invoke(x);
            }, onComplete);
        }

        #endregion

        #region Fields

        private Coroutine _update = null;

        private Action<object> _onUpdate = null;

        private Action _onComplete = null;

        #endregion

        #region Constructors

        internal Tween()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Whether the tween is actively being updated. Set via Start() and Stop().
        /// </summary>
        public bool IsActive { get; private set; } = false;

        /// <summary>
        ///     Whether the tween animation is paused.
        /// </summary>
        public bool IsPaused { get; set; } = false;

        /// <summary>
        ///     Starting value of the tween (0%).
        /// </summary>
        public object StartValue { get; private set; } = null;

        /// <summary>
        ///     Destination value of the tween (100%).
        /// </summary>
        public object EndValue { get; private set; } = null;

        /// <summary>
        ///     Current value of the tween.
        /// </summary>
        public object CurrentValue { get; private set; } = null;

        /// <summary>
        ///     Time that the tween animation takes (seconds).
        /// </summary>
        public float TotalDuration { get; private set; } = 0.0f;

        /// <summary>
        ///     Elapsed time of the tween animation (0.0 - TotalDuration).
        /// </summary>
        public float ElapsedTime { get; private set; } = 0.0f;

        /// <summary>
        ///     Lerp function being used by the tween animation.
        /// </summary>
        public LerpFunction<object> LerpFunction { get; private set; } = null;

        /// <summary>
        ///     Easing function being used by the tween animation.
        /// </summary>
        public EasingFunction EasingFunction { get; private set; } = null;

        /// <summary>
        ///     Type of the value that is being tweened.
        /// </summary>
        public Type UnderlyingType { get; private set; } = null;

        #endregion

        #region Methods

        /// <summary>
        ///     Begin or restart the tween.
        /// </summary>
        /// <param name="duration">Optionally change the tween's duration to a new value or, if null, remain the same.</param>
        public void Start(float? duration = null)
        {
            if (IsActive)
            {
                Stop();
            }

            if (duration != null)
            {
                if (duration.Value < 0f)
                {
                    throw new ArgumentException("Tween cannot have a negative duration", nameof(duration));
                }

                TotalDuration = duration.Value;
            }

            _update = _mono.StartCoroutine(Update());
        }

        /// <summary>
        ///     End the tween prematurely.
        /// </summary>
        /// <param name="invokeOnComplete">Whether external completion logic should be invoked.</param>
        public void Stop(bool invokeOnComplete = false)
        {
            if (!IsActive)
            {
                return;
            }

            // Forcefully stop the coroutine
            _mono.StopCoroutine(_update);
            IsActive = false;

            if (invokeOnComplete)
            {
                UpdateOnComplete();
            }
        }

        /// <summary>
        ///     Get the percentage of the tween's completion (0.0 - 1.0).
        /// </summary>
        /// <returns></returns>
        [Pure]
        public float GetProgress()
        {
            return ElapsedTime / TotalDuration;
        }

        /// <summary>
        ///     Get the tweened value at the provided progress percentage.
        ///     0.0 - returns StartValue.
        ///     1.0 - returns EndValue.
        /// </summary>
        /// <param name="progress">Progress between 0.0 and 1.0.</param>
        /// <returns></returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetTweenedValueAt(float progress)
        {
            return LerpFunction(StartValue, EndValue, EasingFunction(progress));
        }

        [Pure]
        public override string ToString()
        {
            return $"{StartValue} -> {EndValue} over {TotalDuration} seconds{(IsActive ? $" ({GetProgress()*100:0.0}%: {CurrentValue ?? "-"}){(IsPaused ? " [Paused]" : "")}" : "")}";
        }

        /// <summary>
        ///     Coroutine that updates the tweening animation.
        ///     Started in Start().
        ///     Forcefully ended in Stop().
        /// </summary>
        /// <returns></returns>
        private IEnumerator Update()
        {
            // Initialise
            IsActive = true;
            IsPaused = false;
            ElapsedTime = 0.0f;

            // Wait until the end of the frame before starting
            yield return new WaitForEndOfFrame();

            // Begin loop
            while (ElapsedTime <= TotalDuration)
            {
                // Pause if paused (duh!)
                while (IsPaused)
                {
                    yield return null;
                }

                // Perform the tween
                UpdateCurrentValue(GetTweenedValueAt(ElapsedTime / TotalDuration));

                yield return null;

                // Increment elapsed time
                ElapsedTime += Time.deltaTime;
            }

            // Snap to the end value
            ElapsedTime = TotalDuration;
            UpdateCurrentValue(GetTweenedValueAt(1.0f));

            // Invoke external completion logic
            UpdateOnComplete();

            IsActive = false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void UpdateCurrentValue(object value)
        {
            CurrentValue = value;

            // Invoke external update logic
            try
            {
                _onUpdate?.Invoke(CurrentValue);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void UpdateOnComplete()
        {
            try
            {
                _onComplete?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        #endregion

        #region Nested types

        private sealed class TweenMono : MonoBehaviour
        {
        }

        #endregion
    }
}