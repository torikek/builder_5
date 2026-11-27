using Godot;

// базовый строитель определяет шаги настройки характеристик врага
public partial class EnemyBuilder : Node
{
    // сохраняем создаваемый набор характеристик между шагами сборки
    protected EnemyData _product = new EnemyData();
    // задаёт запас здоровья в конкретном строителе
    public virtual void buildHp() {}
    // задаёт урон в конкретном строителе
    public virtual void buildDamage(){}
    // задаёт скорость в конкретном строителе
    public virtual void buildSpeed() {}
    // задаёт текстуру в конкретном строителе
    public virtual void buildSprite() {}
    // возвращает текущий набор характеристик без создания копии
    public EnemyData getResult()
    {
        return _product;
    }
}

// строитель характеристик гоблина
public partial class GoblinBuilder : EnemyBuilder
{
    // загружаем текстуру гоблина из ресурсов проекта
    private Texture2D texture = GD.Load<Texture2D>("res://resourses/Goblin_sprite.png");

    // устанавливает гоблину запас здоровья
    public override void buildHp() 
    {
        _product.hp = 30;
    }
    // устанавливает урон гоблина
    public override void buildDamage(){
        _product.damage = 10;
    }
    // устанавливает скорость гоблина
    public override void buildSpeed() {
        _product.speed = 100;
    }
    // добавляет текстуру гоблина в набор характеристик
    public override void buildSprite()
    {
        _product.texture = texture;
    }

}
// строитель характеристик дракона
public partial class DragonBuilder : EnemyBuilder
{
    // загружаем текстуру дракона из ресурсов проекта
    private Texture2D texture = GD.Load<Texture2D>("res://resourses/Dragon_spite.png");
    // устанавливает дракону запас здоровья
    public override void buildHp() 
    {
        _product.hp = 40;
    }
    // устанавливает урон дракона
    public override void buildDamage(){
        _product.damage = 20;
    }
    // устанавливает скорость дракона
    public override void buildSpeed() {
        _product.speed = 200;
    }
    // добавляет текстуру дракона в набор характеристик
    public override void buildSprite()
    {
        _product.texture = texture;
    }
}
