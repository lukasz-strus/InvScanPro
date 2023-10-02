using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using CsvHelper;
using CsvHelper.Configuration;
using InvScanPro.Helpers;
using InvScanPro.Models;
using System.Globalization;
using System.Threading;

#if ANDROID
using Android;
using Android.Content.PM;
using AndroidX.Core.App;
using AndroidX.Core.Content;
#endif


namespace InvScanPro.Services;

public interface ICsvFileService
{
    Task<List<InventoryItem>> LoadCsvFileAsync();
    Task SaveCsvFileAsync(List<InventoryItem> items);

}

public class CsvFileService : ICsvFileService
{
    private readonly IFileSaver _fileSaver;

    public CsvFileService(IFileSaver fileSaver)
    {
        _fileSaver = fileSaver;
    }
    public async Task SaveCsvFileAsync(List<InventoryItem> items)
    {
        if (DeviceInfo.Platform == DevicePlatform.Android && OperatingSystem.IsAndroidVersionAtLeast(33))
        {
#if ANDROID
                var activity = Platform.CurrentActivity ?? throw new NullReferenceException("Current activity is null");
                if (ContextCompat.CheckSelfPermission(activity, Manifest.Permission.ReadExternalStorage) != Permission.Granted)
                {
                    ActivityCompat.RequestPermissions(activity, new[] { Manifest.Permission.ReadExternalStorage }, 1);
                }
#endif
        }

        var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        var fullFileName = $"ARCPUBLAssetCountingLine_{timestamp}.csv";

        try
        {
            using var memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream);
            using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = false
            });

            foreach (var item in items)
            {
                WriteItemLine(csv, item);

                await csv.NextRecordAsync();
            }

            await writer.FlushAsync();
            memoryStream.Position = 0;           

            var fileSaverResult = await _fileSaver.SaveAsync(fullFileName, memoryStream, default);
            fileSaverResult.EnsureSuccess();

            await DisplayHelper.DisplayToast("Label_0058", postMessage: fileSaverResult.FilePath);

        }
        catch (Exception)
        {
            await DisplayHelper.DisplayToast("Label_0059");
        }
    }



    public async Task<List<InventoryItem>> LoadCsvFileAsync()
    {
        var records = new List<InventoryItem>();
        Application.Current!.Resources.TryGetValue("Label_0060", out object pickerTitle);

        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = pickerTitle.ToString()
            });

            if (result == null || !result.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                await DisplayHelper.DisplayToast("Label_0057");
                return records;
            }

            using var stream = await result.OpenReadAsync();
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = false
            });

            while (await csv.ReadAsync())
            {
                var item = GetInventoryItemFromCsv(csv);

                records.Add(item);
            }

            return records;
        }
        catch (Exception)
        {
            await DisplayHelper.DisplayToast("Label_0062");
            return default!;
        }
    }

    private static void WriteItemLine(CsvWriter csv, InventoryItem item)
    {
        csv.WriteField(item.Countingnum);
        csv.WriteField(item.Barcode);
        csv.WriteField(item.Name);
        csv.WriteField(item.Count);
        csv.WriteField(item.Info1);
        csv.WriteField(item.Info2);
        csv.WriteField(item.Info3);
        csv.WriteField(item.GroupId);
        csv.WriteField(item.DepertamentId);
        csv.WriteField(null);
        csv.WriteField(null);
        csv.WriteField(item.ProductionDate);
        csv.WriteField(item.UnitOfMeasure);
        csv.WriteField(item.UnitCost);
        csv.WriteField(null);
        csv.WriteField(item.Location);
        csv.WriteField(item.Date);
    }

    private static InventoryItem GetInventoryItemFromCsv(CsvReader csv)
        => new()
        {
            Countingnum = csv.GetField<string>(0)!,
            Barcode = csv.GetField<string>(1)!,
            Name = csv.GetField<string>(2)!,
            Count = csv.GetField<int>(3),
            Info1 = csv.GetField<string?>(4),
            Info2 = csv.GetField<string?>(5),
            Info3 = csv.GetField<string?>(6),
            GroupId = csv.GetField<string?>(7),
            DepertamentId = csv.GetField<string?>(8),
            ProductionDate = csv.GetField<DateTime?>(11),
            UnitOfMeasure = csv.GetField<string>(12)!,
            UnitCost = csv.GetField<decimal>(13),
            Location = csv.GetField<string?>(15),
            Date = csv.GetField<DateTime?>(16)
        };
}
