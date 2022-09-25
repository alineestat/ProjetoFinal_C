namespace JewelCollector;

/// <summary>
    /// Robot é o agente controlado pelo usuário que navega pelo mapa do jogo. O objetivo é fazer com que Robot colete todas as joias que estão espalhadas, desviando dos obstáculos. Robot possui coordenadas (x, y) e uma sacola (Bag) que contém as joias coletadas.
/// </summary>
public class Robot : Entity
{
    /// <summary>
        /// Especifica a coordenada x de Robot.
    /// </summary>
    public int X { get; set; }

    /// <summary>
        /// Especifica a coordenada y de Robot.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
        /// Armazena as joias coletadas pelo Robot.
    /// </summary>
    public List<Jewel> Bag { get; set; } = new List<Jewel>();

    /// <summary>
        /// Especifica a energia restante de Robot.
    /// </summary>
    public int Energy { get; set; }

    public Robot(int x, int y)
    {
        X = x;
        Y = y;
        Energy = 5;
    }

    /// <summary>
        /// A função GoNorth move Robot para cima na matrix de Map. Essa operação só ocorre se houver um espaço vazio ou um elemento radioativo acima de Robot.
    /// </summary>
    public void GoNorth(Map m)
    {
        try
        {
            if (m.matrix[X - 1, Y].GetType() == typeof(OpenSpace) ||
                m.matrix[X - 1, Y].GetType() == typeof(Radioactive))
            {
                CheckForRadioactive(m, 'n');
                m.matrix[X - 1, Y] = m.matrix[X, Y];
                m.matrix[X, Y] = new OpenSpace();
                this.X--;
                this.Energy--;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid path!");
        }
    }

    /// <summary>
        /// A função GoSouth move Robot para baixo na matrix de Map. Essa operação só ocorre se houver um espaço vazio ou um elemento radioativo abaixo de Robot.
    /// </summary>
    public void GoSouth(Map m)
    {
        try
        {
            if (m.matrix[X + 1, Y].GetType() == typeof(OpenSpace) ||
                m.matrix[X + 1, Y].GetType() == typeof(Radioactive))
            {
                CheckForRadioactive(m, 's');
                m.matrix[X + 1, Y] = m.matrix[X, Y];
                m.matrix[X, Y] = new OpenSpace();
                this.X++;
                this.Energy--;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid path!");
        }
    }

    /// <summary>
        /// A função GoEast move Robot para a direita na matrix de Map. Essa operação só ocorre se houver um espaço vazio ou elemento radioativo à direita de Robot.
    /// </summary>
    public void GoEast(Map m)
    {
        try
        {
            if (m.matrix[X, Y + 1].GetType() == typeof(OpenSpace) ||
                m.matrix[X, Y + 1].GetType() == typeof(Radioactive))
            {
                CheckForRadioactive(m, 'e');
                m.matrix[X, Y + 1] = m.matrix[X, Y];
                m.matrix[X, Y] = new OpenSpace();
                this.Y++;
                this.Energy--;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid path!");
        }
    }

    /// <summary>
        /// A função GoWest move Robot para a esquerda na matrix de Map. Essa operação só ocorre se houver um espaço vazio ou elemento radioativo à esquerda de Robot.
    /// </summary>
    public void GoWest(Map m)
    {
        try
        {
            if (m.matrix[X, Y - 1].GetType() == typeof(OpenSpace) ||
                m.matrix[X, Y - 1].GetType() == typeof(Radioactive))
            {
                CheckForRadioactive(m, 'w');
                m.matrix[X, Y - 1] = m.matrix[X, Y];
                m.matrix[X, Y] = new OpenSpace();
                this.Y--;
                this.Energy--;
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
    public void CollectJewel(Map m)
    {
        this.CollectOnTop(m);
        this.CollectOnBottom(m);
        this.CollectOnLeft(m);
        this.CollectOnRight(m);
    }

    /// <summary>
        /// A função CollectEnergy utiliza a energia de Trees e JewelBlues nas adjacencias. 
    /// </summary>
    /// <param name="m">Mapa com o qual o robô está interagindo</param>
    public void CollectEnergy(Map m)
    {
        UseEnergy(X, Y - 1, m);
        UseEnergy(X, Y + 1, m);
        UseEnergy(X - 1, Y, m);
        UseEnergy(X + 1, Y, m);
    }

    /// <summary>
        /// A função CollectOnTop verifica se o elemento a esquerda de Robot é uma joia. Caso seja, o robô coleta a joia, colocando-a em sua sacola.
    /// </summary>
    /// <param name="m">Mapa com o qual o robô está interagindo</param>
    private void CollectOnLeft(Map m)
    {
        try
        {
            if (m.matrix[X, Y - 1].GetType() == typeof(JewelBlue) ||
                m.matrix[X, Y - 1].GetType() == typeof(JewelRed) ||
                m.matrix[X, Y - 1].GetType() == typeof(JewelGreen))
            {
                this.Bag.Add((Jewel)m.matrix[X, Y - 1]);
                m.removeJewel(X, Y - 1);
            }
        }
        catch { }
    }

    /// <summary>
        /// A função CollectOnBottom verifica se o elemento a direita de Robot é uma joia. Caso seja, o robô coleta a joia, colocando-a em sua sacola.
    /// </summary>
    /// <param name="m">Mapa com o qual o robô está interagindo</param>
    private void CollectOnRight(Map m)
    {
        try
        {
            if (m.matrix[X, Y + 1].GetType() == typeof(JewelBlue) ||
                m.matrix[X, Y + 1].GetType() == typeof(JewelRed) ||
                m.matrix[X, Y + 1].GetType() == typeof(JewelGreen))
            {
                this.Bag.Add((Jewel)m.matrix[X, Y + 1]);
                m.removeJewel(X, Y + 1);
            }
        }
        catch { }
    }

    /// <summary>
        /// A função CollectOnLeft verifica se o elemento acima de Robot é uma joia. Caso seja, o robô coleta a joia, colocando-a em sua sacola.
    /// </summary>
    /// <param name="m">Mapa com o qual o robô está interagindo</param>
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
        catch { }
    }

    /// <summary>
        /// A função CollectOnRight verifica se o elemento abaixo de Robot é uma joia. Caso seja, o robô coleta a joia, colocando-a em sua sacola.
    /// </summary>
    /// <param name="m">Mapa com o qual o robô está interagindo</param>
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
        catch { }
    }

    /// <summary>
        /// A função UseEnergy coleta a energia de um objeto do tipo JewelBlue ou do tipo Tree, na coordenada especificada na entrada.
    /// </summary>
    /// <param name="x">Especifica a coordenada x da matrix de Map</param>
    /// <param name="y">Especifica a coordenada y da matrix de Map</param>
    /// <param name="m">Especifica o objeto do tipo Map com o qual o robô está interagindo</param>
    public void UseEnergy(int x, int y, Map m)
    {
        try
        {
            if (m.matrix[x, y].GetType() == typeof(JewelBlue))
            {
                Energy += 5;
            }
            else if (m.matrix[x, y].GetType() == typeof(Tree))
            {
                Tree t = (Tree)m.matrix[x, y];
                if (t.Energy > 0)
                {
                    Energy += 3;
                    t.Energy--;
                    m.matrix[x, y] = t;
                }
            }
        }
        catch (Exception) { }
    }

    /// <summary>
        /// A função CheckForRadioactive checa se há um elemento radioativo 1) no local onde o robô está pisando, ou 2) nas adjacências ao local em que o robô está pisando.
    /// </summary>
    /// <param name="m">Especifica o objeto do tipo Map com o qual o robô está interagindo</param>
    /// <param name="movement">Especifica para qual direção o robô está se movendo ('e' para east, 'n' para north, 'w' para west e 's' para south).</param>
    public void CheckForRadioactive(Map m, char movement)
    {
        if (movement.Equals('e'))
        {
            try
            {
                if (m.matrix[X, Y + 1].GetType() == typeof(Radioactive)) Energy -= 30;
            }
            catch { }
            try
            {
                if (m.matrix[X - 1, Y + 1].GetType() == typeof(Radioactive)) Energy -= 10;
            }
            catch { }
            try
            {
                if (m.matrix[X, Y + 2].GetType() == typeof(Radioactive)) Energy -= 10;
            }
            catch { }
            try
            {
                if (m.matrix[X + 1, Y + 1].GetType() == typeof(Radioactive)) Energy -= 10;
            }
            catch { }
        }
        else if (movement.Equals('n'))
        {
            try
            {
            if (m.matrix[X - 1, Y].GetType() == typeof(Radioactive)) Energy -= 30;
            } catch { }
            try
            {
            if (m.matrix[X - 1, Y - 1].GetType() == typeof(Radioactive)) Energy -= 10;
            } catch { }
            try
            {
                if (m.matrix[X - 1, Y + 1].GetType() == typeof(Radioactive)) Energy -= 10;
            } catch { }
            try
            {
            if (m.matrix[X - 2, Y].GetType() == typeof(Radioactive)) Energy -= 10;
            } catch { }
        }
        else if (movement.Equals('w'))
        {
            try
            {
                if (m.matrix[X, Y - 1].GetType() == typeof(Radioactive)) Energy -= 30;
            } catch { }
            try
            {
            if (m.matrix[X - 1, Y - 1].GetType() == typeof(Radioactive)) Energy -= 10;
            } catch { }
            try
            {
            if (m.matrix[X, Y - 2].GetType() == typeof(Radioactive)) Energy -= 10;
            } catch { }
            try
            {
                if (m.matrix[X + 1, Y - 1].GetType() == typeof(Radioactive)) Energy -= 10;
            } catch { }
        }
        else if (movement.Equals('s'))
        {
            try
            {
                if (m.matrix[X + 1, Y].GetType() == typeof(Radioactive)) Energy -= 30;
            } catch { }
            try
            {
                if (m.matrix[X + 1, Y + 1].GetType() == typeof(Radioactive)) Energy -= 10;
            } catch {}
            try
            {
                if (m.matrix[X + 1, Y - 1].GetType() == typeof(Radioactive)) Energy -= 10;
            }
            catch { }
            try
            {
                if (m.matrix[X + 2, Y].GetType() == typeof(Radioactive)) Energy -= 10;
            }
            catch { }
        }
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
        this.Bag.ForEach(x => total += x.Value);
        Console.WriteLine("Bag total value: " + total);
    }

    /// <summary>
        /// A função ShowTotalValue imprime no console o valor total das joias que foram coletadas pelo robô.
    /// </summary>
    public void ShowEnergy()
    {
        Console.WriteLine("Robot's total Energy: " + Energy);
        Console.WriteLine();
    }

    public override string ToString()
    {
        return "ME";
    }
}
