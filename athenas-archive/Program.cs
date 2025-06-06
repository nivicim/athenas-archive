// Importa��es comuns no topo do arquivo
using athenas_archive.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // Habilita a renderiza��o interativa no servidor

// Se voc� tiver outros servi�os (ex: HttpClient, servi�os de autentica��o, etc.), adicione-os aqui.
// Exemplo: builder.Services.AddHttpClient();

var app = builder.Build();

// Configura o pipeline de requisi��es HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Voc� precisar� criar uma p�gina /Error
    // O valor padr�o HSTS � 30 dias. Voc� pode querer mudar isso para cen�rios de produ��o, veja https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Para servir arquivos de wwwroot (como css/app.css)
app.UseAntiforgery(); // Necess�rio para formul�rios em componentes interativos no servidor

// Mapeia o componente raiz App.razor.
// Opcionalmente, voc� pode adicionar um HeadOutlet aqui se n�o estiver no App.razor diretamente.
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // Define o modo de renderiza��o interativa no servidor para os componentes mapeados.

// Se voc� tiver uma p�gina /Error.cshtml ou /Error.razor para o UseExceptionHandler:
// app.MapFallbackToPage("/_Host"); // Para cen�rios de erro mais complexos ou se voc� tiver uma p�gina de erro Blazor espec�fica.
// Ou, para uma p�gina de erro Razor (n�o Blazor component)
// app.MapGet("/Error", async context =>
// {
//     context.Response.ContentType = "text/html";
//     await context.Response.WriteAsync("<html><body><h1>Erro Inesperado.</h1><p>Desculpe, algo deu errado.</p></body></html>");
// });


app.Run();
