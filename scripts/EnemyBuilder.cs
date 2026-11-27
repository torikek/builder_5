using Godot;

// базовый строитель определяет шаги настройки характеристик врага
public abstract partial class EnemyBuilder : Node
{
    // сохраняем создаваемый набор характеристик между шагами сборки
    protected EnemyData _product = new EnemyData();
    // задаёт запас здоровья в конкретном строителе
    public abstract void buildHp();
    // задаёт урон в конкретном строителе
    public abstract void buildDamage();
    // задаёт скорость в конкретном строителе
    public abstract void buildSpeed();
    // задаёт текстуру в конкретном строителе
    public abstract void buildSprite();
    // возвращает готовые характеристики и подготавливает новый продукт
    public EnemyData getResult()
    {
        EnemyData result = _product;
        _product = new EnemyData();
        return result;
    }
}
