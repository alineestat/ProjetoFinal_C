namespace JewelCollector;

/// <summary>
/// A classe JewelCollector é responsável por implementar o método Main(), criar o mapa, inserir as joias, obstáculos, instanciar o robô e ler os comandos do teclado.
/// </summary>
public class JewelCollector
{
    /// <summary>
        /// A propriedade Round armazena a rodada atual
    /// </summary>
    /// <value>Inteiro não negativo</value>
    public int Round { get; set; }

    /// <summary>
        /// O construtor define que a propriedade Round se inicia com valor igual a 1.
    /// </summary>
    public JewelCollector()
    {
        Round = 1;
    }

    /// <summary>
        /// A função BuildMap insere os elementos do jogo no mapa. A partir da fase 2, os elementos são inseridos de maneira aleatória, seguindo a proporção aproximada de 80% de espaço vazio (OpenSpace) e 20% de obstáculos e joias.
    /// </summary>
    /// <param name="m">Especifica o objeto do tipo Map no qual serão inseridos os elementos</param>
    /// <param name="r">Especifica o robô que irá interagir com o mapa</param>
    public void BuildMap(Map m, Robot r)
    {
        m.insertEntity(0, 0, r);
        if (Round == 1)
        {
            m.insertEntity(5, 9, new Tree(5, 9));
            m.insertEntity(3, 9, new Tree(3, 9));
            m.insertEntity(8, 3, new Tree(8, 3));
            m.insertEntity(2, 5, new Tree(2, 5));
            m.insertEntity(1, 4, new Tree(1, 4));
            m.insertEntity(5, 1, new Water(5, 1));
            m.insertEntity(5, 2, new Water(5, 2));
            m.insertEntity(5, 3, new Water(5, 3));
            m.insertEntity(5, 4, new Water(5, 4));
            m.insertEntity(5, 5, new Water(5, 5));
            m.insertEntity(5, 6, new Water(5, 6));
            m.insertEntity(1, 9, new JewelRed(1, 9));
            m.insertEntity(8, 8, new JewelRed(8, 8));
            m.insertEntity(9, 1, new JewelGreen(9, 1));
            m.insertEntity(7, 6, new JewelGreen(7, 6));
            m.insertEntity(3, 4, new JewelBlue(3, 4));
            m.insertEntity(2, 1, new JewelBlue(2, 1));
        }
        
        else
        {
            for (int i = 0; i < m.Dimension; i++)
            {
                for (int j = 0; j < m.Dimension; j++)
                {
                    if (i != 0 && j != 0)
                    {
                        Random rnd = new Random();
                        int num = rnd.Next(1, 24);
                        if (num <= 6)
                        {
                            switch (num)
                            {
                                case 1: 
                                    m.insertEntity(i, j, new Water(i, j));
                                    break;
                                case 2:
                                    m.insertEntity(i, j, new Tree(i, j));
                                    break;
                                case 3:
                                    m.insertEntity(i, j, new JewelBlue(i, j));
                                    break;
                                case 4:
                                    m.insertEntity(i, j, new JewelRed(i, j));
                                    break;
                                case 5:
                                    m.insertEntity(i, j, new JewelGreen(i, j));
                                    break;
                                case 6:
                                    m.insertEntity(i, j, new Radioactive(i, j));
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
        /// O método Main é o ponto de início da execução. Os elementos do jogo são criados e um loop é iniciado, aguardando os comandos do jogador a partir do método Console.ReadKey().
    /// </summary>
    public static void Main()
    {
        Map m = new Map();
        Robot r = new Robot(0, 0);
        JewelCollector j = new JewelCollector();
        j.BuildMap(m, r);
        ConsoleKeyInfo keyInfo;

        do
        {
            m.draw();
            r.ShowTotalJewels();
            r.ShowTotalValue();
            r.ShowEnergy();
            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                r.GoNorth(m);
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                r.GoWest(m);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                r.GoSouth(m);
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                r.GoEast(m);
            }
            else if (keyInfo.Key == ConsoleKey.G)
            {
                r.CollectEnergy(m);
                r.CollectJewel(m);
            }
            if (m.Jewels == 0)
            {
                m.draw();
                j.Round++;
                m.Dimension++;
                r.X = 0;
                r.Y = 0;
                r.Bag = new List<Jewel>();
                m.newMap();
                j.BuildMap(m, r);
            }
            if (r.Energy <= 0)
            {
                m.youLose();
                break;
            }
            if (j.Round == 30)
            {
                m.youWin();
                break;
            }
        } while (keyInfo.Key != ConsoleKey.X);
    }
}
