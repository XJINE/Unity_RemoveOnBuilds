using RemoveOnBuilds;

public class RemoveDebugTaggedObjectsOnBuild : RemoveTaggedObjectsOnBuild
{
    protected override string Tag                       => "Debug";
    protected override bool   RemoveInEditorApplication => true;
}