// File: TweenLayer.cs
// Created by: DavidFDev

using System;
using System.Collections.Generic;
using UnityEngine;

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Control all tweens in a layer at once.
    /// </summary>
    public sealed class TweenLayer
    {
        #region Static Fields and Constants

        public static readonly TweenLayer Default = new TweenLayer();

        #endregion

        #region Fields

        private readonly List<WeakReference<ITween>> _tweens;
        private float _speed;

        #endregion

        #region Constructors

        public TweenLayer()
        {
            _tweens = new List<WeakReference<ITween>>();
            _speed = 1f;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     All tween animations are paused on this layer.
        /// </summary>
        public bool IsPaused { get; set; }

        /// <summary>
        ///     Playback speed (time factor) of all tween animations on this layer.
        /// </summary>
        public float Speed
        {
            get => _speed;
            set => _speed = Mathf.Max(0f, value);
        }

        internal IEnumerable<WeakReference<ITween>> Tweens => _tweens;

        #endregion

        #region Methods

        /// <summary>
        ///     Start all tweens on this layer.
        /// </summary>
        /// <param name="duration">Optionally change the tween's duration to a new value or, if null, remain the same.</param>
        public void StartAll(float? duration = null)
        {
            foreach (var tweenRef in _tweens)
            {
                if (!tweenRef.TryGetTarget(out var tween))
                {
                    continue;
                }

                tween.Start(duration);
            }
        }

        /// <summary>
        ///     Stop all tweens on this layer.
        /// </summary>
        public void StopAll(bool invokeOnComplete = false)
        {
            foreach (var tweenRef in _tweens)
            {
                if (!tweenRef.TryGetTarget(out var tween))
                {
                    continue;
                }

                tween.Stop(invokeOnComplete);
            }
        }

        internal void AddToLayer(ITween tween)
        {
            _tweens.Add(new WeakReference<ITween>(tween));
        }

        internal void RemoveFromLayer(ITween tween)
        {
            for (var i = 0; i < _tweens.Count; i += 1)
            {
                if (!_tweens[i].TryGetTarget(out var target) || target != tween)
                {
                    continue;
                }

                _tweens.RemoveAt(i);
                return;
            }
        }

        #endregion
    }
}