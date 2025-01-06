# Unity_RemoveOnBuilds

Remove some components or objects when building the scene.

## Importing

You can use Package Manager or import it directly.

```
https://github.com/XJINE/Unity_RemoveOnBuilds.git?path=Assets/Packages/RemoveOnBuilds
```

## How to Use

Inherit the following classes and override their properties.

```csharp
public abstract class RemoveOnBuild
{
    protected virtual bool RemoveInEditorApplication { get; } = false;
    protected virtual bool IgnoreDevelopmentBuild    { get; } = false;
}

public abstract class RemoveComponentsOnBuild<T> : RemoveOnBuild
{
    protected virtual bool RemoveParentObject { get; } = false;
}

public abstract class RemoveTaggedObjectsOnBuild : RemoveOnBuild
{
    protected virtual string Tag { get; } = string.Empty;
}
```
