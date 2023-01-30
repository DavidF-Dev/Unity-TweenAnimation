// File: WaitForTweenLayer.cs
// Created by: DavidFDev

using UnityEngine;

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Yield instruction that waits for all tweens in a layer to finish.<br />
    ///     Usage: yield return new WaitForTweenLayer(...)
    /// </summary>
    public sealed class WaitForTweenLayer : CustomYieldInstruction
    {
        #region Fields

        public readonly TweenLayer Layer;

        #endregion

        #region Constructors

        public WaitForTweenLayer(TweenLayer layer)
        {
            Layer = layer;
        }

        #endregion

        #region Properties

        public override bool keepWaiting
        {
            get
            {
                if (Layer == null)
                {
                    return false;
                }

                foreach (var tweenRef in Layer.Tweens)
                {
                    if (tweenRef.TryGetTarget(out var tween) && tween.IsActive)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        #endregion
    }
}