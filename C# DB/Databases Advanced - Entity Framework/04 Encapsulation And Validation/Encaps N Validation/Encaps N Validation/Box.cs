using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Box
{
    private decimal length;
    private decimal width;
    private decimal height;

    public Box(decimal length, decimal width, decimal height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public decimal Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    public decimal Width
    {
        get { return width; }
        private set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    public decimal Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }

    public decimal SurfArea(decimal length, decimal width, decimal height)
    {
        //Surface Area = 2lw + 2lh + 2wh
        return 2 * length * width + 2 * length * height + 2 * width * height;
    }

    public decimal LatSurfArea(decimal length, decimal width, decimal height)
    {
        //Lateral Surface Area = 2lh + 2wh
        return 2 * length * height + 2 * width * height;
    }

    public decimal Volume(decimal length, decimal width, decimal height)
    {
        // Volume = lwh
        return length * width * height;
    }
}
