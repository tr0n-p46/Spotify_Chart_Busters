using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class ChartbustersResourceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artists { get; set; }
        public float? Danceability { get; set; }
        public float? Energy { get; set; }
        public int? Key { get; set; }
        public float? Loudness { get; set; }
        public int? Mode { get; set; }
        public float? Speechiness { get; set; }
        public float? Acousticness { get; set; }
        public float? Instrumentalness { get; set; }
        public float? Liveness { get; set; }
        public float? Valence { get; set; }
        public float? Tempo { get; set; }
        public int? DurationMs { get; set; }
        public int? TimeSignature { get; set; }
        public int? Rank { get; set; }
    }
}
