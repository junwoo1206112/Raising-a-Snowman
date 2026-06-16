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

            // Skills Sheet
            ISheet skillSheet = workbook.CreateSheet("Skills");
            IRow skillHeader = skillSheet.CreateRow(0);
            skillHeader.CreateCell(0).SetCellValue("ID");
            skillHeader.CreateCell(1).SetCellValue("DamageMultiplier");
            skillHeader.CreateCell(2).SetCellValue("Cooldown");
            skillHeader.CreateCell(3).SetCellValue("Duration");
            skillHeader.CreateCell(4).SetCellValue("ManaCost");
            skillHeader.CreateCell(5).SetCellValue("BaseUpgradeCost");
            skillHeader.CreateCell(6).SetCellValue("MaxLevel");

            // Pets Sheet
            ISheet petSheet = workbook.CreateSheet("Pets");
            IRow petHeader = petSheet.CreateRow(0);
            petHeader.CreateCell(0).SetCellValue("ID");
            petHeader.CreateCell(1).SetCellValue("Tier");
            petHeader.CreateCell(2).SetCellValue("AttackDamage");
            petHeader.CreateCell(3).SetCellValue("AttackSpeed");
            petHeader.CreateCell(4).SetCellValue("BuffType");
            petHeader.CreateCell(5).SetCellValue("BuffValue");
            petHeader.CreateCell(6).SetCellValue("UnlockStage");

            // Rebirth Sheet
            ISheet rebirthSheet = workbook.CreateSheet("Rebirth");
            IRow rebirthHeader = rebirthSheet.CreateRow(0);
            rebirthHeader.CreateCell(0).SetCellValue("ID");
            rebirthHeader.CreateCell(1).SetCellValue("StageRequired");
            rebirthHeader.CreateCell(2).SetCellValue("AtkMultiplierBonus");
            rebirthHeader.CreateCell(3).SetCellValue("GoldMultiplierBonus");
            rebirthHeader.CreateCell(4).SetCellValue("StartLevelBonus");

            // Quests Sheet
            ISheet questSheet = workbook.CreateSheet("Quests");
            IRow questHeader = questSheet.CreateRow(0);
            questHeader.CreateCell(0).SetCellValue("ID");
            questHeader.CreateCell(1).SetCellValue("QuestType");
            questHeader.CreateCell(2).SetCellValue("RequirementType");
            questHeader.CreateCell(3).SetCellValue("RequirementValue");
            questHeader.CreateCell(4).SetCellValue("RewardGold");
            questHeader.CreateCell(5).SetCellValue("RewardItemId");

            // Achievements Sheet
            ISheet achievementSheet = workbook.CreateSheet("Achievements");
            IRow achievementHeader = achievementSheet.CreateRow(0);
            achievementHeader.CreateCell(0).SetCellValue("ID");
            achievementHeader.CreateCell(1).SetCellValue("RequirementType");
            achievementHeader.CreateCell(2).SetCellValue("RequirementValue");
            achievementHeader.CreateCell(3).SetCellValue("RewardGold");
            achievementHeader.CreateCell(4).SetCellValue("PermanentStatBonus");

            // Dungeons Sheet
            ISheet dungeonSheet = workbook.CreateSheet("Dungeons");
            IRow dungeonHeader = dungeonSheet.CreateRow(0);
            dungeonHeader.CreateCell(0).SetCellValue("ID");
            dungeonHeader.CreateCell(1).SetCellValue("DungeonType");
            dungeonHeader.CreateCell(2).SetCellValue("DailyEntryLimit");
            dungeonHeader.CreateCell(3).SetCellValue("MonsterHpMultiplier");
            dungeonHeader.CreateCell(4).SetCellValue("GoldRewardMultiplier");
            dungeonHeader.CreateCell(5).SetCellValue("UnlockStage");

            // OfflineRewards Sheet
            ISheet offlineSheet = workbook.CreateSheet("OfflineRewards");
            IRow offlineHeader = offlineSheet.CreateRow(0);
            offlineHeader.CreateCell(0).SetCellValue("ID");
            offlineHeader.CreateCell(1).SetCellValue("GoldPerHourBase");
            offlineHeader.CreateCell(2).SetCellValue("ExperiencePerHourBase");
            offlineHeader.CreateCell(3).SetCellValue("GoldGrowthRate");

            using (FileStream fileStream = new FileStream(ExcelPath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fileStream);
            }

            AssetDatabase.Refresh();
            Debug.Log($"[ExcelTemplateGenerator] Blank template created at: {ExcelPath}");
        }
    }
}
