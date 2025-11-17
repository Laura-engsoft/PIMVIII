using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CreatorMauiApp.ViewModels;

public class UploadViewModel : BaseViewModel
{
    private string _title = string.Empty;
    private string _selectedType = string.Empty;
    private string _fileName = "arquivo_demo.mp4";
    private string _confirmationMessage = string.Empty;

    public ObservableCollection<string> AvailableTypes { get; } = new([
        "Vídeo",
        "Áudio",
        "Live",
        "Short"
    ]);

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string SelectedType
    {
        get => _selectedType;
        set => SetProperty(ref _selectedType, value);
    }

    public string FileName
    {
        get => _fileName;
        set => SetProperty(ref _fileName, value);
    }

    public string ConfirmationMessage
    {
        get => _confirmationMessage;
        set => SetProperty(ref _confirmationMessage, value);
    }

    public ICommand SubmitCommand { get; }

    public UploadViewModel()
    {
        SelectedType = AvailableTypes.First();
        SubmitCommand = new Command(Submit);
    }

    private void Submit()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            ConfirmationMessage = "Informe um título para enviar o conteúdo.";
            return;
        }

        ConfirmationMessage = $"Conteúdo \"{Title}\" ({SelectedType}) enviado com sucesso!";
        Title = string.Empty;
        FileName = "arquivo_demo.mp4";
    }
}
