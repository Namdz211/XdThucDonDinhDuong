using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phần_Mềm_Dinh_Dưỡng
{
    public class DinhDuong
    {
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
    }

    public class NutritionInfo
    {
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }

        public Dictionary<string, string> CompareWithStandard(NutritionInfo standard)
        {
            return new Dictionary<string, string>
            {
                ["Calories"] = $"{Calories:F2} kcal ({(Calories / standard.Calories * 100):F2}%)",
                ["Protein"] = $"{Protein:F2}g ({(Protein / standard.Protein * 100):F2}%)",
                ["Carbs"] = $"{Carbs:F2}g ({(Carbs / standard.Carbs * 100):F2}%)",
                ["Fat"] = $"{Fat:F2}g ({(Fat / standard.Fat * 100):F2}%)",
                ["Fiber"] = $"{Fiber:F2}g ({(Fiber / standard.Fiber * 100):F2}%)"
            };
        }
        private NutritionInfo GetStandardNutrition(string nhomTre)
        {
            return new NutritionInfo
            {
                Calories = nhomTre == "Nhóm mẫu giáo" ? 1200 : 900,
                Protein = nhomTre == "Nhóm mẫu giáo" ? 30 : 25,
                Carbs = nhomTre == "Nhóm mẫu giáo" ? 150 : 120,
                Fat = nhomTre == "Nhóm mẫu giáo" ? 40 : 30,
                Fiber = nhomTre == "Nhóm mẫu giáo" ? 15 : 10
            };
        }
    }

}
