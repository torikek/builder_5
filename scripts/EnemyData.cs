using Godot;

public partial class EnemyData : Resource
{
    [Export]
    public float hp { get; set; }
    [Export]
    public float damage;
    [Export]
    public float speed;
    [Export]
    public Texture2D texture;

    public void applyTo()
    {
    }
}
