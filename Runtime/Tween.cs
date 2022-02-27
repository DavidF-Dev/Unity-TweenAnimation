// File: Tween.cs
// Purpose: Various static tweening methods and a tween instance
// Created by: DavidFDev

using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
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
    [NotNull]
    public delegate T LerpFunction<T>([NotNull] T a, [NotNull] T b, float t);

    /// <summary>
    ///     Static Create() methods for constructing tween animation instances.
    ///     Use Start() and Stop() on an instance to control playback.
    /// </summary>
    public sealed class Tween
    {
        #region Static fields and constants

        /// <summary>
        ///     Package version.
        /// </summary>
        [PublicAPI, NotNull]
        public static readonly Version Version = new Version(1, 0, 1);

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
            var monoObj = _mono.gameObject;
            monoObj.hideFlags = HideFlags.HideInHierarchy;
            _mono.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
            UnityEngine.Object.DontDestroyOnLoad(monoObj);
        }

        #endregion

        #region Static methods

        /// <summary>
        ///     Create a new tweening instance for a specified lerping type.
        /// </summary>
        /// <typeparam name="T">Lerping type.</typeparam>
        /// <param name="start">Starting value (0%).</param>
        /// <param name="end">Destination value (100%).</param>
        /// <param name="duration">Time that the tweening animation should take (seconds).</param>
        /// <param name="lerpFunction">Lerping function to use.</param>
        /// <param name="easingFunction">Easing function to use (defaults to Ease.Linear).</param>
        /// <param name="begin">Whether to begin the animation straight away or wait for Start() to be called on the instance (defaults to true).</param>
        /// <param name="onUpdate">Invoked when the tweened value is updated, providing the current value.</param>
        /// <param name="onComplete">Invoked when the tween is completed.</param>
        /// <returns>Tweening instance that can be used to control playback.</returns>
        [PublicAPI, CanBeNull]
        public static Tween Create<T>([NotNull] T start, [NotNull] T end, float duration, [NotNull] LerpFunction<T> lerpFunction, [CanBeNull] EasingFunction easingFunction = null, bool begin = true, [CanBeNull] Action<T> onUpdate = null, [CanBeNull] Action onComplete = null)
        {
            if (duration < 0f)
            {
                Debug.LogError("Failed to create tween: cannot have a negative duration.");
                return null;
            }

            // Use a linear easing function if none is specified
            easingFunction ??= Ease.Linear;

            // Initialise a new tween instance
            var tween = new Tween
            {
                StartValue = start,
                EndValue = end,
                TotalDuration = duration,
                LerpFunction = (a, b, t) => lerpFunction((T)a, (T)b, t),
                EasingFunction = easingFunction,
                UnderlyingType = typeof(T),
                _onUpdate = x => onUpdate?.Invoke((T)x),
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
        /// <inheritdoc>
        ///     <cref>Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)</cref>
        /// </inheritdoc>
        [PublicAPI, CanBeNull]
        public static Tween Create(float start, float end, float duration, [CanBeNull] EasingFunction easingFunction = null, bool begin = true, [CanBeNull] Action<float> onUpdate = null, [CanBeNull] Action onComplete = null)
        {
            return Create(start, end, duration, Mathf.LerpUnclamped, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens doubles.
        /// </summary>
        /// <inheritdoc>
        ///     <cref>Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)</cref>
        /// </inheritdoc>
        [PublicAPI, CanBeNull]
        public static Tween Create(double start, double end, float duration, [CanBeNull] EasingFunction easingFunction = null, bool begin = true, [CanBeNull] Action<double> onUpdate = null, [CanBeNull] Action onComplete = null)
        {
            return Create(start, end, duration, (a, b, t) => a + (b - a) * t, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens 2d vectors.
        /// </summary>
        /// <inheritdoc>
        ///     <cref>Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)</cref>
        /// </inheritdoc>
        [PublicAPI, CanBeNull]
        public static Tween Create(Vector2 start, Vector2 end, float duration, [CanBeNull] EasingFunction easingFunction = null, bool begin = true, [CanBeNull] Action<Vector2> onUpdate = null, [CanBeNull] Action onComplete = null)
        {
            return Create(start, end, duration, Vector2.LerpUnclamped, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens 3d vectors.
        /// </summary>
        /// <inheritdoc>
        ///     <cref>Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)</cref>
        /// </inheritdoc>
        [PublicAPI, CanBeNull]
        public static Tween Create(Vector3 start, Vector3 end, float duration, [CanBeNull] EasingFunction easingFunction = null, bool begin = true, [CanBeNull] Action<Vector3> onUpdate = null, [CanBeNull] Action onComplete = null)
        {
            return Create(start, end, duration, Vector3.LerpUnclamped, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens 4d vectors.
        /// </summary>
        /// <inheritdoc>
        ///     <cref>Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)</cref>
        /// </inheritdoc>
        [PublicAPI, CanBeNull]
        public static Tween Create(Vector4 start, Vector4 end, float duration, [CanBeNull] EasingFunction easingFunction = null, bool begin = true, [CanBeNull] Action<Vector4> onUpdate = null, [CanBeNull] Action onComplete = null)
        {
            return Create(start, end, duration, Vector4.LerpUnclamped, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens quaternions.
        /// </summary>
        /// <inheritdoc>
        ///     <cref>Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)</cref>
        /// </inheritdoc>
        [PublicAPI, CanBeNull]
        public static Tween Create(Quaternion start, Quaternion end, float duration, [CanBeNull] EasingFunction easingFunction = null, bool begin = true, [CanBeNull] Action<Quaternion> onUpdate = null, [CanBeNull] Action onComplete = null)
        {
            return Create(start, end, duration, Quaternion.LerpUnclamped, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens colours.
        /// </summary>
        /// <inheritdoc>
        ///     <cref>Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)</cref>
        /// </inheritdoc>
        [PublicAPI, CanBeNull]
        public static Tween Create(Color start, Color end, float duration, [CanBeNull] EasingFunction easingFunction = null, bool begin = true, [CanBeNull] Action<Color> onUpdate = null, [CanBeNull] Action onComplete = null)
        {
            return Create(start, end, duration, Color.LerpUnclamped, easingFunction, begin, onUpdate, onComplete);
        }

        /// <summary>
        ///     Create a new instance that tweens an object's property (advanced).
        /// </summary>
        /// <param name="target">Reference to the target object that the property is declared on.</param>
        /// <param name="propertyName">Name of the property (recommend using nameof()).</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="duration"></param>
        /// <param name="lerpFunction"></param>
        /// <param name="easingFunction"></param>
        /// <param name="begin"></param>
        /// <param name="onUpdate"></param>
        /// <param name="onComplete"></param>
        /// <inheritdoc>
        ///     <cref>Create{T}(T, T, float, LerpFunction{T}, EasingFunction, bool, Action{T}, Action)</cref>
        /// </inheritdoc>
        [PublicAPI, CanBeNull]
        public static Tween Create<T>([NotNull] object target, [NotNull] string propertyName, [NotNull] T start, [NotNull] T end, float duration, [NotNull] LerpFunction<T> lerpFunction, [CanBeNull] EasingFunction easingFunction = null, bool begin = true, [CanBeNull] Action<T> onUpdate = null, [CanBeNull] Action onComplete = null)
        {
            // Find the property on the target object by name
            var property = target.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            // Check that the property is found
            if (property == null)
            {
                Debug.LogError($"Failed to create tween: unable to find property \"{propertyName}\" on object \"{target.GetType().Name}\".");
                return null;
            }

            // Ensure that the property type matches the provided generic type
            if (property.PropertyType.IsAssignableFrom(typeof(T)))
            {
                Debug.LogError($"Failed to create tween: unable to cast property type \"{property.PropertyType.Name}\" to tween type \"{typeof(T).Name}\".");
            }

            return Create(start, end, duration, lerpFunction, easingFunction, begin, x =>
            {
                property.SetValue(target, x);
                onUpdate?.Invoke(x);
            }, onComplete);
        }

        #endregion

        #region Fields

        private Coroutine _update;

        private Action<object> _onUpdate;

        private Action _onComplete;

        [NotNull]
        private TweenLayer _layer;

        #endregion

        #region Constructors

        private Tween()
        {
            StartValue = null!;
            EndValue = null!;
            LerpFunction = null!;
            EasingFunction = null!;
            UnderlyingType = null!;
            _layer = TweenLayer.Default;
            _layer.AddToLayer(this);
        }

        ~Tween()
        {
            _layer.RemoveFromLayer(this);
            _layer = null!;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Whether the tween is actively being updated. Set via Start() and Stop().
        /// </summary>
        [PublicAPI]
        public bool IsActive { get; private set; }

        /// <summary>
        ///     Whether the tween animation is paused.
        /// </summary>
        [PublicAPI]
        public bool IsPaused { get; set; }

        /// <summary>
        ///     Whether the tween animation is able to update. Affected by pausing and time scale.
        /// </summary>
        [PublicAPI]
        public bool IsAbleToUpdate => !IsPaused && !Layer.IsPaused && Layer.Speed > 0f && (IsUnscaled || Time.timeScale > 0f);
        
        /// <summary>
        ///     Whether the tween animation should use Time.unscaledDeltaTime.
        /// </summary>
        [PublicAPI]
        public bool IsUnscaled { get; set; }

        /// <summary>
        ///     Controlling layer that the tween is a part of.
        /// </summary>
        [PublicAPI, NotNull]
        public TweenLayer Layer
        {
            get => _layer;
            set
            {
                if (value == _layer)
                {
                    Debug.LogError("Failed to set tween layer: already on the specified layer.");
                    return;
                }

                _layer.RemoveFromLayer(this);
                _layer = value;
                _layer.AddToLayer(this);
            }
        }

        /// <summary>
        ///     Starting value of the tween (0%).
        /// </summary>
        [PublicAPI, NotNull]
        public object StartValue { get; private set; }

        /// <summary>
        ///     Destination value of the tween (100%).
        /// </summary>
        [PublicAPI, NotNull]
        public object EndValue { get; private set; }

        /// <summary>
        ///     Current value of the tween.
        /// </summary>
        [PublicAPI, CanBeNull]
        public object CurrentValue { get; private set; }

        /// <summary>
        ///     Time that the tween animation takes (seconds).
        /// </summary>
        [PublicAPI]
        public float TotalDuration { get; private set; }

        /// <summary>
        ///     Elapsed time of the tween animation (0.0 - TotalDuration).
        /// </summary>
        [PublicAPI]
        public float ElapsedTime { get; private set; }

        /// <summary>
        ///     Lerp function being used by the tween animation.
        /// </summary>
        [PublicAPI, NotNull]
        public LerpFunction<object> LerpFunction { get; private set; }

        /// <summary>
        ///     Easing function being used by the tween animation.
        /// </summary>
        [PublicAPI, NotNull]
        public EasingFunction EasingFunction { get; private set; }

        /// <summary>
        ///     Type of the value that is being tweened.
        /// </summary>
        [PublicAPI, NotNull]
        public Type UnderlyingType { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Begin or restart the tween.
        /// </summary>
        /// <param name="duration">Optionally change the tween's duration to a new value or, if null, remain the same.</param>
        [PublicAPI]
        public void Start(float? duration = null)
        {
            if (IsActive)
            {
                Stop();
            }

            // Set a new duration if not-null parameter provided
            if (duration != null)
            {
                if (duration.Value < 0f)
                {
                    Debug.LogError("Failed to start tween: duration cannot be negative.");
                    return;
                }

                TotalDuration = duration.Value;
            }

            _update = _mono.StartCoroutine(Update());
        }

        /// <summary>
        ///     End the tween prematurely.
        /// </summary>
        /// <param name="invokeOnComplete">Whether external completion logic should be invoked.</param>
        [PublicAPI]
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
        [PublicAPI, Pure]
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
        [PublicAPI, Pure, NotNull, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetTweenedValueAt(float progress)
        {
            return LerpFunction(StartValue, EndValue, EasingFunction(progress));
        }

        [PublicAPI, Pure]
        public override string ToString()
        {
            return $"{StartValue} to {EndValue} over {TotalDuration} seconds{(IsActive ? $" ({GetProgress()*100:0.0}%: {CurrentValue ?? "-"}){(!IsAbleToUpdate ? " [Paused]" : "")}" : "")}";
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
            CurrentValue = default;

            // Wait until the end of the frame before starting
            yield return new WaitForEndOfFrame();

            // Begin loop
            while (ElapsedTime <= TotalDuration)
            {
                // Pause if unable to update
                while (!IsAbleToUpdate)
                {
                    yield return null;
                }

                // Perform the tween
                UpdateCurrentValue(GetTweenedValueAt(ElapsedTime / TotalDuration));

                yield return null;

                // Increment elapsed time
                ElapsedTime += (IsUnscaled ? Mathf.Clamp(Time.unscaledDeltaTime, 0f, 0.2f) : Time.deltaTime) * Layer.Speed;
            }

            // Snap to the end value
            ElapsedTime = TotalDuration;
            UpdateCurrentValue(GetTweenedValueAt(1.0f));

            // Invoke external completion logic
            UpdateOnComplete();

            IsActive = false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void UpdateCurrentValue([NotNull] object value)
        {
            CurrentValue = value;

            // Invoke external update logic
            try
            {
                _onUpdate?.Invoke(CurrentValue);
            }
            catch (Exception)
            {
                Debug.LogWarning("Failed to update tween due to an exception. Stopping.");
                Stop();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void UpdateOnComplete()
        {
            try
            {
                _onComplete?.Invoke();
            }
            catch (Exception)
            {
                Debug.LogWarning("Failed to complete tween due to an exception. Stopping.");
            }
        }

        #endregion

        #region Nested types

        private sealed class TweenMono : MonoBehaviour
        {
        }

        #endregion
    }
    
    #region Other types

    /// <summary>
    ///     Yield instruction that waits for a given tween instance to finish.
    ///     Usage: yield return new WaitForTween(...)
    /// </summary>
    public sealed class WaitForTween : CustomYieldInstruction
    {
        #region Fields

        [PublicAPI, CanBeNull]
        public readonly Tween Tween;
        
        #endregion
        
        #region Constructors

        public WaitForTween([CanBeNull] Tween tween)
        {
            Tween = tween;
        }
        
        #endregion
        
        #region Properties

        public override bool keepWaiting => Tween?.IsActive ?? false;

        #endregion
    }
    
    #endregion
}