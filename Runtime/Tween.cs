// File: Tween.cs
// Purpose: Various static tweening methods and modifiable tween instance
// Created by: DavidFDev

using System;
using System.Collections;
using UnityEngine;

namespace DavidFDev.Tween
{
    public delegate T LerpFunction<T>(T a, T b, float t);

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
            _mono = new GameObject("Tween").AddComponent<TweenMono>();
            _mono.gameObject.hideFlags = HideFlags.HideInHierarchy;
            _mono.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
            UnityEngine.Object.DontDestroyOnLoad(_mono.gameObject);
        }

        #endregion

        #region Static methods

        public static Tween Create<T>(T start, T end, float duration, LerpFunction<T> lerpFunction, EasingFunction easingFunction, bool begin = true, Action<T> onUpdate = null, Action onComplete = null)
        {
            if (duration < 0f)
            {
                throw new ArgumentException("Tween cannot have a negative duration", nameof(duration));
            }

            if (lerpFunction == null)
            {
                throw new ArgumentNullException(nameof(lerpFunction));
            }

            if (easingFunction == null)
            {
                throw new ArgumentNullException(nameof(easingFunction));
            }

            Tween tween = new Tween
            {
                StartValue = start,
                EndValue = end,
                TotalDuration = duration,
                LerpFunction = (a, b, t) => lerpFunction((T)a, (T)b, t),
                EasingFunction = easingFunction,
                _onUpdate = x => onUpdate((T)x),
                _onComplete = onComplete
            };

            if (begin)
            {
                tween.Start();
            }

            return tween;
        }

        public static Tween Create(float start, float end, float duration, EasingFunction easingFunction, bool begin = true, Action<float> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, Mathf.Lerp, easingFunction, begin, onUpdate, onComplete);
        }

        public static Tween Create(double start, double end, float duration, EasingFunction easingFunction, bool begin = true, Action<double> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, (a, b, t) => a + (b - a) * Mathf.Clamp01(t), easingFunction, begin, onUpdate, onComplete);
        }

        public static Tween Create(Vector2 start, Vector2 end, float duration, EasingFunction easingFunction, bool begin = true, Action<Vector2> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, Vector2.Lerp, easingFunction, begin, onUpdate, onComplete);
        }

        public static Tween Create(Vector3 start, Vector3 end, float duration, EasingFunction easingFunction, bool begin = true, Action<Vector3> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, Vector3.Lerp, easingFunction, begin, onUpdate, onComplete);
        }

        public static Tween Create(Vector4 start, Vector4 end, float duration, EasingFunction easingFunction, bool begin = true, Action<Vector4> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, Vector4.Lerp, easingFunction, begin, onUpdate, onComplete);
        }

        public static Tween Create(Quaternion start, Quaternion end, float duration, EasingFunction easingFunction, bool begin = true, Action<Quaternion> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, Quaternion.Lerp, easingFunction, begin, onUpdate, onComplete);
        }

        public static Tween Create(Color start, Color end, float duration, EasingFunction easingFunction, bool begin = true, Action<Color> onUpdate = null, Action onComplete = null)
        {
            return Create(start, end, duration, Color.Lerp, easingFunction, begin, onUpdate, onComplete);
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

        public bool IsRunning { get; private set; } = false;

        public bool IsPaused { get; set; } = false;

        public object StartValue { get; private set; } = null;

        public object EndValue { get; private set; } = null;

        public object CurrentValue { get; private set; } = null;

        public float TotalDuration { get; private set; } = 0.0f;

        public float ElapsedTime { get; private set; } = 0.0f;

        public LerpFunction<object> LerpFunction { get; private set; } = null;

        public EasingFunction EasingFunction { get; private set; } = null;

        #endregion

        #region Methods

        /// <summary>
        ///     Begin or restart the tween from initial values.
        /// </summary>
        public void Start()
        {
            if (IsRunning)
            {
                Stop();
            }

            _update = _mono.StartCoroutine(Update());
        }

        /// <summary>
        ///     End the tween prematurely.
        /// </summary>
        /// <param name="invokeOnComplete"></param>
        public void Stop(bool invokeOnComplete = false)
        {
            if (!IsRunning)
            {
                return;
            }

            _mono.StopCoroutine(_update);
            IsRunning = false;

            if (invokeOnComplete)
            {
                UpdateOnComplete();
            }
        }

        /// <summary>
        ///     Get the percentage of the tween's completion (0.0 - 1.0).
        /// </summary>
        /// <returns></returns>
        public float GetProgress()
        {
            return ElapsedTime / TotalDuration;
        }

        private IEnumerator Update()
        {
            // Initialise
            IsRunning = true;
            IsPaused = false;
            ElapsedTime = 0.0f;

            // Begin loop
            while (ElapsedTime <= TotalDuration)
            {
                while (IsPaused)
                {
                    yield return null;
                }

                UpdateCurrentValue(LerpFunction(StartValue, EndValue, EasingFunction(ElapsedTime / TotalDuration)));
                ElapsedTime += Time.deltaTime;
                yield return null;
            }

            // Snap to the end value
            UpdateCurrentValue(LerpFunction(StartValue, EndValue, 1.0f));

            // Invoke external completion logic
            UpdateOnComplete();

            IsRunning = false;
        }

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