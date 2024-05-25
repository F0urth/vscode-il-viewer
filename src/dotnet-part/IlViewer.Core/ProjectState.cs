using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.DotNet.ProjectModel;

namespace IlViewer.Core;

public class ProjectState
{
    public ProjectState(ProjectId id, ProjectContext context)
    {
        Id = id;
        ProjectContext = context;
    }

    public ProjectId Id { get; }

    public ProjectContext ProjectContext { get; set; }

    public Dictionary<string, MetadataReference> FileMetadataReferences { get; } = new();

    public Dictionary<string, ProjectId> ProjectReferences { get; } = new();

    public Dictionary<string, DocumentId> DocumentReferences { get; } = new();

    public override string ToString()
    {
        return $"[{nameof(ProjectState)}] {ProjectContext.ProjectFile.Name}/{ProjectContext.TargetFramework}";
    }
}