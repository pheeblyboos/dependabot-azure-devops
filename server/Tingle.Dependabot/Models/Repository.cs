﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tingle.Dependabot.Models;

public class Repository
{
    [Key, MaxLength(50)]
    public string? Id { get; set; }

    public DateTimeOffset Created { get; set; }

    public DateTimeOffset Updated { get; set; }

    /// <summary>Name of the repository as per provider.</summary>
    public string? Name { get; set; }
    public string? Slug { get; set; }

    /// <summary>Identifier of the repository as per provider.</summary>
    [JsonIgnore] // only for internal use
    public string? ProviderId { get; set; }

    /// <summary>
    /// Latest commit SHA synchronized for the configuration file.
    /// </summary>
    [MaxLength(200)]
    public string? LatestCommit { get; set; }

    /// <summary>Contents of the configuration file as of <see cref="LatestCommit"/>.</summary>
    [Required]
    [JsonIgnore] // only for internal use
    public string? ConfigFileContents { get; set; }

    /// <summary>
    /// Exception that encountered, if any, when parsing the configuration file.
    /// This is populated when <c>updates</c> is <c>null</c> or empty.
    /// </summary>
    public string? SyncException { get; set; }

    /// <summary>
    /// Updates for the repository, extracted from the configuration file.
    /// When <c>null</c> or empty, there was a parsing exception.
    /// </summary>
    public List<RepositoryUpdate> Updates { get; set; } = new List<RepositoryUpdate>();

    /// <summary>
    /// Registries for the repository, extracted from the configuration file.
    /// When <c>null</c> or empty, there was a parsing exception.
    /// </summary>
    [JsonIgnore] // only for internal use
    public List<DependabotRegistry> Registries { get; set; } = new List<DependabotRegistry>();

    [Timestamp]
    public byte[]? Etag { get; set; }
}
