using System.IO;
using UnityEditor;
using UnityEngine;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace Snowman.Editor
{
    public static class ExcelTemplateGenerator
    {
        private const string ExcelPath = "Assets/Data/ProjectBalance.xlsx";

        [MenuItem("Snowman/Data/Generate Blank Excel Template")]
        public static void GenerateTemplate()
        {
            string directory = Path.GetDirectoryName(ExcelPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            IWorkbook workbook = new XSSFWorkbook();

            // Stats Sheet
            ISheet statsSheet = workbook.CreateSheet("Stats");
            IRow statsHeader = statsSheet.CreateRow(0);
            statsHeader.CreateCell(0).SetCellValue("ID");
            statsHeader.CreateCell(1).SetCellValue("BaseValue");
            statsHeader.CreateCell(2).SetCellValue("GrowthRate");

            // Items Sheet
            ISheet itemsSheet = workbook.CreateSheet("Items");
            IRow itemsHeader = itemsSheet.CreateRow(0);
            itemsHeader.CreateCell(0).SetCellValue("ID");
            itemsHeader.CreateCell(1).SetCellValue("Tier");
            itemsHeader.CreateCell(2).SetCellValue("StatMultiplier");

            // Monsters Sheet
            ISheet monsterSheet = workbook.CreateSheet("Monsters");
            IRow monsterHeader = monsterSheet.CreateRow(0);
            monsterHeader.CreateCell(0).SetCellValue("ID");
            monsterHeader.CreateCell(1).SetCellValue("HP");
            monsterHeader.CreateCell(2).SetCellValue("GoldReward");

            using (FileStream fileStream = new FileStream(ExcelPath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fileStream);
            }

            AssetDatabase.Refresh();
            Debug.Log($"[ExcelTemplateGenerator] Blank template created at: {ExcelPath}");
        }
    }
}
