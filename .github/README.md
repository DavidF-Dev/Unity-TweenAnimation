# Tweening Animations for Unity
This package provides an easy solution for **complex tweening animations**. Designed to be simple and intuitive to use, whilst also flexible and configurable.

A tweening animation typically involves moving from one value (A) to another value (B) over a given time (t). For example, fading out an image. The way that the animation travels between the two values can be altered by using an easing function (see [easings.net](https://easings.net) for visual examples). Tweening is a very powerful tool for programmers as it provides a simple way of adding "juice" to your game with just a few lines of code.

<img src="/.github/example1.gif" alt="Tweening example" width="60%"></img>

Features:
- Tween any type (``float``, ``double``, ``Vector2``, ``Vector3``, ``Vector4``, ``Quaternion``, ``Color``).
- Various built-in easing functions (Bounce, Exponential, Sine, etc.)
- Collection of extension methods for tweening common objects (``transform.TweenX``, ``spriteRenderer.TweenAlpha``, etc.)
- Support for custom lerping functions and easing functions (if needed!)

The asset is completely free, but if you'd like to show support you can [buy me a bowl of spaghetti](https://www.buymeacoffee.com/davidfdev) 🍝

## Setup
Simply import the package into your project and you're good to go. No additional setup is required.
- Download directly from the [releases](https://github.com/DavidF-Dev/Unity-TweenAnimation/releases) tab & import in Unity (<i>Assets>Import Package</i>).
- Import via the Unity package manager (<i>Window>Package Manager</i>).
  - Git URL: ``https://github.com/DavidF-Dev/Unity-TweenAnimation.git``</br>
  - <i>Or</i> add the following line to <i>Packages/manifest.json</i>:</br>``"com.davidfdev.tweening": "https://github.com/DavidF-Dev/Unity-TweenAnimation.git"``

## Usage
The tweening manager will set itself up automatically in the background, so no activation is required by you. Simply press 'play' and the systems will have activated. To access the scripts, include the ``DavidFDev.Tweening`` namespace at the top of your file.

### Creating a tweening animation
The method signature for creating a new tweening animation is as follows:</br>
```cs
Tween.Create(start, end, duration, easingFunction, begin, onUpdate, onComplete) : Tween
```
- ``start``: the initial value of the animation (A).
- ``end``: the destination value of the animation (B).
- ``duration``: the total time that the animation will take, in seconds (t).
- ``easingFunction``: the easing function to use - usually one of the built-in options (see below for more details).
- ``begin``: a boolean for whether the tweening animation should start playing straight away (otherwise it will need to be started manually).
- ``onUpdate``: a callback that is invoked when the tweening animation updates itself. The callback provides the current tweened value.
- ``onComplete``: a callback that is invoked when the tweening animation finishes playing.
- Returns a ``Tween`` instance that can be used to control playback.

### Easing functions
Easing functions specify the rate of change of the tweened value over time. I have included various built-in easing functions that can be accessed through the ``Ease`` static class. For example: ``Ease.SineIn``, ``Ease.Linear``, ``Ease.ExpoInOut``, etc.</br>

The easing functions all implement the ``EasingFunction`` delegate. This allows you to seamlessly create your own easing functions if needed:
```cs
public delegate float EasingFunction(float t);
// ...
EasingFunction myEasingFunction = t => t * t;
```

Furthermore, there is also an ``EaseType`` enum which can be used if you need to expose an easing function in the unity inspector. Use ``Ease.Get()`` to convert between enum value and easing function (and vice-versa!)

### Controlling playback
A tween instance contains properties and methods for querying & controlling playback:
- ``IsActive``: Whether the tween is actively being updated. Set via ``Start()`` and ``Stop()``.
- ``IsPaused``: Whether the tween animation is paused.
- ``Start()``: Begin or restart the tween.
- ``Stop()``: End the tween prematurely.

There are other properties and methods which you can see when viewing the code.

### Examples
```cs
Tween.Create(
  start: 0f,
  end: 10f,
  duration: 5f,
  easingFunction: Ease.SineInOut, 
  begin: true, 
  onUpdate: x => Debug.Log(x), 
  onComplete: () => Debug.Log("Finished!"));
```
This call will begin tweening (A = 0) to (B = 10) over (t = 5) seconds using a sine easing function. At each step, the current value will be displayed to the unity console.
</br></br>
```cs
Tween tween = Tween.Create(
  start: Vector2.zero,
  end: Vector2.one * 5f,
  duration: 2.5f,
  easingFunction: Ease.ElasticOut,
  begin: false,
  onUpdate: x => transform.position = x,
  onComplete: null);

tween.Start();
```
This call will create a dormant tween set to animate from (A = (0,0)) to (B = (5, 5)) over (t = 2.5) seconds using an elastic easing function. At each step, the game object's transform will be updated to the current value (moving the game object). However, because ``begin`` is false, the tween will not start playing until ``Start()`` is called.
</br></br>
```cs
transform.TweenX(
  start: transform.position.x,
  end: transform.position.x + 10f,
  duration: 4f);
```
This call uses one of the built-in extension methods that tween's an object's x position 10 units to the right over (t = 4) seconds. The remainder of the arguments are omitted as they are using default values. This means the easing function will default to ``Ease.Linear``.
</br></br>
```cs
SpriteRenderer renderer = GetComponent<SpriteRenderer>();
Tween.Create<Color>(
  start: Color.white,
  end: Color.green,
  duration: 2f,
  lerpFunction: Color.LerpUnclamped,
  easingFunction: Ease.Spike,
  begin: true,
  onUpdate: x => renderer.color = x,
  onComplete: () => renderer.enabled = false);
```
This example shows how to create a generic tweening animation (note that this example is arbitrary as there is already a built-in overload for colours). The method signature is almost identical to the previous examples, however there is a new required parameter: ``lerpFunction``. This of the delegate type, ``LerpFunction`` - and allows you to create custom lerpable tweening types.
</br></br>
```cs
Light light = GetComponent<Light>();
Tween.Create<float>(
  target: light,
  propertyName: nameof(light.intensity),
  start: 1f,
  end: 0f,
  duration: 10f,
  lerpFunction: Mathf.LerpUnclamped,
  easingFunction: Ease.CubicInOut);
```
This call uses an advanced overload for tweening a property on an object reference. The ``target`` parameter is an object reference and ``propertyName`` is the name of a declared property on the target type. This example will begin tweening a light's intensity from (A = 1) to (B = 0) over (t = 10) seconds using a cubic easing function (note that an equivalent extension method already exists: ``light.TweenIntensity()``.)

## Contact
If you have any questions or would like to get in contact, shoot me an email at contact@davidfdev.com. Alternatively, you can send me a direct message on Twitter at [@DavidF_Dev](https://twitter.com/DavidF_Dev).</br></br>
Consider showing support by [buying me a bowl of spaghetti](https://www.buymeacoffee.com/davidfdev) 🍝</br>
View my other Unity tools on my [website](https://www.davidfdev.com/tools) 🔨
