﻿using System;
using System.Collections.Generic;
using System.Text;

public class StreamProgressInfo
{
    private IStreamProgressInfo file;

    // If we want to stream a music file, we can't
    public StreamProgressInfo(IStreamProgressInfo file)
    {
        this.file = file;
    }

    public int CalculateCurrentPercent()
    {
        return (this.file.BytesSent * 100) / this.file.Length;
    }
}
