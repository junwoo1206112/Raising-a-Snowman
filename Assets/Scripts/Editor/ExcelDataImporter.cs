using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Snowman.Core.Data;

namespace Snowman.Editor
{
    public static class ExcelDataImporter
    {
        private const string ExcelPath = "Assets/Data/ProjectBalance.xlsx";
        private const string OutputRoot = "Assets/Resources/Data/";

        [MenuItem("Snowman/Data/Import All from Excel")]
        public static void ImportAll()
        {
            if (!File.Exists(ExcelPath))
            {
                Debug.LogError($"[ExcelDataImporter] Excel file not found: {ExcelPath}");
                return;
            }

            using (FileStream fileStream = new FileStream(ExcelPath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(fileStream);

                ImportSheet<StatsConfigSO>(workbook, "Stats", row => new StatsConfigSO
                {
                    id = row.GetCell(0)?.StringCellValue ?? "",
                    baseValue = (float)(row.GetCell(1)?.NumericCellValue ?? 0),
                    growthRate = (float)(row.GetCell(2)?.NumericCellValue ?? 0)
                });

                ImportSheet<ItemConfigSO>(workbook, "Items", row => new ItemConfigSO
                {
                    id = row.GetCell(0)?.StringCellValue ?? "",
                    tier = (int)(row.GetCell(1)?.NumericCellValue ?? 0),
                    statMultiplier = (float)(row.GetCell(2)?.NumericCellValue ?? 0)
                });

                ImportSheet<MonsterConfigSO>(workbook, "Monsters", row => new MonsterConfigSO
                {
                    id = row.GetCell(0)?.StringCellValue ?? "",
                    hp = (float)(row.GetCell(1)?.NumericCellValue ?? 0),
                    goldReward = (int)(row.GetCell(2)?.NumericCellValue ?? 0)
                });
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("[ExcelDataImporter] All data imported successfully.");
        }

        private static void ImportSheet<T>(IWorkbook workbook, string sheetName, System.Func<IRow, T> factory) where T : DataConfigSO
        {
            ISheet sheet = workbook.GetSheet(sheetName);
            if (sheet == null)
            {
                Debug.LogWarning($"[ExcelDataImporter] Sheet '{sheetName}' not found. Skipping.");
                return;
            }

            string subFolder = Path.Combine(OutputRoot, sheetName);
            if (!Directory.Exists(subFolder))
                Directory.CreateDirectory(subFolder);

            List<string> existingGuids = new List<string>(AssetDatabase.FindAssets($"t:{typeof(T).Name}", new[] { subFolder }));
            foreach (string guid in existingGuids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                AssetDatabase.DeleteAsset(path);
            }

            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null) continue;

                T config = factory(row);
                if (string.IsNullOrEmpty(config.id)) continue;

                string assetPath = Path.Combine(subFolder, $"{config.id}.asset");
                AssetDatabase.CreateAsset(config, assetPath);
            }

            Debug.Log($"[ExcelDataImporter] Imported {sheetName} sheet -> {subFolder}");
        }
    }
}
