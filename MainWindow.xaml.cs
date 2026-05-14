using System.Windows;

namespace laco_for;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void BotaoSorteio_OnClick(object sender, RoutedEventArgs e)
    {
        var quantidadetexto = tbQuantidade.Text;
        var quantidadedesorteios = Convert.ToInt32(quantidadetexto);
        if (quantidadedesorteios < 1) quantidadedesorteios = 1;

        var sorteador = new Random();
        for (var contador = 0; contador < quantidadedesorteios; contador++)
        {
            tbresultado.Text = sorteador.Next(0, 4000000).ToString();
            await Task.Delay(1000);
        }
    }
}