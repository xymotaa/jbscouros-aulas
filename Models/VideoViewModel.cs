namespace jbscouros_aulas.Models;

/// <summary>
/// Representa os dados de um vídeo corporativo do portal JBS Aulas.
/// </summary>
public class VideoViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PublishDate { get; set; } = string.Empty;
}