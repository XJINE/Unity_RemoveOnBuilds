using RemoveOnBuilds;

public class RemoveDebugTagObjectsOnBuild : RemoveTaggedObjectOnBuild
{
    protected override string Tag                       => "Debug";
    protected override bool   RemoveInEditorApplication => true;
}