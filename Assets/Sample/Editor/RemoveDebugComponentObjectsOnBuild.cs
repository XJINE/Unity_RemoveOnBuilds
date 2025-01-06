using RemoveOnBuilds;

public class RemoveDebugComponentObjectsOnBuild : RemoveComponentOnBuild<Debug>
{
    protected override bool RemoveComponentParentObject => true;
}