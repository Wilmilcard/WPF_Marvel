using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.Models
{
    public class Comic
    {
        public int id { get; set; }
        public int digitalId { get; set; }
        public string title { get; set; }
        public double issueNumber { get; set; }
        public string variantDescription { get; set; }
        public object description { get; set; }
        public DateTime modified { get; set; }
        public string isbn { get; set; }
        public string upc { get; set; }
        public string diamondCode { get; set; }
        public string ean { get; set; }
        public string issn { get; set; }
        public string format { get; set; }
        public int pageCount { get; set; }
        public List<TextObject> textObjects { get; set; }
        public string resourceURI { get; set; }
        public List<Url> urls { get; set; }
        public SeriesSummary series { get; set; }
        public List<ComicSummary> variants { get; set; }
        public List<ComicSummary> collections { get; set; }
        public List<ComicSummary> collectedIssues { get; set; }
        public List<ComicDate> dates { get; set; }
        public List<ComicPrice> prices { get; set; }
        public Image thumbnail { get; set; }
        public List<Image> images { get; set; }
        public CreatorList creators { get; set; }
        public CharacterList characters { get; set; }
        public StoryList stories { get; set; }
        public EventList events { get; set; }
    }
}
