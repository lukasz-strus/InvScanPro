﻿using CommunityToolkit.Mvvm.ComponentModel;
using InvScanPro.Services;
using System;

namespace InvScanPro.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty] private string? _caption;

    protected readonly IStorageService _storageService;

    public BaseViewModel(IStorageService storageService)
    {
        _storageService = storageService;
    }
    protected void SetCaption(string label)
    {
        Application.Current!.Resources.TryGetValue(label, out object title);

        var items = _storageService.GetInventoryItems();

        Caption = items.Count == 0 ? $"{title}" : $"{title} ({items[0].Countingnum})";
    }
}
