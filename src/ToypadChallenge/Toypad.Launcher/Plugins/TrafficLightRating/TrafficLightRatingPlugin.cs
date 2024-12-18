namespace Toypad.Launcher.Plugins.TrafficLightRating
{
    [PluginDescription("Traffic Light Rating", "Traffic light rating for indicating the status of a variable using the red, amber or green of traffic lights")]
    internal sealed class TrafficLightRatingPlugin : Plugin<TrafficLightRatingConfiguration>
    {
        private readonly TrafficLightRatingControl _control = new();

        public override void Dispose()
        {
            _control.SetToypad(null);
            _control.Dispose();
        }

        protected override TrafficLightRatingConfiguration GetDefaultConfiguration()
        {
            return new TrafficLightRatingConfiguration
            {
                UseAmber = true
            };
        }

        protected override void SetToypad(IToypad toypad)
        {
            _control.SetToypad(Toypad);
        }
        protected override void SetConfiguration(TrafficLightRatingConfiguration configuration)
        {
            _control.SetConfiguration(configuration);
        }

        protected override void UpdateConfiguration()
        {
            if (Configuration is null)
            {
                return;
            }

            _control.UpdateConfiguration(Configuration);
        }

        public override Control Control => _control;
    }
}
