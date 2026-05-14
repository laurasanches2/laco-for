using System.Windows;

namespace laco_for;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public decimal saldoinicial = 1234.00m;
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void BotaoSorteio_OnClick(object sender, RoutedEventArgs e)
    {
        btsorteio.IsEnabled = false;
        
        var quantidadetexto = tbQuantidade.Text;
        var quantidadedesorteios = Convert.ToInt32(quantidadetexto);
        if (quantidadedesorteios < 1) quantidadedesorteios = 1;

        var sorteador = new Random();
        
        for (var contador = 0; contador < quantidadedesorteios; contador++)
        {
            if (saldoinicial >= 10M)
            {
                tbresultado.Text = sorteador.Next(0, 4000000).ToString();
                saldoinicial -= 10M;
                tbSaldo.Text =  $"R$ {saldoinicial}";
                await Task.Delay(1000);
            }
            else
            {
                MessageBox.Show("voce nao tem saldo suficiente para realizar o sorteio! ");
                break;
            }
        }
        
    }

    
    }