# Documentation
It is recommended to view this file in a markdown viewer.
View on [GitHub](https://github.com/DavidF-Dev/Unity-TweenAnimation/blob/main/DOCUMENTATION.md). 

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

Furthermore, there is also an ``EaseType`` enum which can be used if you need to expose an easing function in the unity inspector. Use ``Ease.GetEasingFunction()`` to convert between enum value and easing function.

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