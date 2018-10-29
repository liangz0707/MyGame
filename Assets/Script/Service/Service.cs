/* *
 * 服务器定位：完全脱离单例模式，仍然能向全局提供访问点的服务。
 * */
using UnityEngine;
using UnityEditor;


public class ServiceLocator 
{
    static public void prodive(IMoveControlService service) { service_input = service; }
    static public void prodive(IMouseControlService service) { service_mouse = service; }
    static public void prodive(IActionControlService service) { service_Action = service; }
    static public void prodive(IInputEventService service) { service_event = service; }
    static public void prodive(ICameraService service) { service_camera = service; }
    static public void prodive(IMapService service) { service_map = service; }

    static public IMoveControlService getInputSetvice() {
        if(service_input == null)
        {
            return new NullKeyBoardControlService();
        }
        else
        {
            return service_input;
        }
    }

    static public IInputEventService getInputEventSetvice()
    {
        if (service_event == null)
        {
            return new NullInputEventService();
        }
        else
        {
            return service_event;
        }
    }

    static public IMouseControlService getMouseSetvice()
    {
        if (service_mouse == null)
        {
            return new NullMouseControlService();
        }
        else
        {
            return service_mouse;
        }
    }

    static public IActionControlService getActionService()
    {
        if (service_Action == null)
        {
            return new NullActionControlService();
        }
        else
        {
            return service_Action;
        }
    }


    static public ICameraService getCameraService()
    {
        if (service_camera == null)
        {
            return new NullCameraService();
        }
        else
        {
            return service_camera;
        }
    }

    static public IMapService getMapService()
    {
        if (service_map == null)
        {
            return new NullMapService();
        }
        else
        {
            return service_map;
        }
    }

    static IMoveControlService service_input;
    static IMouseControlService service_mouse; 
    static IInputEventService service_event;
    static IActionControlService service_Action;
    static ICameraService service_camera;
    static IMapService service_map;

}
    