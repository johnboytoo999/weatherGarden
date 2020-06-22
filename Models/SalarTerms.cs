using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class SalarTerms
    {
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string  Description  { get; set; }

        /// <summary>
        /// 日期描述
        /// </summary>
        public string DayDescription { get; set; }
    }

    public class SalarTermsForYear
    {
        public List<SalarTerms> SalarTerms { get; set; }  

        public List<SalarTerms> Init()
        {
            List<SalarTerms> SalarTerms = new List<SalarTerms>();
            SalarTerms.Add(new SalarTerms()
            {
                Name = "小寒",
                StartDate = new DateTime(DateTime.Now.Year, 1, 5),
                EndDate = new DateTime(DateTime.Now.Year, 1, 19),   
                Description = "天氣相當寒冷，雖進入嚴冬但尚未到達最冷的時候。",
                DayDescription = "1/5~1/19"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "大寒",
                StartDate = new DateTime(DateTime.Now.Year, 1, 19),
                EndDate = new DateTime(DateTime.Now.Year, 2, 3),
                Description = "天氣酷寒，是一年中最冷的日子。",
                DayDescription = "1/19~2/3"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "立春",
                StartDate = new DateTime(DateTime.Now.Year, 2, 3),
                EndDate = new DateTime(DateTime.Now.Year, 2, 18),
                Description = "春季開始，立是開始的意思，春是蠢動，表示萬物開始有生氣",
                DayDescription = "2/3~2/18"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "雨水",
                StartDate = new DateTime(DateTime.Now.Year, 2, 18),
                EndDate = new DateTime(DateTime.Now.Year, 3, 5),
                Description = "春到人間，降雨開始增多，春雨綿綿。",
                DayDescription = "2/18~3/5"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "驚蟄",
                StartDate = new DateTime(DateTime.Now.Year, 3, 5),
                EndDate = new DateTime(DateTime.Now.Year, 3, 20),
                Description = "蟲類冬眠或隱藏起來，伏著不動，叫做蟄。春雷響起，驚醒蟄伏地下冬眠的蟲類，將開始出土活動。",
                DayDescription = "3/5~3/20"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "春分",
                StartDate = new DateTime(DateTime.Now.Year, 3, 20),
                EndDate = new DateTime(DateTime.Now.Year, 4, 4),
                Description = "春季過了一半，此時陽光直射赤道上，這一天太陽從正東方昇起，落於正西方，地球上南北半球受光相等，晝夜長短相等，古代曾稱春分與秋分為晝夜分。",
                DayDescription = "3/20~4/4"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "清明",
                StartDate = new DateTime(DateTime.Now.Year, 4, 4),
                EndDate = new DateTime(DateTime.Now.Year, 4, 19),
                Description = "天氣逐漸和暖，春暖花開，草木開始萌發茂盛，大地一片氣清景明的現象。",
                DayDescription = "4/4~4/19"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "穀雨",
                StartDate = new DateTime(DateTime.Now.Year, 4, 19),
                EndDate = new DateTime(DateTime.Now.Year, 5, 10),
                Description = "雨生百穀的意思，此時農夫剛完成春耕，田裡的秧苗正需大量的雨水滋潤，適時且足夠的雨水才能使穀物成長茁壯。但此時的氣候，卻時晴時雨，時冷時熱，最讓人不易捉摸。",
                DayDescription = "4/19~5/10"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "立夏",
                StartDate = new DateTime(DateTime.Now.Year, 5, 10),
                EndDate = new DateTime(DateTime.Now.Year, 5, 20),
                Description = "夏季開始，此時已出現溫暖的氣候，萬物迅速生長。",
                DayDescription = "5/10~5/20"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "小滿",
                StartDate = new DateTime(DateTime.Now.Year, 5, 20),
                EndDate = new DateTime(DateTime.Now.Year, 6, 5),
                Description = "滿指穀物籽粒飽滿，稻穀和麥類等夏熟農作物行將結實，但尚未達到飽滿的程度。",
                DayDescription = "5/20~6/5"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "芒種",
                StartDate = new DateTime(DateTime.Now.Year, 6, 5),
                EndDate = new DateTime(DateTime.Now.Year, 6, 20),
                Description = "有芒作物開始成熟，結實成穗，此時也是秋季作物播種的適當時節。",
                DayDescription = "6/5~6/20"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "夏至",
                StartDate = new DateTime(DateTime.Now.Year, 6, 20),
                EndDate = new DateTime(DateTime.Now.Year, 7, 6),
                Description = "炎熱的夏天真正到來，此時陽光直射北回歸線上，北半球受光最多，是白天最長黑夜最短的一天，中午時太陽的仰角是一年裡最高的，因此日影是一年中最短的，過了夏至日，白天漸漸變短，夜晚慢慢加長。",
                DayDescription = "6/20~7/6"

            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "小暑",
                StartDate = new DateTime(DateTime.Now.Year, 7, 6),
                EndDate = new DateTime(DateTime.Now.Year, 7, 22),
                Description = "暑是炎熱之意，此時天氣開始逐漸炎熱，但是還沒有熱到極點，雖然夏至時北半球受陽光照射時間最長，由於太陽射來的熱力必須先對地面和大氣加溫，才能把熱儲存於大氣中，所以天氣從夏至開始慢慢加熱，經過小暑後，熱度才會逐漸昇高到極點。",
                DayDescription = "7/6~7/22"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "大暑",
                StartDate = new DateTime(DateTime.Now.Year,7, 22),
                EndDate = new DateTime(DateTime.Now.Year, 8, 7),
                Description = "氣候酷熱到達高峰。",
                DayDescription = "7/22~8/7"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "立秋",
                StartDate = new DateTime(DateTime.Now.Year, 8, 7),
                EndDate = new DateTime(DateTime.Now.Year, 8, 22),
                Description = "秋季開始，氣溫將由熱轉涼，涼爽舒適的秋天就要來臨。",
                DayDescription = "8/7~8/22"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "處暑",
                StartDate = new DateTime(DateTime.Now.Year, 8, 22),
                EndDate = new DateTime(DateTime.Now.Year, 9, 7),
                Description = "處是止的意思，表示夏天的暑氣到此終止，但有時晴天的下午，炎熱不亞於暑夏，可視為夏的迴光返照。",
                DayDescription = "8/22~9/7"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "白露",
                StartDate = new DateTime(DateTime.Now.Year, 9, 7),
                EndDate = new DateTime(DateTime.Now.Year, 9, 22),
                Description = "天氣已經轉涼，夜晚時空氣中所含的水汽，接觸到地面上因輻射而迅速冷卻的物體，於是部份凝結為水滴而附於地面的花草樹葉上，這些透明晶瑩的水珠，我們就稱它為白露。",
                DayDescription = "9/7~9/22"
            }); SalarTerms.Add(new SalarTerms()
            {
                Name = "秋分",
                StartDate = new DateTime(DateTime.Now.Year, 9, 22),
                EndDate = new DateTime(DateTime.Now.Year, 10, 7),
                Description = "秋季過了一半，同春分一樣，此時陽光直射赤道上，地球上南北半球受光相等，晝夜長短相等。",
                DayDescription = "9/22~10/7"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "寒露",
                StartDate = new DateTime(DateTime.Now.Year, 10, 7),
                EndDate = new DateTime(DateTime.Now.Year, 10, 23),
                Description = "此時已屆深秋，天氣轉冷，早晚所接觸到的霧氣和露水，感覺寒意沁心，而草木行將枯萎。",
                DayDescription = "10/7~10/23"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "霜降",
                StartDate = new DateTime(DateTime.Now.Year, 10, 23),
                EndDate = new DateTime(DateTime.Now.Year, 11, 7),
                Description = "天氣漸寒，當地面的物體溫度降至攝氏零度或以下，接觸的水汽直接結霜附於其上。",
                DayDescription = "10/23~11/7"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "立冬",
                StartDate = new DateTime(DateTime.Now.Year, 11, 7),
                EndDate = new DateTime(DateTime.Now.Year, 11, 21),
                Description = "冬季開始，冬是終了，作物已收割貯藏，農事完成。",
                DayDescription = "11/7~11/21"
            }); 
            SalarTerms.Add(new SalarTerms()
            {
                Name = "小雪",
                StartDate = new DateTime(DateTime.Now.Year, 11, 21),
                EndDate = new DateTime(DateTime.Now.Year, 12, 6),
                Description = "氣候寒冷，此時節空氣中的水汽在溫度冷至攝氏零度以下時，晶狀的固體由空中降下，稱為降雪，不過降雪量不多且不大。",
                DayDescription = "11/21~12/6"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "大雪",
                StartDate = new DateTime(DateTime.Now.Year, 12, 6),
                EndDate = new DateTime(DateTime.Now.Year, 12, 21),
                Description = "春季開始，立是開始的意思，春是蠢動，表示萬物開始有生氣。",
                DayDescription = "12/6~12/21"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "冬至",
                StartDate = new DateTime(DateTime.Now.Year, 12, 21),
                EndDate = new DateTime(DateTime.Now.Year, 12, 31),
                Description = "嚴冬來臨，此時陽光直射南回歸線上，北半球受光最少，是白天最短黑夜最長的一天，中午時太陽的仰角是一年裡最低的，日影是一年中最長的。",
                DayDescription = "12/21~1/5"
            });
            SalarTerms.Add(new SalarTerms()
            {
                Name = "冬至",
                StartDate = new DateTime(DateTime.Now.Year, 1, 1),
                EndDate = new DateTime(DateTime.Now.Year, 1, 5),
                Description = "嚴冬來臨，此時陽光直射南回歸線上，北半球受光最少，是白天最短黑夜最長的一天，中午時太陽的仰角是一年裡最低的，日影是一年中最長的。",
                DayDescription = "12/21~1/5"
            });
            return SalarTerms;
        }
    }
}
