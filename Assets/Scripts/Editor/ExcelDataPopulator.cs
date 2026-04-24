using System.IO;
using UnityEditor;
using UnityEngine;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Snowman.Editor
{
    public static class ExcelDataPopulator
    {
        private const string ExcelPath = "Assets/Data/ProjectBalance.xlsx";

        [MenuItem("Snowman/Data/Populate Excel with Game Data")]
        public static void PopulateExcel()
        {
            if (!File.Exists(ExcelPath))
            {
                Debug.LogError($"[ExcelDataPopulator] Excel file not found: {ExcelPath}. Generate template first.");
                return;
            }

            IWorkbook workbook;

            using (FileStream readStream = new FileStream(ExcelPath, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(readStream);
            }

            PopulateStats(workbook);
            PopulateItems(workbook);
            PopulateMonsters(workbook);

            using (FileStream writeStream = new FileStream(ExcelPath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(writeStream);
            }

            AssetDatabase.Refresh();
            Debug.Log("[ExcelDataPopulator] Game data populated successfully. Run 'Import All from Excel' to generate SO assets.");
        }

        private static void PopulateStats(IWorkbook workbook)
        {
            ISheet sheet = workbook.GetSheet("Stats");
            if (sheet == null)
            {
                Debug.LogWarning("[ExcelDataPopulator] 'Stats' sheet not found.");
                return;
            }

            string[,] statsData =
            {
                { "Atk",          "10",    "2"     },
                { "HP",           "100",   "20"    },
                { "AttackSpeed",  "1",     "0.05"  },
                { "Defense",      "0",     "1.5"   },
                { "CritRate",     "0.05",  "0.005" },
                { "CritDamage",   "1.5",   "0.1"   }
            };

            int rowCount = statsData.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                row.CreateCell(0).SetCellValue(statsData[i, 0]);
                row.CreateCell(1).SetCellValue(double.Parse(statsData[i, 1]));
                row.CreateCell(2).SetCellValue(double.Parse(statsData[i, 2]));
            }

            Debug.Log($"[ExcelDataPopulator] Stats: {rowCount} entries written.");
        }

        private static void PopulateItems(IWorkbook workbook)
        {
            ISheet sheet = workbook.GetSheet("Items");
            if (sheet == null)
            {
                Debug.LogWarning("[ExcelDataPopulator] 'Items' sheet not found.");
                return;
            }

            string[,] itemsData =
            {
                { "Item_Bronze",    "0", "1.0"  },
                { "Item_Silver",    "1", "1.6"  },
                { "Item_Gold",      "2", "2.5"  },
                { "Item_Platinum",  "3", "4.0"  },
                { "Item_Diamond",   "4", "6.5"  },
                { "Item_Mythic",    "5", "10.0" }
            };

            int rowCount = itemsData.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                row.CreateCell(0).SetCellValue(itemsData[i, 0]);
                row.CreateCell(1).SetCellValue(int.Parse(itemsData[i, 1]));
                row.CreateCell(2).SetCellValue(double.Parse(itemsData[i, 2]));
            }

            Debug.Log($"[ExcelDataPopulator] Items: {rowCount} entries written.");
        }

        private static void PopulateMonsters(IWorkbook workbook)
        {
            ISheet sheet = workbook.GetSheet("Monsters");
            if (sheet == null)
            {
                Debug.LogWarning("[ExcelDataPopulator] 'Monsters' sheet not found.");
                return;
            }

            string[,] monstersData =
            {
                { "Slime",           "20",     "5"     },
                { "SnowBall",        "50",     "12"    },
                { "IceBat",          "90",     "25"    },
                { "FrostWolf",       "150",    "50"    },
                { "SnowGolem",       "250",    "85"    },
                { "IceWraith",       "420",    "140"   },
                { "FrostBear",       "700",    "230"   },
                { "SnowDrake",       "1200",   "380"   },
                { "IceElemental",    "2000",   "600"   },
                { "FrostYeti",       "3500",   "1000"  },
                { "Boss_IceGolem",   "8000",   "5000"  },
                { "Boss_FrostDragon","20000",  "15000" },
                { "Boss_LichKing",   "50000",  "50000" }
            };

            int rowCount = monstersData.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                row.CreateCell(0).SetCellValue(monstersData[i, 0]);
                row.CreateCell(1).SetCellValue(double.Parse(monstersData[i, 1]));
                row.CreateCell(2).SetCellValue(int.Parse(monstersData[i, 2]));
            }

            Debug.Log($"[ExcelDataPopulator] Monsters: {rowCount} entries written.");
        }
    }
}
