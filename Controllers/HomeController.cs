using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using jbscouros_aulas.Models;

namespace jbscouros_aulas.Controllers;

/// <summary>
/// Controller principal da aplicação JBS Aulas.
/// Gerencia a listagem e visualização dos vídeos corporativos.
/// </summary>
public class HomeController : Controller
{
    /// <summary>
    /// Catálogo de vídeos em memória.
    /// Em produção, substituir por um repositório com banco de dados ou API.
    /// </summary>
    private static readonly IReadOnlyList<VideoViewModel> _catalog =
    [
        new()
        {
            Id = 1,
            Title = "Treinamento de Segurança Operacional - Planta Lins",
            Duration = "45:20",
            ThumbnailUrl = "https://images.unsplash.com/photo-1581092160562-40aa08e78837?auto=format&fit=crop&w=1200",
            Category = "Treinamentos",
            Description = "Instruções completas sobre o uso de EPIs e operação de maquinário pesado. Este treinamento cobre todos os protocolos de segurança exigidos pela norma NR-12 para colaboradores da Planta Lins.",
            PublishDate = "Jan 2024"
        },
        new()
        {
            Id = 2,
            Title = "Workshop de Sustentabilidade e ESG 2024",
            Duration = "1:12:05",
            ThumbnailUrl = "https://images.unsplash.com/photo-1542601906990-b4d3fb773b09?auto=format&fit=crop&w=1200",
            Category = "Eventos",
            Description = "Workshop completo sobre as metas ESG da JBS para 2024, com apresentação dos resultados ambientais, sociais e de governança do último trimestre.",
            PublishDate = "Mar 2024"
        },
        new()
        {
            Id = 3,
            Title = "Mensagem do CEO - Resultados Globais Q3",
            Duration = "58:00",
            ThumbnailUrl = "https://images.unsplash.com/photo-1556761175-b413da4baf72?auto=format&fit=crop&w=1200",
            Category = "Reuniões",
            Description = "Mensagem direta do CEO para todos os colaboradores com os destaques dos resultados globais do terceiro trimestre e as perspectivas para o próximo período.",
            PublishDate = "Out 2024"
        },
        new()
        {
            Id = 4,
            Title = "Boas Práticas de Fabricação (BPF)",
            Duration = "12:15",
            ThumbnailUrl = "https://images.unsplash.com/photo-1566933267003-31119463286d?auto=format&fit=crop&w=1200",
            Category = "Compliance",
            Description = "Guia prático sobre as Boas Práticas de Fabricação obrigatórias para todas as linhas de produção. Conteúdo atualizado conforme as normas vigentes de segurança alimentar.",
            PublishDate = "Fev 2024"
        },
        new()
        {
            Id = 5,
            Title = "Manual do Novo Colaborador - Administrativo",
            Duration = "08:45",
            ThumbnailUrl = "https://images.unsplash.com/photo-1454165833767-027ffea9e77b?auto=format&fit=crop&w=1200",
            Category = "Treinamentos",
            Description = "Onboarding completo para novos colaboradores da área administrativa: cultura organizacional, benefícios, sistemas internos e fluxos de trabalho.",
            PublishDate = "Jan 2024"
        },
        new()
        {
            Id = 6,
            Title = "Planejamento Logístico para 2025",
            Duration = "2:30:00",
            ThumbnailUrl = "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=1200",
            Category = "Reuniões",
            Description = "Reunião de planejamento estratégico com as equipes de logística para definição de rotas, parceiros e metas de entrega para o ano de 2025.",
            PublishDate = "Nov 2024"
        },
        new()
        {
            Id = 7,
            Title = "Integração: Valores e Cultura Alimentar",
            Duration = "15:30",
            ThumbnailUrl = "https://images.unsplash.com/photo-1517048676732-d65bc937f952?auto=format&fit=crop&w=1200",
            Category = "Treinamentos",
            Description = "Apresentação dos valores fundamentais da JBS, missão, visão e os compromissos com a cadeia alimentar sustentável e responsável.",
            PublishDate = "Abr 2024"
        },
        new()
        {
            Id = 8,
            Title = "Inovação na Cadeia de Suprimentos",
            Duration = "34:10",
            ThumbnailUrl = "https://images.unsplash.com/photo-1565610222536-ef125c59da2e?auto=format&fit=crop&w=1200",
            Category = "Treinamentos",
            Description = "Case de inovação aplicada à cadeia de suprimentos da JBS, com uso de tecnologia para rastreamento, eficiência operacional e redução de desperdício.",
            PublishDate = "Ago 2024"
        },
    ];

    /// <summary>Página principal — exibe o catálogo completo de vídeos.</summary>
    public IActionResult Index()
    {
        return View(_catalog);
    }

    /// <summary>
    /// Página de visualização de um vídeo específico.
    /// Exibe o player com as informações do vídeo e sugestões relacionadas.
    /// </summary>
    /// <param name="id">Identificador do vídeo. Padrão: primeiro do catálogo.</param>
    public IActionResult Watch(int id = 1)
    {
        var current = _catalog.FirstOrDefault(v => v.Id == id) ?? _catalog[0];

        var viewModel = new WatchViewModel
        {
            Video = current,
            Suggestions = _catalog.Where(v => v.Id != current.Id).Take(2).ToList()
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

