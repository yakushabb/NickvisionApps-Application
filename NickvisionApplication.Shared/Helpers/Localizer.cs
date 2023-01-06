﻿using System.Globalization;
using System.Resources;

namespace NickvisionApplication.Shared.Helpers;

/// <summary>
/// A helper for getting localized strings
/// </summary>
public class Localizer
{
    private readonly ResourceManager _resourceManager;
    private readonly ResourceSet _resourceSet;
    private readonly ResourceSet _resourceFallback;

    /// <summary>
    /// Gets a localized non-plural/plural string
    /// </summary>
    /// <param name="name">The name of the string resource</param>
    /// <param name="plural">Whether or not to get a plural string resource</param>
    /// <returns>The localized string</returns>
    public string this[string name, bool plural = false] => plural ? GetPluralString(name) : GetString(name);
    /// <summary>
    /// Gets a localized string by context
    /// </summary>
    /// <param name="name">The name of the string resource</param>
    /// <param name="context">The name of the context</param>
    /// <returns>The localized string with the context</returns>
    public string this[string name, string context] => GetStringWithContext(name, context);

    /// <summary>
    /// Constructs a Localizer
    /// </summary>
    internal Localizer()
    { 
        _resourceManager = new ResourceManager("NickvisionApplication.Shared.Resources.Strings", GetType().Assembly);
        _resourceSet = _resourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true)!;
        _resourceFallback = _resourceManager.GetResourceSet(new CultureInfo("en-US"), true, true)!;
    }

    /// <summary>
    /// Gets a localized string
    /// </summary>
    /// <param name="name">The name of the string resource</param>
    /// <returns>The localized string</returns>
    public string GetString(string name) => _resourceSet.GetString(name) ?? _resourceFallback.GetString(name) ?? string.Empty;

    /// <summary>
    /// Gets a localized string by context
    /// </summary>
    /// <param name="name">The name of the string resource</param>
    /// <param name="context">The name of the context</param>
    /// <returns>The localized string with the context</returns>
    public string GetStringWithContext(string name, string context) => GetString($"{name}.{context}");

    /// <summary>
    /// Gets a localized plural string
    /// </summary>
    /// <param name="name">The name of the string resource</param>
    /// <returns>The localized plural string</returns>
    public string GetPluralString(string name) => GetString($"{name}.Plural");
}