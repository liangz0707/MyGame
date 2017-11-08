/* *
 * 服务器定位：完全脱离单例模式，仍然能向全局提供访问点的服务。
 * */
using UnityEngine;
using UnityEditor;


public class ServiceLocator 
{
    static public void prodive(IAudioService service){ service_audio = service; }
    static public void prodive(IInputControlService service) { service_input = service; }
    static public void prodive(IInputEventService service) { service_event = service; }
    
    static public IAudioService getAudioSetvice() {
        if (service_audio == null)
        {
            return new NullAudioService();
        }
        else
        {
            return service_audio;
        }
    }

    static public IInputControlService getInputSetvice() {
        if(service_input == null)
        {
            return new NullInputConrtolService();
        }
        else
        {
            return service_input;
        }
    }

    static public IInputEventService getEventSetvice()
    {
        if (service_input == null)
        {
            return new NullInputEventService();
        }
        else
        {
            return service_event;
        }
    }

    static IInputControlService service_input;
    static IAudioService service_audio;
    static IInputEventService service_event;
    
}
    