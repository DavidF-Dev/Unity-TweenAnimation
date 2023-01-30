// File: WaitForTween.cs
// Created by: DavidFDev

using UnityEngine;

namespace DavidFDev.Tweening
{
    /// <summary>
    ///     Yield instruction that waits for a given tween instance to finish.<br />
    ///     Usage: yield return new WaitForTween(...)
    /// </summary>
    public sealed class WaitForTween : CustomYieldInstruction
    {
        #region Fields

        public readonly ITween Tween;

        #endregion

        #region Constructors

        public WaitForTween(ITween tween)
        {
            Tween = tween;
        }

        #endregion

        #region Properties

        public override bool keepWaiting => Tween?.IsActive ?? false;

        #endregion
    }
}