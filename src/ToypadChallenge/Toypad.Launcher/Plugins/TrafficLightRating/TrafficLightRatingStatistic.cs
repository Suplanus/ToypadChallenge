using System.Collections.ObjectModel;

namespace Toypad.Launcher.Plugins.TrafficLightRating
{
    internal sealed class TrafficLightRatingStatistic
    {
        private readonly Dictionary<string, TrafficLightRatingPosition> _statistic = [];

        internal void AddToStatistic(ReadOnlyCollection<byte> uid, TrafficLightRatingPosition position)
        {
            var key = string.Join("-", uid.Select(x => x.ToString("X2")));

            _statistic[key] = position;

            int value;
            var groups = _statistic.GroupBy(kvp => kvp.Value).ToDictionary(g => g.Key, g => g.Count());

            NumRed = groups.TryGetValue(TrafficLightRatingPosition.Red, out value) ? value : 0;
            NumAmber = groups.TryGetValue(TrafficLightRatingPosition.Amber, out value) ? value : 0;
            NumGreen = groups.TryGetValue(TrafficLightRatingPosition.Green, out value) ? value : 0;

            MaxNum = (int)Math.Ceiling(Math.Max(NumRed, Math.Max(NumAmber, NumGreen)) / 10.0) * 10;
        }

        public int NumRed { get; set; }
        public int NumAmber { get; set; }
        public int NumGreen { get; set; }

        public int MaxNum { get; set; }
    }
}
