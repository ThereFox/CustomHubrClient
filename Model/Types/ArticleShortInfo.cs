using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Types
{
    public class ArticleShortInfo
    {
        public long Id { get; init; }
        public string Title { get; init; }
        public List<string> Tags { get; init; }
        public int Rating { get; init; }
        public uint CommentaryCount { get; init; }

        public ArticleShortInfo(long id, string title, List<string> tags, int rating, uint commentaryCount)
        {
            Id = id;
            Title = title;
            Tags = tags;
            Rating = rating;
            CommentaryCount = commentaryCount;
        }
    }
}
