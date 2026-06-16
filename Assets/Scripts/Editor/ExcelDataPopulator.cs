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
            PopulateSkills(workbook);
            PopulatePets(workbook);
            PopulateRebirth(workbook);
            PopulateQuests(workbook);
            PopulateAchievements(workbook);
            PopulateDungeons(workbook);
            PopulateOfflineRewards(workbook);

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

        private static void PopulateSkills(IWorkbook workbook)
        {
            ISheet sheet = workbook.GetSheet("Skills");
            if (sheet == null)
            {
                Debug.LogWarning("[ExcelDataPopulator] 'Skills' sheet not found.");
                return;
            }

            string[,] skillsData =
            {
                { "Skill_Snowstorm",     "1.5",  "10",   "3",    "20",   "100",  "20" },
                { "Skill_IceExplosion",  "3.0",  "25",   "1",    "35",   "200",  "20" },
                { "Skill_IcicleDrop",    "2.0",  "15",   "4",    "25",   "150",  "20" },
                { "Skill_FrostArmor",    "0.0",  "30",   "8",    "40",   "250",  "20" },
                { "Skill_Blizzard",      "5.0",  "60",   "5",    "60",   "500",  "10" }
            };

            int rowCount = skillsData.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                row.CreateCell(0).SetCellValue(skillsData[i, 0]);
                row.CreateCell(1).SetCellValue(double.Parse(skillsData[i, 1]));
                row.CreateCell(2).SetCellValue(double.Parse(skillsData[i, 2]));
                row.CreateCell(3).SetCellValue(double.Parse(skillsData[i, 3]));
                row.CreateCell(4).SetCellValue(int.Parse(skillsData[i, 4]));
                row.CreateCell(5).SetCellValue(int.Parse(skillsData[i, 5]));
                row.CreateCell(6).SetCellValue(int.Parse(skillsData[i, 6]));
            }

            Debug.Log($"[ExcelDataPopulator] Skills: {rowCount} entries written.");
        }

        private static void PopulatePets(IWorkbook workbook)
        {
            ISheet sheet = workbook.GetSheet("Pets");
            if (sheet == null)
            {
                Debug.LogWarning("[ExcelDataPopulator] 'Pets' sheet not found.");
                return;
            }

            string[,] petsData =
            {
                { "Pet_SnowPuff",     "0",  "5",    "1.0",  "Atk",    "1.1",  "0"  },
                { "Pet_Penguin",      "1",  "12",   "0.8",  "Gold",   "1.1",  "5"  },
                { "Pet_IceFairy",     "2",  "25",   "0.7",  "HP",     "1.15", "10" },
                { "Pet_PolarBear",    "3",  "50",   "0.6",  "Atk",    "1.3",  "20" },
                { "Pet_FrostDragon",  "4",  "100",  "0.5",  "Gold",   "1.5",  "40" },
                { "Pet_SnowSpirit",   "5",  "200",  "0.4",  "Atk",    "2.0",  "80" }
            };

            int rowCount = petsData.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                row.CreateCell(0).SetCellValue(petsData[i, 0]);
                row.CreateCell(1).SetCellValue(int.Parse(petsData[i, 1]));
                row.CreateCell(2).SetCellValue(double.Parse(petsData[i, 2]));
                row.CreateCell(3).SetCellValue(double.Parse(petsData[i, 3]));
                row.CreateCell(4).SetCellValue(petsData[i, 4]);
                row.CreateCell(5).SetCellValue(double.Parse(petsData[i, 5]));
                row.CreateCell(6).SetCellValue(int.Parse(petsData[i, 6]));
            }

            Debug.Log($"[ExcelDataPopulator] Pets: {rowCount} entries written.");
        }

        private static void PopulateRebirth(IWorkbook workbook)
        {
            ISheet sheet = workbook.GetSheet("Rebirth");
            if (sheet == null)
            {
                Debug.LogWarning("[ExcelDataPopulator] 'Rebirth' sheet not found.");
                return;
            }

            string[,] rebirthData =
            {
                { "Rebirth_1",  "50",  "2.0",   "1.5",  "0"  },
                { "Rebirth_2",  "100", "5.0",   "2.5",  "5"  },
                { "Rebirth_3",  "200", "12.0",  "4.0",  "10" },
                { "Rebirth_4",  "400", "30.0",  "7.0",  "20" },
                { "Rebirth_5",  "800", "80.0",  "12.0", "35" }
            };

            int rowCount = rebirthData.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                row.CreateCell(0).SetCellValue(rebirthData[i, 0]);
                row.CreateCell(1).SetCellValue(int.Parse(rebirthData[i, 1]));
                row.CreateCell(2).SetCellValue(double.Parse(rebirthData[i, 2]));
                row.CreateCell(3).SetCellValue(double.Parse(rebirthData[i, 3]));
                row.CreateCell(4).SetCellValue(int.Parse(rebirthData[i, 4]));
            }

            Debug.Log($"[ExcelDataPopulator] Rebirth: {rowCount} entries written.");
        }

        private static void PopulateQuests(IWorkbook workbook)
        {
            ISheet sheet = workbook.GetSheet("Quests");
            if (sheet == null)
            {
                Debug.LogWarning("[ExcelDataPopulator] 'Quests' sheet not found.");
                return;
            }

            string[,] questsData =
            {
                { "Quest_Daily_Kill100",   "Daily",  "Kill",   "100",    "500",    ""             },
                { "Quest_Daily_Gold1K",    "Daily",  "Gold",   "1000",   "800",    ""             },
                { "Quest_Daily_Stage10",   "Daily",  "Stage",  "10",     "1000",   "Item_Bronze"  },
                { "Quest_Weekly_Kill1000", "Weekly", "Kill",   "1000",   "5000",   "Item_Silver"  },
                { "Quest_Weekly_Gold10K",  "Weekly", "Gold",   "10000",  "8000",   ""             },
                { "Quest_Weekly_Stage50",  "Weekly", "Stage",  "50",     "10000",  "Item_Gold"    }
            };

            int rowCount = questsData.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                row.CreateCell(0).SetCellValue(questsData[i, 0]);
                row.CreateCell(1).SetCellValue(questsData[i, 1]);
                row.CreateCell(2).SetCellValue(questsData[i, 2]);
                row.CreateCell(3).SetCellValue(int.Parse(questsData[i, 3]));
                row.CreateCell(4).SetCellValue(int.Parse(questsData[i, 4]));
                row.CreateCell(5).SetCellValue(questsData[i, 5]);
            }

            Debug.Log($"[ExcelDataPopulator] Quests: {rowCount} entries written.");
        }

        private static void PopulateAchievements(IWorkbook workbook)
        {
            ISheet sheet = workbook.GetSheet("Achievements");
            if (sheet == null)
            {
                Debug.LogWarning("[ExcelDataPopulator] 'Achievements' sheet not found.");
                return;
            }

            string[,] achievementsData =
            {
                { "Ach_Kill_100",        "Kill",   "100",    "1000",   "0.02" },
                { "Ach_Kill_1000",       "Kill",   "1000",   "10000",  "0.05" },
                { "Ach_Kill_10000",      "Kill",   "10000",  "100000", "0.1"  },
                { "Ach_Gold_1M",         "Gold",   "1000000","50000",  "0.03" },
                { "Ach_Stage_50",        "Stage",  "50",     "20000",  "0.05" },
                { "Ach_Stage_100",       "Stage",  "100",    "100000", "0.1"  },
                { "Ach_PetCollect_5",    "PetOwn", "5",      "30000",  "0.05" },
                { "Ach_Rebirth_1",       "Rebirth","1",      "100000", "0.15" }
            };

            int rowCount = achievementsData.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                row.CreateCell(0).SetCellValue(achievementsData[i, 0]);
                row.CreateCell(1).SetCellValue(achievementsData[i, 1]);
                row.CreateCell(2).SetCellValue(int.Parse(achievementsData[i, 2]));
                row.CreateCell(3).SetCellValue(int.Parse(achievementsData[i, 3]));
                row.CreateCell(4).SetCellValue(double.Parse(achievementsData[i, 4]));
            }

            Debug.Log($"[ExcelDataPopulator] Achievements: {rowCount} entries written.");
        }

        private static void PopulateDungeons(IWorkbook workbook)
        {
            ISheet sheet = workbook.GetSheet("Dungeons");
            if (sheet == null)
            {
                Debug.LogWarning("[ExcelDataPopulator] 'Dungeons' sheet not found.");
                return;
            }

            string[,] dungeonsData =
            {
                { "Dungeon_GoldCave",      "Gold",   "3",  "1.5",  "3.0",  "5"  },
                { "Dungeon_ItemForge",     "Item",   "2",  "2.0",  "1.5",  "15" },
                { "Dungeon_PetNest",       "Pet",    "1",  "3.0",  "2.0",  "30" },
                { "Dungeon_ChallengeTower","Boss",   "1",  "5.0",  "5.0",  "50" }
            };

            int rowCount = dungeonsData.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                row.CreateCell(0).SetCellValue(dungeonsData[i, 0]);
                row.CreateCell(1).SetCellValue(dungeonsData[i, 1]);
                row.CreateCell(2).SetCellValue(int.Parse(dungeonsData[i, 2]));
                row.CreateCell(3).SetCellValue(double.Parse(dungeonsData[i, 3]));
                row.CreateCell(4).SetCellValue(double.Parse(dungeonsData[i, 4]));
                row.CreateCell(5).SetCellValue(int.Parse(dungeonsData[i, 5]));
            }

            Debug.Log($"[ExcelDataPopulator] Dungeons: {rowCount} entries written.");
        }

        private static void PopulateOfflineRewards(IWorkbook workbook)
        {
            ISheet sheet = workbook.GetSheet("OfflineRewards");
            if (sheet == null)
            {
                Debug.LogWarning("[ExcelDataPopulator] 'OfflineRewards' sheet not found.");
                return;
            }

            string[,] offlineData =
            {
                { "Offline_Default", "100",   "50",   "1.1" }
            };

            int rowCount = offlineData.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                row.CreateCell(0).SetCellValue(offlineData[i, 0]);
                row.CreateCell(1).SetCellValue(double.Parse(offlineData[i, 1]));
                row.CreateCell(2).SetCellValue(double.Parse(offlineData[i, 2]));
                row.CreateCell(3).SetCellValue(double.Parse(offlineData[i, 3]));
            }

            Debug.Log($"[ExcelDataPopulator] OfflineRewards: {rowCount} entries written.");
        }
    }
}
