// File: Tween.cs
// Created by: DavidFDev

using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Lerping function.
    /// </summary>
    /// <param name="t">Progress (0.0 - 1.0).</param>
    /// <returns>Value between a and b.</returns>
    public delegate T LerpFunction<T>(T a, T b, float t) where T : struct;

    /// <summary>
    ///     Tween instance responsible for animating a given value from start to finish over a duration.
    /// </summary>
    public sealed class Tween<T> : ITween where T : struct
    {
        #region Delegates

        /// <summary>
        ///     Passes along the current value of the tween.
        /// </summary>
        public delegate void TweenUpdatedDelegate(T value);

        public delegate void TweenStartedDelegate();

        public delegate void TweenFinishedDelegate();

        #endregion

        #region Fields

        /// <summary>
        ///     Lerp function being used by the tween animation.
        /// </summary>
        public readonly LerpFunction<T> LerpFunction;

        /// <inheritdoc cref="ITween.EasingFunction" />
        public readonly EasingFunction EasingFunction;

        private Coroutine _update;
        private TweenLayer _layer;

        #endregion

        #region Constructors

        public Tween(T start, T end, float duration, LerpFunction<T> lerpFunction, EasingFunction easingFunction)
        {
            StartValue = start;
            EndValue = end;
            TotalDuration = Math.Max(0f, duration);
            LerpFunction = lerpFunction ?? throw new ArgumentNullException(nameof(lerpFunction));
            EasingFunction = easingFunction ?? Ease.Linear;
            _layer = TweenLayer.Default;
            _layer.AddToLayer(this);
        }

        public Tween(Tween<T> copy)
        {
            StartValue = copy.StartValue;
            EndValue = copy.EndValue;
            TotalDuration = copy.TotalDuration;
            LerpFunction = copy.LerpFunction;
            EasingFunction = copy.EasingFunction;
            _layer = copy.Layer;
            _layer.AddToLayer(this);
        }

        #endregion

        #region Properties

        public bool IsActive { get; private set; }

        public bool IsPaused { get; set; }

        public bool IsUnscaled { get; set; }

        public TweenLayer Layer
        {
            get => _layer;
            set
            {
                if (_layer == value || (value == null && _layer == TweenLayer.Default))
                {
                    return;
                }

                _layer.RemoveFromLayer(this);
                _layer = value ?? TweenLayer.Default;
                _layer.AddToLayer(this);
            }
        }

        /// <inheritdoc cref="ITween.StartValue" />
        public T StartValue { get; }

        /// <inheritdoc cref="ITween.EndValue" />
        public T EndValue { get; }

        /// <inheritdoc cref="ITween.CurrentValue" />
        public T CurrentValue { get; private set; }

        public float TotalDuration { get; private set; }

        public float ElapsedTime { get; private set; }

        EasingFunction ITween.EasingFunction => EasingFunction;

        object ITween.StartValue => StartValue;

        object ITween.EndValue => EndValue;

        object ITween.CurrentValue => CurrentValue;

        /// <summary>
        ///     Tween animation is able to update. Affected by pausing and time scale.
        /// </summary>
        private bool IsAbleToUpdate => !IsPaused && !Layer.IsPaused && Layer.Speed > 0f && (!IsUnscaled || Time.timeScale > 0f);

        #endregion

        #region Events

        /// <summary>
        ///     Invoked when the tween is updated.
        /// </summary>
        public event TweenUpdatedDelegate Updated;

        /// <summary>
        ///     Invoked when the tween is started or restarted.
        /// </summary>
        public event TweenStartedDelegate Started;

        /// <summary>
        ///     Invoked when the tween is finished animating.
        /// </summary>
        public event TweenFinishedDelegate Finished;

        #endregion

        #region Methods

        public void Start(float? duration = null)
        {
            if (IsActive)
            {
                Stop();
            }

            // Set a new duration if not-null parameter provided
            if (duration.HasValue)
            {
                TotalDuration = Math.Max(0, duration.Value);
            }

            _update = TweenMono.Instance.StartCoroutine(Update());
        }

        public void Stop(bool invokeOnComplete = false)
        {
            if (!IsActive)
            {
                return;
            }

            // Forcefully stop the coroutine
            TweenMono.Instance.StopCoroutine(_update);
            _update = null;
            IsActive = false;

            if (!invokeOnComplete)
            {
                return;
            }

            try
            {
                Finished?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogWarning("Failed to complete tween due to an exception. Stopping.");
                Debug.LogException(e);
            }
        }

        /// <summary>
        ///     Coroutine that updates the tweening animation.
        /// </summary>
        private IEnumerator Update()
        {
            // Initialise
            IsActive = true;
            IsPaused = false;
            ElapsedTime = 0f;
            CurrentValue = default;

            // Invoke external start logic
            try
            {
                Started?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to start tween due to an exception. Stopping.");
                Debug.LogException(e);
                Stop();
                yield break;
            }

            // Wait until the end of the frame before starting
            yield return new WaitForEndOfFrame();

            if (TotalDuration != 0f)
            {
                // Begin loop
                while (ElapsedTime <= TotalDuration)
                {
                    // Pause if unable to update
                    while (!IsAbleToUpdate)
                    {
                        yield return null;
                    }

                    // Perform the tween
                    CurrentValue = LerpFunction(StartValue, EndValue, EasingFunction(ElapsedTime / TotalDuration));

                    // Invoke external update logic
                    try
                    {
                        Updated?.Invoke(CurrentValue);
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Failed to update tween due to an exception. Stopping.");
                        Debug.LogException(e);
                        Stop();
                        yield break;
                    }

                    yield return null;

                    // Increment elapsed time
                    ElapsedTime += (IsUnscaled ? Mathf.Clamp(Time.unscaledDeltaTime, 0f, 0.2f) : Time.deltaTime) * Layer.Speed;
                }
            }

            // Snap to the end value
            ElapsedTime = TotalDuration;
            CurrentValue = LerpFunction(StartValue, EndValue, EasingFunction(1f));

            // Invoke external update logic
            try
            {
                Updated?.Invoke(CurrentValue);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to update tween due to an exception. Stopping.");
                Debug.LogException(e);
                Stop();
                yield break;
            }

            if (!IsActive)
            {
                yield break;
            }

            // Invoke external completion logic
            try
            {
                Finished?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to complete tween due to an exception. Stopping.");
                Debug.LogException(e);
            }

            IsActive = false;
        }

        #endregion
    }

    /// <summary>
    ///     Collection of methods for constructing new tween instances for common animation types.
    /// </summary>
    public static class Tween
    {
        #region Static Methods

        /// <summary>
        ///     Create a new tweening instance for a specified lerping type.
        /// </summary>
        /// <typeparam name="T">Lerping type.</typeparam>
        /// <param name="start">Starting value (0%).</param>
        /// <param name="end">Destination value (100%).</param>
        /// <param name="duration">Time that the tweening animation should take (seconds).</param>
        /// <param name="lerpFunction">Lerping function to use.</param>
        /// <param name="easingFunction">Easing function to use (defaults to Ease.Linear).</param>
        /// <returns>Tweening instance that can be used to control playback.</returns>
        public static Tween<T> Create<T>(T start, T end, float duration, LerpFunction<T> lerpFunction, EasingFunction easingFunction) where T : struct
        {
            return new Tween<T>(start, end, duration, lerpFunction, easingFunction);
        }

        /// <summary>
        ///     Create a new instance that tweens floats.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<float> Create(float start, float end, float duration, EasingFunction easingFunction)
        {
            return Create(start, end, duration, Mathf.LerpUnclamped, easingFunction);
        }

        /// <summary>
        ///     Create a new instance that tweens doubles.
        /// </summary>
        /// ///
        /// <inheritdoc cref="Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<double> Create(double start, double end, float duration, EasingFunction easingFunction)
        {
            return Create(start, end, duration, (a, b, t) => a + (b - a) * t, easingFunction);
        }

        /// <summary>
        ///     Create a new instance that tweens 2d vectors.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector2> Create(Vector2 start, Vector2 end, float duration, EasingFunction easingFunction)
        {
            return Create(start, end, duration, Vector2.LerpUnclamped, easingFunction);
        }

        /// <summary>
        ///     Create a new instance that tweens 3d vectors.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector3> Create(Vector3 start, Vector3 end, float duration, EasingFunction easingFunction)
        {
            return Create(start, end, duration, Vector3.LerpUnclamped, easingFunction);
        }

        /// <summary>
        ///     Create a new instance that tweens 4d vectors.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Vector4> Create(Vector4 start, Vector4 end, float duration, EasingFunction easingFunction)
        {
            return Create(start, end, duration, Vector4.LerpUnclamped, easingFunction);
        }

        /// <summary>
        ///     Create a new instance that tweens quaternions.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Quaternion> Create(Quaternion start, Quaternion end, float duration, EasingFunction easingFunction)
        {
            return Create(start, end, duration, Quaternion.LerpUnclamped, easingFunction);
        }

        /// <summary>
        ///     Create a new instance that tweens colours.
        /// </summary>
        /// <inheritdoc cref="Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        public static Tween<Color> Create(Color start, Color end, float duration, EasingFunction easingFunction)
        {
            return Create(start, end, duration, Color.LerpUnclamped, easingFunction);
        }

        /// <summary>
        ///     Create a new instance that tweens an object's property [advanced].
        /// </summary>
        /// <param name="target">Reference to the target object that the property is declared on.</param>
        /// <param name="propertyName">Name of the property (recommend using nameof()).</param>
        /// <inheritdoc cref="Create{T}(T,T,float,LerpFunction{T},DavidFDev.Tweening.EasingFunction)" />
        // ReSharper disable all InvalidXmlDocComment
        public static Tween<T> Create<T>(object target, string propertyName, T start, T end, float duration, LerpFunction<T> lerpFunction, EasingFunction easingFunction) where T : struct
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

            var tween = Create(start, end, duration, lerpFunction, easingFunction);
            tween.Updated += value => property.SetValue(target, value);
            return tween;
        }

        #endregion
    }

    /// <summary>
    ///     Singleton object used for starting coroutines.
    /// </summary>
    [AddComponentMenu("")]
    internal sealed class TweenMono : MonoBehaviour
    {
        #region Static Methods

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#pragma warning disable IDE0051
        private static void Init()
#pragma warning restore IDE0051
        {
            // Create a game object that can be used to start coroutine(s) later
            Instance = new GameObject("Tween").AddComponent<TweenMono>();
            Instance.gameObject.hideFlags = HideFlags.HideInHierarchy;
            Instance.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
            DontDestroyOnLoad(Instance.gameObject);
        }

        #endregion

        #region Properties

        public static TweenMono Instance { get; private set; }

        #endregion
    }
}