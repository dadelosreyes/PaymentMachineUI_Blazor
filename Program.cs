using BlazorApp3.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddBlazorBootstrap();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = true;
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Add these in the correct order
app.UseRouting();
app.UseAuthentication();  // Add if you're using authentication
app.UseAuthorization();   // Add if you're using authorization
app.UseAntiforgery();

// Map endpoints last
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();