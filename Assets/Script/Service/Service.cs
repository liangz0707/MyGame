/* *
 * 服务器定位：完全脱离单例模式，仍然能向全局提供访问点的服务。
 * */
using UnityEngine;
using UnityEditor;


public class ServiceLocator 
{
    static public void prodive(AudioService service){ service_audio = service; }
    static public void prodive(IInputControlService service) { service_input = service; }



    static public AudioService getAudioSetvice() { return service_audio; }
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



    static IInputControlService service_input;
    static AudioService service_audio;
}
    