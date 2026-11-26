using Godot;

public partial class EnemyBuilder : Node
{
    protected EnemyData _product = new EnemyData();
    public virtual void buildHp() {}
    public virtual void buidDamage(){}
    public virtual void buidSpeed() {}
    public virtual void buidSpite() {}
    public EnemyData getResult()
    {
        return _product;
    }
}

public partial class OrcBuilder : EnemyBuilder
{

    public override void buildHp() 
    {
        _product.hp = 30;
    }
    public override void buidDamage(){
        _product.damage = 10;
    }
    public override void buidSpeed() {
        _product.speed = 50;
    }
    public override void buidSpite() {}

}
public partial class DragonBuilder : EnemyBuilder
{

}
