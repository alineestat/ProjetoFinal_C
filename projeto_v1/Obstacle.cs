namespace JewelCollector;

/// <summary>
/// A classe abstrata Obstacle especifica as propriedades que todos os obstáculos devem ter: coordenadas (x, y) e um tipo (Tree ou Water).
/// </summary>
public abstract class Obstacle : Entity
{
    /// <summary>
    /// Especifica a coordenada x do obstáculo no mapa.
    /// </summary>
    /// <value>Valor inteiro</value>
    public int X { get; set; }

    /// <summary>
    /// Especifica a coordenada x do obstáculo no mapa.
    /// </summary>
    /// <value>Valor inteiro</value>
    public int Y { get; set; }

    /// <summary>
    /// Especifica o tipo de obstáculo.
    /// </summary>
    /// <value>Tree ou Water</value>
    public ObstacleType Type { get; set; }
}

/// <summary>
/// Water é um tipo de obstáculo intransponível do mapa. 
/// </summary>
public class Water : Obstacle
{
    public Water(int x, int y)
    {
        X = x;
        Y = y;
        Type = ObstacleType.Water;
    }
    public override string ToString()
    {
        return "##";
    }
}

/// <summary>
/// Tree é um tipo de obstáculo intransponível do mapa. 
/// </summary>
public class Tree : Obstacle
{   
    public Tree(int x, int y)
    {
        X = x;
        Y = y;
        Type = ObstacleType.Tree;
    }

 public override string ToString()
    {
        return "$$";
    }
}

/// <summary>
/// ObstacleType enumera os tipos de obstáculos do mapa
/// </summary>
public enum ObstacleType
{
    Water, Tree
}