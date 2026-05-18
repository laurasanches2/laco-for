using System.Windows;

namespace laco_for;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public decimal saldoinicial = 1234.00m;
    private string[] emoticons = { "🐯", "🍊", "💎", "💰", "🍒", "🔔" };
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void BotaoSorteio_OnClick(object sender, RoutedEventArgs e)
    {

        if (!int.TryParse(tbQuantidade.Text, out var quantidadedesorteios))
        {
            MessageBox.Show("coloque apenas valores numericos!");
            return;
        }
        
        btsorteio.IsEnabled = false;

        if (quantidadedesorteios < 1)
        {
            quantidadedesorteios = 1;
        }
        
        var sorteador = new Random();
        
        for (var contador = 0; contador < quantidadedesorteios; contador++)
        {
            if (saldoinicial >= 10M)
            {
               
                saldoinicial -= 10M;
                tbSaldo.Text =  $"R$ {saldoinicial}";

                var numeroSorteado = sorteador.Next(40000001);
                if (numeroSorteado == 3)
                {
                    tbSlot1.Text = emoticons[0];
                    tbSlot2.Text = emoticons[0];
                    tbSlot3.Text = emoticons[0];
                    saldoinicial += 20M;
                    tbSaldo.Text = $"R$ {saldoinicial}";
                }
                else
                {
                    int Slot1, Slot2, Slot3;
                    do
                    {
                        Slot1 = sorteador.Next(emoticons.Length);
                        Slot2 = sorteador.Next(emoticons.Length); 
                        Slot3 = sorteador.Next(emoticons.Length);
                        tbSlot1.Text = emoticons[Slot1];
                        tbSlot2.Text = emoticons[Slot2];
                        tbSlot3.Text = emoticons[Slot3];
                    } while (Slot1 == Slot2 && Slot2 == Slot3);
                }
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