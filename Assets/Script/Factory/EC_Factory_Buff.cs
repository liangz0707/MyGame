
public class BuffFactory : IBuffFactory
{
    public override IBuffProduct CreateImtHurtBuff(PlayerProduct player)
    {
        BuffProduct buff = new BuffProduct();
        return buff;
    }

    public override IBuffProduct CreateNagtiveBuff(PlayerProduct player)
    {
        BuffProduct buff = new BuffProduct();
        return buff;
    }

    public override IBuffProduct CreatePostiveBuff(PlayerProduct player)
    {
        BuffProduct buff = new BuffProduct();
        return buff;
    }
}

