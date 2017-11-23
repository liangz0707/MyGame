using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class AbstractCameraCommand
{
    public abstract void Execute(ICameraComponent camComponent, float xOffset, float yOffset, float zoomOffset, float x, float y);

}

public class CameraRightCommandImpl : AbstractCameraCommand
{
    public override void Execute(ICameraComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        posComponent.TurnHerizental(xOffset);
        posComponent.TurnVerticel(yOffset);
    }
}

public class CameraLeftCommandImpl : AbstractCameraCommand
{
    public override void Execute(ICameraComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(posComponent.ScreenPointToRay(new Vector3(x,y,0)), out hit, 100f);
        if (isHit)
        {
            // 左键拾取。
            // 这里需要对场景中的所有可以去物品进行管理：SetAim(hit.collider.gameObject.name);
        }
    }
}

public class CameraZoomCommandImpl : AbstractCameraCommand
{
    public override void Execute(ICameraComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        posComponent.ZoomIn(zoomOffset);
    }
}