namespace DotnetStarter.Logic;

internal record Light
{
    public int Brightness;

    public void ChangeBrightness(int increasedBrightness)
    {
        Brightness += increasedBrightness;
    }
}