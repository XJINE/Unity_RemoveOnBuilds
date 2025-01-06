using RemoveOnBuilds;

public class RemoveDebugComponentsOnBuild : RemoveComponentsOnBuild<Debug>
{
    protected override bool RemoveParentObject => true;
}