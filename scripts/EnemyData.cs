using Godot;

// ресурс с характеристиками и текстурой врага
public partial class EnemyData : Resource
{
    // запас здоровья с возможностью настройки в инспекторе
    [Export]
    public float hp { get; set; }
    // урон врага
    [Export]
    public float damage;
    // скорость движения в пикселях в секунду
    [Export]
    public float speed;
    // текстура для отображения врага
    [Export]
    public Texture2D texture;
    // устанавливает текстуру спрайта из этого ресурса
    public void applyTo(Enemy enemy)
    {
        enemy.GetNode<Sprite2D>("Sprite2D").Texture = texture;
    }
}
