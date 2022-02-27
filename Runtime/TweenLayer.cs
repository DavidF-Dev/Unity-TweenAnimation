using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Control all tweens in a layer at once.
    /// </summary>
    public sealed class TweenLayer
    {
        #region Static fields
        
        [PublicAPI, NotNull]
        public static readonly TweenLayer Default = new TweenLayer();
        
        #endregion
        
        #region Fields

        [NotNull]
        private readonly List<WeakReference<Tween>> _tweens = new List<WeakReference<Tween>>();

        private float _speed = 1f;

        #endregion
        
        #region Properties

        /// <summary>
        ///     Whether all tween animations are paused on this layer.
        /// </summary>
        [PublicAPI]
        public bool IsPaused { get; set; }

        /// <summary>
        ///     Playback speed (time factor) of all tween animations on this layer.
        /// </summary>
        [PublicAPI]
        public float Speed
        {
            get => _speed;
            set => _speed = Mathf.Max(0f, value);
        }

        internal IEnumerable<WeakReference<Tween>> Tweens => _tweens;

        #endregion

        #region Methods

        /// <summary>
        ///     Start all tweens on this layer.
        /// </summary>
        /// <param name="duration">Optionally change the tween's duration to a new value or, if null, remain the same.</param>
        [PublicAPI]
        public void StartAll(float? duration = null)
        {
            foreach (var tweenRef in _tweens)
            {
                if (!tweenRef.TryGetTarget(out var tween)) continue;
                tween.Start(duration);
            }
        }
        
        /// <summary>
        ///     Stop all tweens on this layer.
        /// </summary>
        [PublicAPI]
        public void StopAll()
        {
            foreach (var tweenRef in _tweens)
            {
                if (!tweenRef.TryGetTarget(out var tween)) continue;
                tween.Stop();
            }
        }
        
        internal void AddToLayer([NotNull] Tween tween)
        {
            _tweens.Add(new WeakReference<Tween>(tween));
        }

        internal void RemoveFromLayer([NotNull] Tween tween)
        {
            for (var i = 0; i < _tweens.Count; i += 1)
            {
                if (!_tweens[i].TryGetTarget(out var target) || target != tween) continue;
                _tweens.RemoveAt(i);
                return;
            }
        }
        
        #endregion
    }
    
    #region Other types

    /// <summary>
    ///     Yield instruction that waits for all tweens in a layer to finish.
    ///     Usage: yield return new WaitForTweenLayer(...)
    /// </summary>
    public sealed class WaitForTweenLayer : CustomYieldInstruction
    {
        #region Fields

        [PublicAPI, NotNull]
        public readonly TweenLayer Layer;
        
        #endregion
        
        #region Constructors

        public WaitForTweenLayer([NotNull] TweenLayer layer)
        {
            Layer = layer;
        }
        
        #endregion
        
        #region Properties

        public override bool keepWaiting => Layer.Tweens.Any(x => x.TryGetTarget(out var t) && t.IsActive);

        #endregion
    }
    
    #endregion
}