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
    ShapeManager m_shapeMan;
    PlayerManager m_playerMan;
    SkillManager m_skillMan;

    private static ControllerCenter instance = null;

    public void AddShape(IShapeProduct shape)
    {
        m_shapeMan.AddShape(shape);
    }

    public PlayerProduct GetMainPlayer()
    {
        return m_playerMan.GetMainPlayer();
    }

    public void SetMainPlayer(PlayerProduct player)
    {
        m_playerMan.SetMainPlayer(player);
    }

    public void AddSkill(ISkillProduct skill)
    {
        m_skillMan.AddSkill(skill);
    }


    // 单例的使用
    private ControllerCenter()
    {
        m_shapeMan = new ShapeManager();
        m_playerMan = new PlayerManager();
        m_skillMan = new SkillManager();
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
        m_shapeMan.Update();
        m_playerMan.Update();
        m_skillMan.Update();
    }
}


