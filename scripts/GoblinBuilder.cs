using Godot;

// строитель характеристик гоблина
public partial class GoblinBuilder : EnemyBuilder
{
    // настраиваемые характеристики гоблина
    [Export]
    private float hp = 30;
    [Export]
    private float damage = 10;
    [Export]
    private float speed = 100;
    // загружаем текстуру гоблина из ресурсов проекта
    [Export]
    private Texture2D texture = GD.Load<Texture2D>("res://resourses/Goblin_sprite.png");

    // устанавливает гоблину запас здоровья
    public override void buildHp() 
    {
        _product.hp = hp;
    }
    // устанавливает урон гоблина
    public override void buildDamage(){
        _product.damage = damage;
    }
    // устанавливает скорость гоблина
    public override void buildSpeed() {
        _product.speed = speed;
    }
    // добавляет текстуру гоблина в набор характеристик
    public override void buildSprite()
    {
        _product.texture = texture;
    }

}
