namespace Requerimientos.Models.System;

public class ThresholdUploadReachedEventArgs : EventArgs
{
    public int Progress { get; set; }
}