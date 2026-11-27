using Godot;

// строитель характеристик дракона
public partial class DragonBuilder : EnemyBuilder
{
    // настраиваемые характеристики дракона
    [Export]
    private float hp = 40;
    [Export]
    private float damage = 20;
    [Export]
    private float speed = 200;
    // загружаем текстуру дракона из ресурсов проекта
    [Export]
    private Texture2D texture = GD.Load<Texture2D>("res://resourses/Dragon_spite.png");
    // устанавливает дракону запас здоровья
    public override void buildHp() 
    {
        _product.hp = hp;
    }
    // устанавливает урон дракона
    public override void buildDamage(){
        _product.damage = damage;
    }
    // устанавливает скорость дракона
    public override void buildSpeed() {
        _product.speed = speed;
    }
    // добавляет текстуру дракона в набор характеристик
    public override void buildSprite()
    {
        _product.texture = texture;
    }
}
