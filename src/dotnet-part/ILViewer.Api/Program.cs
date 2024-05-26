using ILViewer.Api;
using IlViewer.Core.ResultOutput;
using IlViewer.Core;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHsts().UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("il-viewer/ping", () => "Pong");
app.MapPost("il-viewer/il", HandleIlRequest);

static InspectionResult HandleIlRequest(IlRequest request)
{
    ArgumentNullException.ThrowIfNull(request);
    Debug.WriteLine(request);
    try
    {
        return IlGeneration.ExtractIl(request.ProjectFilePath, request.Filename);
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex);
        throw;
    }
}

app.Run();