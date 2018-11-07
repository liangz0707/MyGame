using UnityEngine;
/* *
 * 这是整个游戏进程的中央控制器
 * 可以看做是一个中介者模式，同时通过单例模式向其他模块提供调用。
 * 任何一个模块都能够通过类访问这个模块。
 * 到了后面可能会用事件队列带简化这一部分的功能。
 * 
 * */
// 中介者,使用单例向外提供
class ControllerCenter
{
    public RendererSystem renderSystem;
    public PlayerSystem playerSystem;
    public ActionSystem ActionSystem;
    public GameObjectSystem gameobjectSystem;
    public ItemSystem itemSystem;
    public SkillItemSystem skillitemSystem;

    private static ControllerCenter instance = null;
    
    // 单例的使用
    private ControllerCenter()
    {
        renderSystem = new RendererSystem();
        playerSystem = new PlayerSystem();
        ActionSystem = new ActionSystem();
        gameobjectSystem = new GameObjectSystem();
        itemSystem = new ItemSystem();
        skillitemSystem = new SkillItemSystem();
    }

    public static ControllerCenter Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ControllerCenter();
            }
            return instance;
        }
    }

    public void Update()
    {
        renderSystem.Update();
        playerSystem.Update();
        ActionSystem.Update();
        gameobjectSystem.Update();
        itemSystem.Update();
        skillitemSystem.Update();
    }
}


