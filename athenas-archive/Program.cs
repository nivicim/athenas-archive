// Importações comuns no topo do arquivo
using athenas_archive.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // Habilita a renderização interativa no servidor

// Se você tiver outros serviços (ex: HttpClient, serviços de autenticação, etc.), adicione-os aqui.
// Exemplo: builder.Services.AddHttpClient();

var app = builder.Build();

// Configura o pipeline de requisições HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Você precisará criar uma página /Error
    // O valor padrão HSTS é 30 dias. Você pode querer mudar isso para cenários de produção, veja https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Para servir arquivos de wwwroot (como css/app.css)
app.UseAntiforgery(); // Necessário para formulários em componentes interativos no servidor

// Mapeia o componente raiz App.razor.
// Opcionalmente, você pode adicionar um HeadOutlet aqui se não estiver no App.razor diretamente.
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // Define o modo de renderização interativa no servidor para os componentes mapeados.

// Se você tiver uma página /Error.cshtml ou /Error.razor para o UseExceptionHandler:
// app.MapFallbackToPage("/_Host"); // Para cenários de erro mais complexos ou se você tiver uma página de erro Blazor específica.
// Ou, para uma página de erro Razor (não Blazor component)
// app.MapGet("/Error", async context =>
// {
//     context.Response.ContentType = "text/html";
//     await context.Response.WriteAsync("<html><body><h1>Erro Inesperado.</h1><p>Desculpe, algo deu errado.</p></body></html>");
// });


app.Run();
