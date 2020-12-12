using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace WebLab1_Levchenko.Blazor.Data
{

    public class CatsListViewModel
    {
        [JsonPropertyName("catsID")]
        public int CatsID { get; set; } // id блюда

        [JsonPropertyName("catsName")]
        public string CatsName { get; set; } // название 
    }

    public class CatsDetailsViewModel
    {
        [JsonPropertyName("catsName")]public string CatsName { get; set; } // название котенка
        
        [JsonPropertyName("catsColor")]public string CatsColor { get; set; } // описание
        
        [JsonPropertyName("catsWeight")]public int CatsWeight { get; set; } // кол. 
        
        [JsonPropertyName("image")]public string Image { get; set; } // имя файла изображения
    }
}
