using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class AbstractCameraCommand
{
    public abstract void Execute(CameraComponent camComponent, float xOffset, float yOffset, float zoomOffset, float x, float y);

}

public class CameraTurnRightCommandImpl : AbstractCameraCommand
{
    public override void Execute(CameraComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        posComponent.TurnHerizental(xOffset);
        posComponent.TurnVerticel(yOffset);
    }
}

public class CameraTurnLeftCommandImpl : AbstractCameraCommand
{
    public override void Execute(CameraComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
    }
}

public class CameraZoomCommandImpl : AbstractCameraCommand
{
    public override void Execute(CameraComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        posComponent.ZoomIn(zoomOffset);
    }
}