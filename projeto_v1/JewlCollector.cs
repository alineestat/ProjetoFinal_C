namespace JewelCollector;

/// <summary>
/// A classe JewelCollector é responsável por implementar o método Main(), criar o mapa, inserir as joias, obstáculos, instanciar o robô e ler os comandos do teclado.
/// </summary>
public class JewelCollector
{
    /// <summary>
    /// O construtor de JewelCollector recebe um mapa e um robô como parâmetros, preenchendo o mapa com os elementos Tree, Water, JewelRed, JewelGreen e JewelBlue de acordo com as coordenadas especificadas no projeto.
    /// </summary>
    /// <param name="m">Mapa</param>
    /// <param name="r">Robô</param>
    public JewelCollector(Map m, Robot r)
    {
        m.insertEntity(0, 0, r);
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

    /// <summary>
    /// O método Main é o ponto de início da execução. Os elementos do jogo são criados e um loop é iniciado, aguardando os comandos do jogador a partir do método Console.ReadLine().
    /// </summary>
    public static void Main()
    {
        Map m = new Map();
        Robot r = new Robot(0, 0);
        JewelCollector j = new JewelCollector(m, r);

        bool running = true;

        do
        {
            m.draw();
            r.ShowTotalJewels();
            r.ShowTotalValue();
            Console.Write("Enter the command: ");
            string command = Console.ReadLine();

            if (command.Equals("quit"))
            {
                running = false;
            } 
            else if (command.Equals("w"))
            {
                r.GoNorth(m);

            } 
            else if (command.Equals("a"))
            {
                r.GoWest(m);
            }
            else if (command.Equals("s"))
            {
                r.GoSouth(m);

            }
            else if (command.Equals("d"))
            {
                r.GoEast(m);

            }
            else if (command.Equals("g"))
            {
                r.CollectJewel(m);
            }
            if (m.Jewels == 0)
            {
                m.draw();
                m.youWin();
                running = false;
            }

        } while (running);
    }
}
