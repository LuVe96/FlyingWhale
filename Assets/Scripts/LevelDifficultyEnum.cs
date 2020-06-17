using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public enum LevelDifficulty
    {
        Easy,
        Normal,
        Hard,
        End
    }

    // extension für enum: PlayerSpeed
    static class LevelDifficultyMethods
    {
        // here define how many obj the levelgenerat uses on each dificulty
        public static Dictionary<string, int> getNumberofObj(this LevelDifficulty d1)
        {
            Dictionary<string, int> amountOfObjDic = new Dictionary<string, int>();
            amountOfObjDic.Add("numberOfFish", 0);
            amountOfObjDic.Add("numberOfRainCloud", 0);
            amountOfObjDic.Add("numberOfSunnyCloud", 0);
            switch (d1)
            {
                case LevelDifficulty.Easy:
                    amountOfObjDic["numberOfFish"] = 50;
                    amountOfObjDic["numberOfRainCloud"] = 10;
                    amountOfObjDic["numberOfSunnyCloud"] = 20;
                    return amountOfObjDic;
                case LevelDifficulty.Normal:
                    amountOfObjDic["numberOfFish"] = 20;
                    amountOfObjDic["numberOfRainCloud"] = 10;
                    amountOfObjDic["numberOfSunnyCloud"] = 30;
                    return amountOfObjDic;
                case LevelDifficulty.Hard:
                    amountOfObjDic["numberOfFish"] = 10;
                    amountOfObjDic["numberOfRainCloud"] = 30;
                    amountOfObjDic["numberOfSunnyCloud"] = 20;
                    return amountOfObjDic;
            case LevelDifficulty.End:
                amountOfObjDic["numberOfFish"] = 0;
                amountOfObjDic["numberOfRainCloud"] = 0;
                amountOfObjDic["numberOfSunnyCloud"] = 0;
                return amountOfObjDic;
            default:
                    return amountOfObjDic;

            }
        }
    }
