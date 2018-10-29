using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class AbstractCameraCommand
{
    public abstract void Execute(float xOffset, float yOffset, float zoomOffset, float x, float y);

}

public class CameraRightCommandImpl : AbstractCameraCommand
{
    public override void Execute( float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        ServiceLocator.getCameraService().TurnHerizental(xOffset);
        ServiceLocator.getCameraService().TurnVerticel(yOffset);
    }
}

public class CameraLeftCommandImpl : AbstractCameraCommand
{
    public override void Execute( float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        MouseState ms = ServiceLocator.getInputEventSetvice().GetMouseState();
        GameObject obj = ms.selectedItem;
        GameObject ob;
        bool Created = ControllerCenter.Instance.gameobjectSystem.Get(1, out ob);
        if (Created == true)
        {
            StripSimulate ss = ob.GetComponent<StripSimulate>();
            if (ss != null)
            {
                ss.TrackPointB.transform.SetParent(obj.transform);
                ss.TrackPointB.transform.localPosition = Vector3.zero;
            }
            return;
        }

        if (obj != null && obj.name.StartsWith("HangerPoint"))
        {
            ItemFactory.CreateHangerItem(1, 0, obj.transform.position);
            if(ControllerCenter.Instance.gameobjectSystem.Get(1,out ob))
            {
                StripSimulate ss = ob.GetComponent<StripSimulate>();
                if(ss!= null)
                {
                    PlayerProduct pp = ControllerCenter.Instance.playerSystem.GetMainPlayer();
                    GameObject PlayerObject;
                    if (ControllerCenter.Instance.gameobjectSystem.Get(0, out PlayerObject))
                    {
                        if (ControllerCenter.Instance.gameobjectSystem.Get(0, out ob))
                        {
                            ss.TrackPointA.SetParent(PlayerObject.transform);
                            ss.TrackPointA.localPosition = Vector3.zero;
                            ss.TrackPointB.SetParent(obj.transform);
                            ss.TrackPointB.localPosition = Vector3.zero;
                        }
                    }
                        
                }
            }
        }
    }

    private Transform GetChildByName(Transform t, string name)
    {
        int c = t.childCount;
        Transform r = t;
        for (int i = 0; i < c; i++)
        {
            if (t.GetChild(i).name == name)
            {
                r = t.GetChild(i);
            }
        }
        return r;
    }
}



public class CameraZoomCommandImpl : AbstractCameraCommand
{
    public override void Execute(float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        ServiceLocator.getCameraService().ZoomIn(zoomOffset);
    }
}