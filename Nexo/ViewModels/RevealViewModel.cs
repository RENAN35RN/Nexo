using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Nexo.ViewModels;

// ViewModel de UMA carta de revelação (um jogador por vez).
// A tela é sempre igual pra todo mundo: quem chama esta classe
// é quem decide, na lógica do jogo, se PlayerWord é a palavra
// principal ou a palavra do impostor. A UI não sabe e não precisa saber.
public partial class RevealViewModel : ObservableObject
{
    [ObservableProperty]
    private string playerName = string.Empty;

    [ObservableProperty]
    private string playerWord = string.Empty;

    [ObservableProperty]
    private bool isRevealed;

    // Texto do botão muda conforme o estado
    public string ButtonText => IsRevealed ? "entendi, passar adiante" : "revelar";

    // Disparado quando o usuário confirma "entendi, passar adiante"
    public event Action? NextRequested;

    [RelayCommand]
    private void ToggleReveal()
    {
        if (!IsRevealed)
        {
            IsRevealed = true;
            OnPropertyChanged(nameof(ButtonText));
        }
        else
        {
            // avança pro próximo jogador; quem orquestra a fila
            // (o GameViewModel) escuta este evento
            NextRequested?.Invoke();
        }
    }

    // Chamado pelo GameViewModel ao preparar a carta do próximo jogador
    public void ResetFor(string name, string word)
    {
        PlayerName = name;
        PlayerWord = word;
        IsRevealed = false;
        OnPropertyChanged(nameof(ButtonText));
    }
}
