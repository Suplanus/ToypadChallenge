
namespace Toypad.Launcher.Plugins.TrafficLightRating
{
    public partial class TrafficLightRatingControl : UserControl
    {
        private IToypad? _toypad;
        private TrafficLightRatingConfiguration? _configuration;
        private TrafficLightRatingStatistic _trafficLightRatingStatistic = new();

        public TrafficLightRatingControl()
        {
            _toypad = null;
            InitializeComponent();
        }

        internal void SetConfiguration(TrafficLightRatingConfiguration configuration)
        {
            _configuration = configuration;

            checkUseAmber.Checked = configuration.UseAmber;

            UpdateConfigOfControlsAndToyPad();
        }

        internal void UpdateConfiguration(TrafficLightRatingConfiguration configuration)
        {
            configuration.UseAmber = checkUseAmber.Checked;
        }

        internal void SetToypad(IToypad? toypad)
        {
            if (_toypad == toypad)
            {
                return;
            }

            if (_toypad is not null)
            {
                _toypad.TagAdded -= ToypadOnTagAdded;
            }

            _toypad = toypad;

            if (_toypad is not null)
            {
                _toypad.TagAdded += ToypadOnTagAdded;

                _toypad.SetColor(Pad.Left, Color.Red);
                _toypad.SetColor(Pad.Right, Color.Green);
            }

            ResetStatistic();
        }

        private void ToypadOnTagAdded(object? sender, Tag tag)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    Add(tag);
                });
            }
            else
            {
                Add(tag);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetStatistic();
        }

        private void CheckUseAmber_CheckedChanged(object sender, EventArgs e)
        {
            if (_configuration is not null)
            {
                _configuration.UseAmber = checkUseAmber.Checked;
            }

            UpdateConfigOfControlsAndToyPad();

            ResetStatistic();
        }

        private void Add(Tag tag)
        {
            switch (tag.Pad)
            {
                case Pad.Left:
                    _trafficLightRatingStatistic.AddToStatistic(tag.Uid, TrafficLightRatingPosition.Red);
                    break;
                case Pad.Center:
                    _trafficLightRatingStatistic.AddToStatistic(tag.Uid, TrafficLightRatingPosition.Amber);
                    break;
                case Pad.Right:
                    _trafficLightRatingStatistic.AddToStatistic(tag.Uid, TrafficLightRatingPosition.Green);
                    break;
            }

            UpdateControls();
        }

        private void UpdateControls()
        {
            var maxHeight = (double)(tableLayout.Height - 170);

            pnlRed.Height = (int)Math.Floor(maxHeight * _trafficLightRatingStatistic.NumRed / _trafficLightRatingStatistic.MaxNum);
            pnlAmber.Height = (int)Math.Floor(maxHeight * _trafficLightRatingStatistic.NumAmber / _trafficLightRatingStatistic.MaxNum);
            pnlGreen.Height = (int)Math.Floor(maxHeight * _trafficLightRatingStatistic.NumGreen / _trafficLightRatingStatistic.MaxNum);

            lblRed.Text = _trafficLightRatingStatistic.NumRed.ToString();
            lblAmber.Text = _trafficLightRatingStatistic.NumAmber.ToString();
            lblGreen.Text = _trafficLightRatingStatistic.NumGreen.ToString();
        }

        private void ResetStatistic()
        {
            _trafficLightRatingStatistic = new();

            if (_toypad is not null)
            {
                foreach (var tag in _toypad.Tags)
                {
                    ToypadOnTagAdded(_toypad, tag);
                }
            }

            UpdateControls();
        }

        private void UpdateConfigOfControlsAndToyPad()
        {
            var useAmber = _configuration?.UseAmber ?? false;

            SuspendLayout();

            lblAmber.Visible = useAmber;
            pnlAmber.Visible = useAmber;

            tableLayout.ColumnStyles[3].Width = useAmber ? 33.3333f : 10.0f;
            tableLayout.ColumnStyles[3].SizeType = useAmber ? SizeType.Percent : SizeType.Absolute;

            ResumeLayout();

            _toypad?.SetColor(Pad.Center, useAmber ? Color.Yellow : Color.Black);
        }
    }
}
