using Godot;

public partial class EnemyBuilder : Node
{
    protected EnemyData _product = new EnemyData();
    public virtual void buildHp() {}
    public virtual void buildDamage(){}
    public virtual void buildSpeed() {}
    public virtual void buildSprite() {}
    public EnemyData getResult()
    {
        return _product;
    }
}

public partial class GoblinBuilder : EnemyBuilder
{
    private Texture2D texture = GD.Load<Texture2D>("res://resourses/Goblin_sprite.png");

    public override void buildHp() 
    {
        _product.hp = 30;
    }
    public override void buildDamage(){
        _product.damage = 10;
    }
    public override void buildSpeed() {
        _product.speed = 100;
    }
    public override void buildSprite()
    {
        _product.texture = texture;
    }

}
public partial class DragonBuilder : EnemyBuilder
{
    private Texture2D texture = GD.Load<Texture2D>("res://resourses/Dragon_spite.png");
    public override void buildHp() 
    {
        _product.hp = 40;
    }
    public override void buildDamage(){
        _product.damage = 20;
    }
    public override void buildSpeed() {
        _product.speed = 200;
    }
    public override void buildSprite()
    {
        _product.texture = texture;
    }
}
