public class VisualizerControl: Control
{
    private Color[] _colors;
    public Color[] Colors
    {
        get
        {
            return _colors;
        }
        set
        {
            _colors = value;
            // Redraw if the array is changed to a new one.
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;

        // Draw the background.
        g.Clear(BackColor);

        // If the array's null or too small, don't try to draw it.
        if (Colors == null || Colors.Length == 0)
        {
            return;
        }

        // Start drawing squares at (10, 10), moving horizontally
        // for each one, with 5px between them.
        var x = 10;
        var y = 10;
        var squareSide = 20;
        var buffer = 5;

        foreach (var color in Colors)
        {
            using (var b = new SolidBrush(color))
            {
                g.FillRectangle(b, x, y, squareSide, squareSide);

                // "move" to the next square
                x += squareSide + buffer;
            }
        }
    }
}