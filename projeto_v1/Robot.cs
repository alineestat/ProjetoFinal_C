namespace JewelCollector;

/// <summary>
/// Robot é o agente controlado pelo usuário que navega pelo mapa do jogo. O objetivo é fazer com que Robot colete todas as joias que estão espalhadas, desviando dos obstáculos. Robot possui coordenadas (x, y) e uma sacola (Bag) que contém as joias coletadas.
/// </summary>
public class Robot : Entity
{
    /// <summary>
    /// Especifica a coordenada x de Robot.
    /// </summary>
    /// <value>Valor inteiro</value>
    public int X { get; set; }
    /// <summary>
    /// Especifica a coordenada y de Robot.
    /// </summary>
    /// <value>Valor inteiro</value>
    public int Y { get; set; }
    /// <summary>
    /// Armazena as joias coletadas pelo Robot.
    /// </summary>
    /// <typeparam name="Jewel">Tipo Jewel</typeparam>
    /// <returns>Retorna uma List<Jewel></returns>
    public List<Jewel> Bag { get; set; } = new List<Jewel>();

    public Robot(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// A função GoNorth move Robot para cima na matrix de Map. Essa operação só ocorre se houver um espaço vazio acima de Robot.
    /// </summary>
    /// <param name="m">Mapa</param>
    public void GoNorth(Map m)
    {
        try
        {
            if (m.matrix[X - 1, Y].GetType() == typeof(OpenSpace))
            {
                m.matrix[X - 1, Y] = m.matrix[X, Y];
                m.matrix[X, Y] = new OpenSpace();
                X--;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid path!");
        }

    }

    /// <summary>
    /// A função GoSouth move Robot para baixo na matrix de Map. Essa operação só ocorre se houver um espaço vazio abaixo de Robot.
    /// </summary>
    /// <param name="m">Mapa</param>
    public void GoSouth(Map m)
    {
        try
        {
            if (m.matrix[X + 1, Y].GetType() == typeof(OpenSpace))
            {
                m.matrix[X + 1, Y] = m.matrix[X, Y];
                m.matrix[X, Y] = new OpenSpace();
                this.X++;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid path!");
        }
    }

    /// <summary>
    /// A função GoEast move Robot para a direita na matrix de Map. Essa operação só ocorre se houver um espaço vazio à direita de Robot.
    /// </summary>
    /// <param name="m">Mapa</param>
    public void GoEast(Map m)
    {
        try
        {
            if (m.matrix[X, Y + 1].GetType() == typeof(OpenSpace))
            {
                m.matrix[X, Y + 1] = m.matrix[X, Y];
                m.matrix[X, Y] = new OpenSpace();
                this.Y++;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid path!");
        }
    }
    /// <summary>
    /// A função GoWest move Robot para a esquerda na matrix de Map. Essa operação só ocorre se houver um espaço vazio à esquerda de Robot.
    /// </summary>
    /// <param name="m">Mapa</param>
    public void GoWest(Map m)
    {
        try
        {
            if (m.matrix[X, Y - 1].GetType() == typeof(OpenSpace))
            {
                m.matrix[X, Y - 1] = m.matrix[X, Y];
                m.matrix[X, Y] = new OpenSpace();
                this.Y--;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid path!");
        }
    }

    /// <summary>
    /// A função CollectJewel coleta as joias adjacentes a Robot.
    /// </summary>
    /// <param name="m">Mapa</param>
    public void CollectJewel(Map m)
    {
        this.CollectOnTop(m);
        this.CollectOnBottom(m);
        this.CollectOnLeft(m);
        this.CollectOnRight(m);
    }
    /// <summary>
    /// A função CollectOnTop verifica se o elemento a esquerda de Robot é uma joia. Caso seja, o robô coleta a joia, colocando-a em sua sacola.
    /// </summary>
    /// <param name="m">Mapa</param>
    private void CollectOnLeft(Map m)
    {
        try
        {
            if (m.matrix[X, Y - 1].GetType() != typeof(JewelBlue) ||
                m.matrix[X, Y - 1].GetType() != typeof(JewelRed) ||
                m.matrix[X, Y - 1].GetType() != typeof(JewelGreen))
            {
                Bag.Add((Jewel)m.matrix[X, Y - 1]);
                m.removeJewel(X, Y - 1);
            }
        }
        catch (Exception) { }
    }

    /// <summary>
    /// A função CollectOnBottom verifica se o elemento a direita de Robot é uma joia. Caso seja, o robô coleta a joia, colocando-a em sua sacola.
    /// </summary>
    /// <param name="m">Mapa</param>
    private void CollectOnRight(Map m)
    {
        try
        {
            if (m.matrix[X, Y + 1].GetType() != typeof(JewelBlue) ||
                m.matrix[X, Y + 1].GetType() != typeof(JewelRed) ||
                m.matrix[X, Y + 1].GetType() != typeof(JewelGreen))
            {
                this.Bag.Add((Jewel)m.matrix[X, Y + 1]);
                m.removeJewel(X, Y + 1);
            }
        }
        catch (Exception) { }
    }

    /// <summary>
    /// A função CollectOnLeft verifica se o elemento acima de Robot é uma joia. Caso seja, o robô coleta a joia, colocando-a em sua sacola.
    /// </summary>
    /// <param name="m">Mapa</param>
    private void CollectOnTop(Map m)
    {
        try
        {

            if (m.matrix[X - 1, Y].GetType() == typeof(JewelBlue) ||
            m.matrix[X - 1, Y].GetType() == typeof(JewelRed) ||
            m.matrix[X - 1, Y].GetType() == typeof(JewelGreen))
            {
                this.Bag.Add((Jewel)m.matrix[X - 1, Y]);
                m.removeJewel(X - 1, Y);
            }
        }
        catch (Exception) { }
    }

    /// <summary>
    /// A função CollectOnRight verifica se o elemento abaixo de Robot é uma joia. Caso seja, o robô coleta a joia, colocando-a em sua sacola.
    /// </summary>
    /// <param name="m">Mapa</param>
    private void CollectOnBottom(Map m)
    {
        try
        {

            if (m.matrix[X + 1, Y].GetType() != typeof(JewelBlue) ||
                m.matrix[X + 1, Y].GetType() != typeof(JewelRed) ||
                m.matrix[X + 1, Y].GetType() != typeof(JewelGreen))
            {
                this.Bag.Add((Jewel)m.matrix[X + 1, Y]);
                m.removeJewel(X + 1, Y);
            }
        }
        catch (Exception) { }
    }

    /// <summary>
    /// A função ShowTotalJewels imprime no console o total de joias coletadas pelo robô.
    /// </summary>
    public void ShowTotalJewels()
    {
        Console.Write("Bag total items: " + this.Bag.Count + " | ");
    }

    /// <summary>
    /// A função ShowTotalValue imprime no console o valor total das joias que foram coletadas pelo robô.
    /// </summary>
    public void ShowTotalValue()
    {
        int total = 0;
        for (int i = 0; i < Bag.Count; i++)
        {
            total += Bag[i].Value;
        }
        Console.WriteLine("Bag total value: " + total);
    }

    public override string ToString()
    {
        return "ME";
    }
}
