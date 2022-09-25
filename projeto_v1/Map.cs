namespace JewelCollector;

/// <summary>
/// A classe Map implementa o espaço virtual através do qual o robô se locomove. Ela armazena todas as informações dos elementos do mapa.
/// </summary>
public class Map
{
    /// <summary>
    /// A matrix é um array de duas dimensões, e armazena objetos do tipo Entity. Desse modo, como todos os elementos do mapa herdam de Entity, o mapa consegue acomodar Jewel, OpenSpace, Robot e Obstacle.
    /// </summary>
    public Entity[,] matrix = new Entity[10, 10];

    /// <summary>
    /// O mapa mantém uma contagem de quantas joias ainda estão espalhadas. Quando Jewels = 0, o jogo acaba.
    /// </summary>
    /// <value>Inteiro não negativo</value>
    public int Jewels { get; set; }

    /// <summary>
    /// O construtor de Map atribui espaços vazios (OpenSpace) a todos os índices de sua matriz quando Map é inicializado.
    /// </summary>
    public Map() {
        for ( int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                matrix[i, j] = new OpenSpace(); 
            }
        }
        this.Jewels = 0;
    }

    /// <summary>
    /// A função draw() imprime a matrix de Map no console.
    /// </summary>
    public void draw(){
        string line = "";
         for ( int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                line += matrix[i, j] + " "; 
            }
            line += "\n";
        }
        Console.WriteLine(line);
    }

    /// <summary>
    /// A função insertEntity insere um elemento do jogo (obstáculo ou jóia) na coordenada especificada
    /// </summary>
    /// <param name="i">Coordenada x</param>
    /// <param name="j">Coordenada y</param>
    /// <param name="e">Objeto do tipo Entity a ser inserido</param>
    public void insertEntity(int i, int j, Entity e){
        matrix[i, j] = e; 

        if (e.GetType() == typeof(JewelBlue) ||
            e.GetType() == typeof(JewelRed) ||
            e.GetType() == typeof(JewelGreen))
        {
            Jewels++;
        }
    }

    /// <summary>
    /// A função removeJewel retira uma joia do mapa, inserindo um espaço vazio em seu lugar e subtraindo 1 do contador de joias.
    /// </summary>
    /// <param name="x">Coordenada x</param>
    /// <param name="y">Coordenada y</param>
    public void removeJewel(int x, int y)
    {
        matrix[x, y] = new OpenSpace();
        Jewels--;
    }
    /// <summary>
    /// Esta função imprime uma mensagem de vitória para o jogador.
    /// </summary>
    public void youWin()
    {
        Console.WriteLine();
        Console.WriteLine("=-=-=-=- CONGRATULATIONS! YOU WIN! -=-=-=-=");
        Console.WriteLine();
    }
}
