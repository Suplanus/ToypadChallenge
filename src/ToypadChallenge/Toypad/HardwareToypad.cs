using LegoDimensions;
using LegoDimensions.Portal;
using Color = System.Drawing.Color;

namespace Toypad
{
    /// <summary>
    /// Wrapper around an original toypad
    /// </summary>
    public class HardwareToypad : Toypad
    {
        /// <summary>
        /// Local reference to the portal
        /// </summary>
        public readonly LegoPortal Portal;

        public HardwareToypad(LegoPortal portal)
        {
            Portal = portal ?? throw new ArgumentNullException(nameof(portal));
            Portal.LegoTagEvent += PortalOnLegoTagEvent;

            // Add already existing tags
            foreach (var tag in Portal.PresentTags)
            {
                AddTag(new Tag(
                    tag.Index, 
                    FromInternalPad(tag.Pad), 
                    tag.CardUid));
            }
        }

        /// <inheritdoc />
        protected override void OnDispose()
        {
            Portal.Dispose();
        }

        /// <inheritdoc />
        public override void SetColor(Pad pad, Color color)
        {
            base.SetColor(pad, color);

            if (pad == Pad.All)
            {
                // Special handling for all pads
                Portal.SetColor(LegoDimensions.Portal.Pad.All, FromExternalColor(color));
            }
            else
            {
                if (pad.HasFlag(Pad.Left))
                {
                    Portal.SetColor(LegoDimensions.Portal.Pad.Left, FromExternalColor(color));
                }

                if (pad.HasFlag(Pad.Right))
                {
                    Portal.SetColor(LegoDimensions.Portal.Pad.Right, FromExternalColor(color));
                }

                if (pad.HasFlag(Pad.Center))
                {
                    Portal.SetColor(LegoDimensions.Portal.Pad.Center, FromExternalColor(color));
                }
            }
        }

        /// <inheritdoc />
        public override void FlashColor(Pad pad, Color color, byte onPhase, byte offPhase, byte cycles)
        {
            base.FlashColor(pad, color, onPhase, offPhase, cycles);

            if (pad == Pad.All)
            {
                // Special handling for all pads
                Portal.Flash(LegoDimensions.Portal.Pad.All, new FlashPad(onPhase, offPhase, cycles, FromExternalColor(color)));
            }
            else
            {
                if (pad.HasFlag(Pad.Left))
                {
                    Portal.Flash(LegoDimensions.Portal.Pad.Left, new FlashPad(onPhase, offPhase, cycles, FromExternalColor(color)));
                }

                if (pad.HasFlag(Pad.Right))
                {
                    Portal.Flash(LegoDimensions.Portal.Pad.Right, new FlashPad(onPhase, offPhase, cycles, FromExternalColor(color)));
                }

                if (pad.HasFlag(Pad.Center))
                {
                    Portal.Flash(LegoDimensions.Portal.Pad.Center, new FlashPad(onPhase, offPhase, cycles, FromExternalColor(color)));
                }
            }
        }

        /// <inheritdoc />
        public override void FadeColor(Pad pad, Color color, byte time, byte cycles)
        {
            base.FadeColor(pad, color, time, cycles);

            if (pad == Pad.All)
            {
                // Special handling for all pads
                Portal.Fade(LegoDimensions.Portal.Pad.All, new FadePad(time, cycles, FromExternalColor(color)));
            }
            else
            {
                if (pad.HasFlag(Pad.Left))
                {
                    Portal.Fade(LegoDimensions.Portal.Pad.Left, new FadePad(time, cycles, FromExternalColor(color)));
                }

                if (pad.HasFlag(Pad.Right))
                {
                    Portal.Fade(LegoDimensions.Portal.Pad.Right, new FadePad(time, cycles, FromExternalColor(color)));
                }

                if (pad.HasFlag(Pad.Center))
                {
                    Portal.Fade(LegoDimensions.Portal.Pad.Center, new FadePad(time, cycles, FromExternalColor(color)));
                }
            }
            //Thread.Sleep(time * 10);
        }

        /// <summary>
        /// Handle changed tags
        /// </summary>
        private void PortalOnLegoTagEvent(object? sender, LegoTagEventArgs e)
        {
            if (e.Present)
            {
                AddTag(new Tag(
                    e.Index, 
                    FromInternalPad(e.Pad), 
                    e.CardUid, 
                    e.LegoTag?.Name ?? ""));
            }
            else
            {
                RemoveTagByIndex(e.Index);
            }
        }

        /// <summary>
        /// Translates from internal pad enum to the external one
        /// </summary>
        private Pad FromInternalPad(LegoDimensions.Portal.Pad pad)
        {
            switch (pad)
            {
                case LegoDimensions.Portal.Pad.Left:
                    return Pad.Left;
                case LegoDimensions.Portal.Pad.Center:
                    return Pad.Center;
                case LegoDimensions.Portal.Pad.Right: 
                    return Pad.Right;
                default:
                    throw new ArgumentException("Position makes no sense.");
            }
        }

        /// <summary>
        /// Converts external color to internal one
        /// </summary>
        private LegoDimensions.Color FromExternalColor(Color color)
        {
            return LegoDimensions.Color.FromArgb(color.ToArgb());
        }
    }
}
