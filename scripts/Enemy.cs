using Godot;

public partial class Enemy : CharacterBody2D
{
    [Export]
    public EnemyData Data { get; set; }
}
