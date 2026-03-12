namespace jbscouros_aulas.Models;

/// <summary>
/// ViewModel da página Watch.
/// Agrega o vídeo atual e a lista de sugestões exibida ao lado.
/// </summary>
public class WatchViewModel
{
    /// <summary>Vídeo sendo exibido no player.</summary>
    public VideoViewModel Video { get; set; } = new();

    /// <summary>Vídeos sugeridos (diferentes do atual).</summary>
    public IReadOnlyList<VideoViewModel> Suggestions { get; set; } = [];
}
