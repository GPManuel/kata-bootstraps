namespace DotnetStarter.Logic;

internal record Light
{
    public bool State;

    public void ChangeBrightness(bool state)
    {
        State = state;
    }
}