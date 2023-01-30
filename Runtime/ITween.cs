// File: ITween.cs
// Created by: DavidFDev

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Non-generic wrapper for a tween instance.
    /// </summary>
    public interface ITween
    {
        #region Properties

        /// <summary>
        ///     Easing function being used by the tween animation.
        /// </summary>
        EasingFunction EasingFunction { get; }

        /// <summary>
        ///     Tween is actively being updated.
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        ///     Tween animation is paused.
        /// </summary>
        bool IsPaused { get; set; }

        /// <summary>
        ///     Tween animation should use Time.unscaledDeltaTime.
        /// </summary>
        bool IsUnscaled { get; set; }

        /// <summary>
        ///     Controlling layer that the tween is a part of.
        /// </summary>
        TweenLayer Layer { get; set; }

        /// <summary>
        ///     Starting value of the tween (0%).
        /// </summary>
        object StartValue { get; }

        /// <summary>
        ///     Destination value of the tween (100%).
        /// </summary>
        object EndValue { get; }

        /// <summary>
        ///     Current value of the tween.
        /// </summary>
        object CurrentValue { get; }

        /// <summary>
        ///     Time that the tween animation takes (seconds).
        /// </summary>
        float TotalDuration { get; }

        /// <summary>
        ///     Elapsed time of the tween animation (0.0 - TotalDuration).
        /// </summary>
        float ElapsedTime { get; }

        #endregion

        #region Methods

        /// <summary>
        ///     Begin or restart the tween.
        /// </summary>
        /// <param name="duration">Optionally change the tween's duration to a new value or, if null, remain the same.</param>
        void Start(float? duration = null);

        /// <summary>
        ///     End the tween prematurely.
        /// </summary>
        /// <param name="invokeOnComplete">External completion logic should be invoked.</param>
        void Stop(bool invokeOnComplete = false);

        #endregion
    }
}