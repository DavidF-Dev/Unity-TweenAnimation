using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Control all tweens in a layer at once.
    /// </summary>
    public sealed class TweenLayer : IReadOnlyList<Tween>
    {
        #region Static fields
        
        [PublicAPI, NotNull]
        public static readonly TweenLayer Default = new TweenLayer();
        
        #endregion
        
        #region Fields

        [NotNull]
        private readonly HashSet<Tween> _tweens = new HashSet<Tween>();

        #endregion
        
        #region Properties

        /// <summary>
        ///     Whether all tween animations are paused on this layer.
        /// </summary>
        [PublicAPI]
        public bool IsPaused { get; set; }
        
        [PublicAPI]
        public int Count => _tweens.Count;
        
        [PublicAPI, NotNull]
        public Tween this[int index] => _tweens.ElementAt(index);

        #endregion

        #region Methods

        /// <summary>
        ///     Start all tweens on this layer.
        /// </summary>
        /// <param name="duration">Optionally change the tween's duration to a new value or, if null, remain the same.</param>
        [PublicAPI]
        public void StartAll(float? duration = null)
        {
            foreach (var tween in _tweens)
            {
                tween.Start(duration);
            }
        }
        
        /// <summary>
        ///     Stop all tweens on this layer.
        /// </summary>
        [PublicAPI]
        public void StopAll()
        {
            foreach (var tween in _tweens)
            {
                tween.Stop();
            }
        }
        
        public IEnumerator<Tween> GetEnumerator()
        {
            return _tweens.GetEnumerator();
        }
        
        internal void AddToLayer([NotNull] Tween tween)
        {
            _tweens.Add(tween);
        }

        internal void RemoveFromLayer([NotNull] Tween tween)
        {
            _tweens.Remove(tween);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

        public override bool keepWaiting => Layer.Any(x => x.IsActive);

        #endregion
    }
    
    #endregion
}