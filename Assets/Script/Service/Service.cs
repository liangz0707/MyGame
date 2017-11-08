﻿/* *
 * 服务器定位：完全脱离单例模式，仍然能向全局提供访问点的服务。
 * */
using UnityEngine;
using UnityEditor;


public class ServiceLocator 
{
    static public void prodive(IAudioService service){ service_audio = service; }
    static public void prodive(IKeyBoardControlService service) { service_input = service; }
    static public void prodive(IMouseControlService service) { service_mouse = service; }
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

    static public IKeyBoardControlService getInputSetvice() {
        if(service_input == null)
        {
            return new NullKeyBoardControlService();
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

    static public IMouseControlService getMouseSetvice()
    {
        if (service_input == null)
        {
            return new NullMouseControlService();
        }
        else
        {
            return service_mouse;
        }
    }

    static IKeyBoardControlService service_input;
    static IMouseControlService service_mouse; 
    static IAudioService service_audio;
    static IInputEventService service_event;
    
}
    