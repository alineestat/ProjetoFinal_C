namespace JewelCollector;
/// <summary>
/// A classe abstrata Jewel especifica as propriedades que todas as joias devem ter: coordenadas (x, y) e um valor (pontuação). Ela herda de Entity.
/// </summary>
public abstract class Jewel : Entity
{
    /// <summary>
    /// Especifica a coordenada X da joia
    /// </summary>
    /// <value></value>
    public int X { get; set; }
    /// <summary>
    /// Especifica a coordenada Y da joia
    /// </summary>
    /// <value></value>
    public int Y { get; set; }
    /// <summary>
    /// Pontuação da joia
    /// </summary>
    /// <value></value>
    public int Value { get; set; }
}

/// <summary>
/// A classe JewelRed armazena informações das joias vermelhas do mapa, como a sua coordenada e seu valor (100 pontos). Ela herda da classe abstrata Jewel.
/// </summary>
public class JewelRed : Jewel
{
    /// <summary>
    /// O construtor recebe as coordenadas da joia no mapa
    /// </summary>
    /// <param name="x">Coordenada X</param>
    /// <param name="y">Coordenada Y</param>
    public JewelRed(int x, int y)
    {
        X = x;
        Y = y;
        Value = 100;
    }

/// <summary>
/// Este método sobrescreve a função ToString(), retornando uma string (JR) para ser impressa no mapa.
/// </summary>
public override string ToString()
    {
        return "JR";
    }
}

/// <summary>
/// A classe JewelGreen armazena informações das joias verdes do mapa, como a sua coordenada e seu valor (50 pontos). Ela herda da classe abstrata Jewel.
/// </summary>
public class JewelGreen : Jewel
{
    /// <summary>
    /// O construtor recebe as coordenadas da joia no mapa
    /// </summary>
    /// <param name="x">Coordenada X</param>
    /// <param name="y">Coordenada Y</param>
    public JewelGreen(int x, int y)
    {
        X = x;
        Y = y;
        Value = 50;
    }

/// <summary>
/// Este método sobrescreve a função ToString(), retornando uma string (JG) para ser impressa no mapa.
/// </summary>
/// <returns></returns>
public override string ToString()
    {
        return "JG";
    }
}

/// <summary>
/// A classe JewelBlue armazena informações das joias azuis do mapa, como a sua coordenada e seu valor (10 pontos). Ela herda da classe abstrata Jewel.
/// </summary>
public class JewelBlue : Jewel
{
    /// <summary>
    /// O construtor recebe as coordenadas da joia no mapa
    /// </summary>
    /// <param name="x">Coordenada X</param>
    /// <param name="y">Coordenada Y</param>
    public JewelBlue(int x, int y)
    {
        X = x;
        Y = y;
        Value = 10;
    }

/// <summary>
/// Este método sobrescreve a função ToString(), retornando uma string (JB) para ser impressa no mapa.
/// </summary>
/// <returns></returns>
public override string ToString()
    {
        return "JB";
    }
}

